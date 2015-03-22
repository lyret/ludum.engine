using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LudumEngine
{
	/// <summary>
	/// A Scene is a collection of entities that belong togheter, it is meant to form
	/// game sector or sequences; for example a level, loading screen, menu or game area.
	/// </summary>
	public sealed class Scene
	{
		private bool _currentlyActive = false;
		private bool _isLoaded = false;
		private bool _isPaused = false;
		private bool _isAutoPaused = false;
		private bool _willAutoPause;
		private Color _backgroundColor;

		// Internal events available for components
		internal Event OnLoad = new Event();
		internal Event OnUnload = new Event();
		internal Event OnUpdate = new Event();
		internal Event OnDraw = new Event();
		internal Event OnGoTo = new Event();
		internal Event OnLeave = new Event();
		internal Event OnDelete = new Event();

		// This scenes input handler
		public InputHandler Input { get; private set; }

		/// <summary>
		/// The id used to find this scene in the scene manager.
		/// </summary>
		/// <value>A string identifier.</value>
		public string Id { get; internal set; }

		/// <summary>
		/// Indicates whether this scene should be keept in memory when it
		/// becomes inactive.
		/// </summary>
		/// <value><c>true</c> if keept in memory; otherwise, <c>false</c>.</value>
		public Boolean KeepInMemory { get; set; }

		/// <summary>
		/// Indicates wheteher this scene will be automaticly paused and resumed
		/// when it switches between being the active scene.
		/// </summary>
		/// <value><c>true</c> if auto pausing; otherwise, <c>false</c>.</value>
		public Boolean AutoPausing { 
			
			get { return _willAutoPause; }

			set {
				if (_currentlyActive) {
					_isAutoPaused = value;
				}
				_willAutoPause = value;
			}
		}

		/// <summary>
		/// Indicates if this scene is paused or not, and allows the scene
		/// to be manually paused.
		/// </summary>
		/// <value><c>true</c> if currently paused; otherwise, <c>false</c>.</value>
		public Boolean Paused {

			get { return (_isPaused || _isAutoPaused); }

			set { _isPaused = value; }
		}

		/// <summary>
		/// The background color of the screen when this scene is active.
		/// </summary>
		/// <value>a color.</value>
		public Color BackgroundColor {

			get { return _backgroundColor; }

			set {
				_backgroundColor = value;

				if (_currentlyActive)
					Ludum.RenderManager.WindowBackgroundColor = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.Scene"/> class.
		/// </summary>
		internal Scene ()
		{
			KeepInMemory = false;
			AutoPausing = true;
			BackgroundColor = Color.Black;
			Input = new InputHandler();
		}

		/// <summary>
		/// Deletes this scene and all accosiated entities.
		/// </summary>
		internal void Delete()
		{
			OnDelete.Trigger();
		}

		/// <summary>
		/// Method called when this scene is made active.
		/// </summary>
		internal void GoTo()
		{
			// Resume the scene if autopausing.
			if (AutoPausing) {
				_isAutoPaused = false;
			}

			// Set the correct background color
			Ludum.RenderManager.WindowBackgroundColor = BackgroundColor;

			// Load content if so is not already done.
			if (!_isLoaded) {
				Load();
			}

			// Flag as active.
			_currentlyActive = true;

			// Trigger event
			OnGoTo.Trigger();
		}

		/// <summary>
		/// Method called when this scene becomes inactive.
		/// </summary>
		internal void Leave()
		{
			// Pause the scene if autopausing.
			if (AutoPausing) {
				_isAutoPaused = true;
			}

			// Unload
			if (!KeepInMemory) {
				Unload();
			}

			// Flag as inactive.
			_currentlyActive = false;

			// Trigger event
			OnLeave.Trigger();
		}

		/// <summary>
		/// Update loop for entities in this scene.
		/// </summary>
		internal void Update()
		{
			// Do nothing if paused
			if (Paused) {
				return;
			}

			// Trigger event
			OnUpdate.Trigger();
		}

		/// <summary>
		/// Draw loop for entities in this scene.
		/// </summary>
		internal void Draw()
		{
			// Do nothing if paused
			if (Paused) {
				return;
			}

			// Trigger event
			OnDraw.Trigger();
		}

		/// <summary>
		/// Loads this scene to memory.
		/// </summary>
		internal void Load()
		{
			// Trigger event
			OnLoad.Trigger();

			// Flag as loaded.
			_isLoaded = true;
		}

		/// <summary>
		/// Unload this scene from memory.
		/// </summary>
		internal void Unload()
		{
			// Trigger event
			OnUnload.Trigger();

			// Flag as unloaded.
			_isLoaded = false;
		}

		/// <summary>
		/// Creates a new entity and adds it to this scene.
		/// </summary>
		/// <returns>The new entity.</returns>
		/// <param name="blueprint">The EntityBlueprint to create from.</param>
		public Entity CreateEntity(EntityBlueprint blueprint) {

			// Create the entity and add it to the scene.
			Entity newEntity = new Entity (blueprint, this);

			// Add specific subscriptions to this event.
			OnDelete.Subscribe(newEntity.Delete);

			// Then return it.
			return newEntity;
		}
	}
}