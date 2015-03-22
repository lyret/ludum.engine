using System;
using System.Collections.Generic;

namespace LudumEngine
{
	/// <summary>
	/// A Component collection is a set of unique components, it uses generics to increase
	/// the typeability of the engine and make sure that the maximum of one component per type
	/// exists in each collection.
	/// </summary>
	internal class ComponentCollection
	{
		private Dictionary<string, Component> _components;

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.ComponentCollection"/> class.
		/// </summary>
		internal ComponentCollection()
		{
			_components = new Dictionary<string, Component> ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.ComponentCollection"/> class
		/// as a copy of another collection.
		/// </summary>
		/// <param name="parent">the collection to copy.</param>
		internal ComponentCollection(ComponentCollection parent)
		{
			_components = parent.CloneDictionary ();
		}

		/// <summary>
		/// Creates a copy of all components in this collection and returns them as
		/// a dictionary.
		/// </summary>
		/// <returns>A dictionary of all components in this collection.</returns>
		internal Dictionary<string, Component> CloneDictionary()
		{
			Dictionary<string, Component> newComponents = new Dictionary<string, Component> ();

			foreach (string key in _components.Keys) {
				newComponents[key] = _components [key].Clone ();
			}

			return newComponents;
		}

		/// <summary>
		/// Determines whether a component of a given type is in this collection
		/// </summary>
		/// <returns><c>true</c> if the collection contains the component; otherwise, <c>false</c>.</returns>
		/// <typeparam name="T">The type of component to look for.</typeparam>
		internal bool HasComponent<T> () where T: Component
		{
			string key = typeof(T).Name;

			return (_components.ContainsKey(key));
		}

		/// <summary>
		/// Adds the component.
		/// </summary>
		/// <returns>The component.</returns>
		/// <param name="writeover">If set to <c>true</c> writeover.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		internal T AddComponent<T> (bool writeover = false) where T : Component, new()
		{
			string key = typeof(T).Name;

			if (_components.ContainsKey(key) && writeover == false)
			{
				throw Ludum.Error.General("the component '" + key + "' already exists!");
			}

			T component = new T();
			_components [key] = component;

			return component;
		}

		/// <summary>
		/// Returns a component of a given type from the collection
		/// </summary>
		/// <returns>The component if it exists, otherwise null.</returns>
		/// <typeparam name="T">The type of component to retrive.</typeparam>
		internal T GetComponent<T> (bool required = true) where T: Component
		{
			string key = typeof(T).Name;

			if (!_components.ContainsKey(key))
			{
				return null;
			}

			return (T) _components [key];
		}

		/// <summary>
		/// Removes a component from this collection.
		/// </summary>
		/// <typeparam name="T">The type of the component to remove.</typeparam>
		internal void RemoveComponent<T> () where T: Component
		{
			string key = typeof(T).Name;

			if (!_components.ContainsKey(key))
			{
				return;
			}

			_components.Remove (key);
		}

		/// <summary>
		/// Gets all list of all components in this collection.
		/// </summary>
		/// <returns>A List of components.</returns>
		internal List<Component> GetAllComponents()
		{
			return new List<Component> (_components.Values);
		}
	}
}