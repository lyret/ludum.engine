using System;
using System.Collections.Generic;

namespace LudumEngine
{
	/// <summary>
	/// The Scene manager contains all the created scenes and
	/// contains methods for manipulating them.
	/// </summary>
	public class SceneManager
	{
		private Dictionary<String, Scene> _scenes = new Dictionary<String, Scene>();

		/// <summary>
		/// The currently active scene that is supposed to be drawn.
		/// </summary>
		/// <value>A scene.</value>
		internal Scene CurrentScene { get; set; }
        

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.SceneManager"/> class.
		/// </summary>
		internal SceneManager() {
			ClearContent();
            CurrentScene = null;
		}

		/// <summary>
		/// Clears and removes all created scenes from memory.
		/// </summary>
		internal void ClearContent()
		{
			_scenes = new Dictionary<String, Scene>();
		}


		public void GoTo(Scene scene)
		{
			//Leave the current scene
			if (CurrentScene != null) {
				CurrentScene.Leave();
			}
		
			//Go to the next scene
			CurrentScene = scene;
			CurrentScene.GoTo();
		}

		/// <summary>
		/// Creates a new Game Scene and returns it. It it stored
		/// at a location in the dictionary that must be unique.
		/// </summary>
		/// <returns>A new Scene.</returns>
		/// <param name="name">The unique name for the new scene.</param>
		public Scene CreateScene(string name)
		{
			if (_scenes.ContainsKey (name))
			{
				throw Ludum.Error.General("A scene named '" + name + "' already exists.");
			}

			Scene scene = new Scene();
			scene.Id = name;
			_scenes[name] = scene;
			return scene;
		}

		/// <summary>
		/// Loads a selected scene in advance.
		/// </summary>
		/// <param name="name">The name of the scene to preload.</param>
		public void PreloadScene(string name)
		{
			// Retrive the scene.
			Scene scene = GetScene(name);

			// Load the scene.
			scene.Load();
		}

		/// <summary>
		/// Gets a previous exisiting Game Scene. Usefull for getting a scene
		/// when currently in another game scene.
		/// </summary>
		/// <returns>The Scene.</returns>
		/// <param name="name">The name of the scene to retrive.</param>
		public Scene GetScene(string name)
		{
			if (!_scenes.ContainsKey (name)) {
				throw Ludum.Error.General("An scene namned '" + name + "' does not exists.");
			}

			return _scenes[name];
		}

		/// <summary>
		/// Removes an existing Game Scene from storage, this frees up memory.
		/// </summary>
		/// <param name="name">The name of the scene.</param>
		public void RemoveScene(string name)
		{
			if (!_scenes.ContainsKey (name)) {
				throw Ludum.Error.General("A scene with the name '" + name + "' does not exists.");
			}

			_scenes[name].Delete();
			_scenes.Remove(name);
		}
	}
}