using System;
using System.Collections.Generic;

namespace LudumEngine
{
	/// <summary>
	/// An Entity is basicly an collection of initialized components that is created
	/// from an blueprint and added to a scene. A synonym to "game object" in other
	/// engines.
	/// </summary>
	public sealed class Entity
	{
		private ComponentCollection _componentCollection;

		/// <summary>
		/// The scene this entity belongs to.
		/// </summary>
		/// <value>a scene.</value>
		internal Scene Scene { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.Entity"/> class from a
		/// entity blueprint and assigns it to a scene.
		/// </summary>
		/// <param name="blueprint">A blueprint to instantiate from.</param>
		/// <param name="scene">A scene to add the entity to.</param>
		internal Entity(EntityBlueprint blueprint, Scene scene)
		{
			this.Scene = scene;

			_componentCollection = new ComponentCollection (blueprint.ComponentCollection);

			foreach (Component component in _componentCollection.GetAllComponents()) {
				component.Entity = this;
				component.Reset ();
				component.Initialize ();
			}
		}

		/// <summary>
		/// Hides the default constructor, throws an error if actually accessed.
		/// </summary>
		internal Entity() {
			throw new Exception("A Entity can only be created from a blueprint.");
		}

		/// <summary>
		/// Delete all components in this entity.
		/// </summary>
		public void Delete()
		{
			// Get all current components
			var allComponents = _componentCollection.GetAllComponents();

			// Remove all component references
			_componentCollection = new ComponentCollection ();

			// Make sure all components destroy themselfs
			foreach (Component component in allComponents) {
				component.Delete ();
			}
		}

		/// <summary>
		/// Determines whether this entity has the (initialized) component or not.
		/// </summary>
		/// <returns><c>true</c> if the component exists; otherwise, <c>false</c>.</returns>
		/// <typeparam name="T">The component to check for.</typeparam>
		public bool HasComponent<T> () where T: Component
		{
			return _componentCollection.HasComponent<T>();
		}

		/// <summary>
		/// Creates a new component on the fly. Adds it to this entity and initializes it.
		/// The new component is returned for possible customization.
		/// </summary>
		/// <returns>The created and initialized component.</returns>
		/// <typeparam name="T">The type of component to initialize.</typeparam>
		public T CreateComponent<T> () where T: Component, new()
		{
			T component = _componentCollection.AddComponent<T>(writeover: true);
			component.Entity = this;
			component.Reset ();
			component.Initialize ();

			return component;
		}
	
		/// <summary>
		/// Gets a (initialized) component.
		/// </summary>
		/// <returns>The component.</returns>
		/// <typeparam name="T">The component to retrive.</typeparam>
		public T GetComponent<T> (bool required = false, bool createifmissing = true) where T: Component, new()
		{
			if (!HasComponent<T> () && createifmissing && !required)
				return CreateComponent<T> ();

			return _componentCollection.GetComponent<T>(required);
		}
	
		/// <summary>
		/// Deletes a (initialized) component.
		/// </summary>
		/// <typeparam name="T">The component to remove.</typeparam>
		public void DeleteComponent<T> () where T: Component, new()
		{
			T component = _componentCollection.GetComponent<T> (required: false);

			if (component != null)
				component.Delete ();

			_componentCollection.RemoveComponent<T> ();
		}
	}
}