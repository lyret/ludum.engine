using System;
using System.Collections.Generic;

namespace LudumEngine
{
	/// <summary>
	/// The Blueprint Manager is a central place to create, store and manage blueprints that acts as standard configurations for entities.
	/// It stores blueprints through the entire run of the game so that they can be declered once and accessed many times.
	/// </summary>
	public class BlueprintManager
	{
		private Dictionary<string, EntityBlueprint> _blueprints;

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.BlueprintManager"/> class.
		/// </summary>
		internal BlueprintManager()
		{
			ClearContent();
		}

		/// <summary>
		/// Clears all created blueprints.
		/// </summary>
		internal void ClearContent()
		{
			_blueprints = new Dictionary<string, EntityBlueprint> ();
		}

		/// <summary>
		/// Creates a new EntityBlueprint and returns it. It it stored
		/// at a location in the dictionary that must be unique.
		/// </summary>
		/// <returns>A new EntityBlueprint.</returns>
		/// <param name="name">The unique name for the new blueprint.</param>
		public EntityBlueprint CreateEntityBlueprint(string name)
		{
			if (_blueprints.ContainsKey (name))
			{
				throw Ludum.Error.General("A Entity specification named '" + name + "' already exists.");
			}

			EntityBlueprint blueprint = new EntityBlueprint();
			_blueprints[name] = blueprint;
			return blueprint;
		}

		/// <summary>
		/// Creates a new EntityBlueprint that is a copy of a previous one.
		/// </summary>
		/// <returns>A new EntityBlueprint.</returns>
		/// <param name="name">The unique name for the new blueprint.</param>
		/// <param name="copyfrom">The unique name for the blueprint to copy from.</param>
		public EntityBlueprint CopyEntityBlueprint(string name, string copyfrom)
		{
			if (_blueprints.ContainsKey (name)) {
				throw Ludum.Error.General("A Entity specification named '" + name + "' already exists.");
			}

			EntityBlueprint parent = GetEntityBlueprint(name);
			EntityBlueprint blueprint = new EntityBlueprint(parent);
			_blueprints[name] = blueprint;

			return blueprint;
		}

		/// <summary>
		/// Gets a previous exisiting EntityBlueprint. Usefull for getting a blueprint
		/// that is declered in a previous scene.
		/// </summary>
		/// <returns>The entity blueprint.</returns>
		/// <param name="name">The name of the blueprint.</param>
		public EntityBlueprint GetEntityBlueprint(string name)
		{
			if (!_blueprints.ContainsKey (name)) {
				throw Ludum.Error.General("An entity specification for '" + name + "' does not exists.");
			}

			return _blueprints [name];
		}

		/// <summary>
		/// Removes an existing entity blueprint from storage, this frees up memory.
		/// </summary>
		/// <param name="name">The name of the blueprint.</param>
		public void RemoveEntityBlueprint(string name)
		{
			if (!_blueprints.ContainsKey (name)) {
				throw Ludum.Error.General("An entity specification for '" + name + "' does not exists.");
			}

			_blueprints[name].Delete();
			_blueprints.Remove(name);
		}
	}
}