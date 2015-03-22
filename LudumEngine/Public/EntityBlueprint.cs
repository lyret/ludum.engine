using System;

namespace LudumEngine
{
	/// <summary>
	/// A Entity blueprint is a class that defines a common set of components
	/// that can easily be instantiated into entities and added to a scene.
	/// </summary>
	public sealed class EntityBlueprint
	{
		/// <summary>
		/// Gets the component collection of the blueprint.
		/// </summary>
		/// <value>The component collection.</value>
		internal ComponentCollection ComponentCollection { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.EntityBlueprint"/> class.
		/// </summary>
		internal EntityBlueprint()
		{
			this.ComponentCollection = new ComponentCollection ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.EntityBlueprint"/> class as 
		/// a copy of another blueprint.
		/// </summary>
		/// <param name="parent">The blueprint to copy.</param>
		internal EntityBlueprint(EntityBlueprint parent)
		{
			this.ComponentCollection = new ComponentCollection (parent.ComponentCollection);
		}

		/// <summary>
		/// Delete all components in this entity.
		/// </summary>
		internal void Delete()
		{
			// Get all current components
			var allComponents = ComponentCollection.GetAllComponents();

			// Remove all component references
			ComponentCollection = new ComponentCollection ();

			// Make sure all components destroy themselfs
			foreach (Component component in allComponents) {
				component.Delete ();
			}
		}

		/// <summary>
		/// Determines whether a blueprint has a specific component.
		/// </summary>
		/// <returns><c>true</c> if the component exists; otherwise, <c>false</c>.</returns>
		/// <typeparam name="T">The component to check for.</typeparam>
		public bool HasComponent<T> () where T: Component
		{
			return ComponentCollection.HasComponent<T>();
		}

		/// <summary>
		/// Adds a component to this blueprint and returns a reference to it,
		/// so that it can easily be customized.
		/// </summary>
		/// <returns>The added component.</returns>
		/// <typeparam name="T">The type of component to add.</typeparam>
		public T AddComponent<T> () where T: Component, new()
		{
			return (T) ComponentCollection.AddComponent<T> (writeover: false);
		}

		/// <summary>
		/// Gets a component from this blueprint.
		/// </summary>
		/// <returns>The component.</returns>
		/// <typeparam name="T">The component to retrive.</typeparam>
		public T GetComponent<T> () where T: Component
		{
			return ComponentCollection.GetComponent<T>();
		}

		/// <summary>
		/// Removes a component from this blueprint.
		/// </summary>
		/// <typeparam name="T">The component to remove.</typeparam>
		public void RemoveComponent<T> () where T: Component, new()
		{
			ComponentCollection.RemoveComponent<T> ();
		}
	}
}

