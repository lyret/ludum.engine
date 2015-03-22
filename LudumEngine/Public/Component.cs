using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace LudumEngine
{
	/// <summary>
	/// Component is the core class of the entire engine! It's abstract and needs to be extended,
	/// but in this base class are some common functionallity for all components to communicate
	/// with each others and with managers.
	/// Its component should be written to cover a specific dimension/state or behavior of a
	/// entity; compont could for example be named: position, ableToShoot, Flying, Defender, Explorer, Health etc.
	/// The Initialize method replaces the functionallity of a constructor and is called
	/// when a component becomes attached to an actual entity and should start
	/// performing its indended functionallity.
	/// </summary>
	public abstract class Component
	{
		private List<Tuple<Event, int>> _eventSubscriptions;

		/// <summary>
		/// Initializes this component.
		/// </summary>
		public abstract void Initialize();

		/// <summary>
		/// The entity this component belongs to when initialized.
		/// </summary>
		/// <value>an entity.</value>
		public Entity Entity { get; set; }

		/// <summary>
		/// The scene this component belongs to when initialized.
		/// </summary>
		/// <value>a scene.</value>
		public Scene Scene { get { return this.Entity.Scene; } }

		/// <summary>
		/// The components that are dependent on this component.
		/// </summary>
		/// <value>list of all dependent components.</value>
		internal List<Component> DependentComponents { get; set; }

		/// <summary>
		/// Standard constructor for components.
		/// </summary>
		public Component() {}

		/// <summary>
		/// Creates a clone of this component.
		/// </summary>
		internal Component Clone()
		{
            Component component = (Component) this.Copy();
			component.Reset();

			return component;
		}

		/// <summary>
		/// Resets the standard members of a component to its pre-initialized state.
		/// </summary>
		public void Reset() {
			_eventSubscriptions = new List<Tuple<Event, int>>();
			DependentComponents = new List<Component>();
		}

		/// <summary>
		/// Deletes this component and all dependent components.
		/// </summary>
		internal void Delete()
		{
			// Delete all dependent components
			foreach (Component component in DependentComponents)
			{
				component.Delete();
			}

			// Remove the reference to dependent components
			DependentComponents = new List<Component>();
			
			// Remove all subscriptions of this component
			foreach (Tuple<Event, int> tuple in _eventSubscriptions)
			{
				Event happening = tuple.Item1;
				int delegationId = tuple.Item2;

				happening.Unsubscribe (delegationId);
			}
		}

		/// <summary>
		/// Subscribes to an event, sends a method from this component to be
		/// executed when an event triggers.
		/// </summary>
		/// <param name="happening">The event to subscribe to.</param>
		/// <param name="function">The method to send.</param>
		protected void SubscribeToEvent(Event happening, Delegate function)
		{
			_eventSubscriptions.Add(new Tuple<Event,int>(happening, happening.Subscribe (function)));
		}

		/// <summary>
		/// Subscribes to the scenes draw event.
		/// </summary>
		/// <param name="function">The method to send.</param>
		protected void SubscribeToDrawEvent(Delegate function)
		{
			SubscribeToEvent(this.Scene.OnDraw, function);
		}

		/// <summary>
		/// Subscribes to the scenes update event.
		/// </summary>
		/// <param name="function">The method to send.</param>
		protected void SubscribeToUpdateEvent(Delegate function)
		{
			SubscribeToEvent(this.Scene.OnUpdate, function);
		}

		/// <summary>
		/// Subscribes to the scenes load event.
		/// </summary>
		/// <param name="function">The method to send.</param>
        protected void SubscribeToLoadEvent(Delegate function)
        {
            SubscribeToEvent(this.Scene.OnLoad, function);
        }

		/// <summary>
		/// Gets a refrence to another component, this is the safe way
		/// to access another component in the same, or another, entity.
		/// If it does not exists it will be automaticly created.
		/// </summary>
		/// <returns>The wanted component.</returns>
		/// <param name="entity">An Entity, defaults to the same entity as this component.</param>
		/// <typeparam name="T">The component to retrive.</typeparam>
		protected T RequiredComponent<T>(Entity entity = null) where T : Component, new()
		{
			// Check for the default entity value
			if (entity == null)
				entity = this.Entity;
			 
			// Retrive the wanted component
			T wantedComponent = entity.GetComponent<T>();

			// Add this component as a dependent at the wanted component.
			wantedComponent.DependentComponents.Add(this);

			//Return the wanted component
			return wantedComponent;
		}
	}
}

