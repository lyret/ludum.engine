using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LudumEngine
{
	/// <summary>
	/// The Render Manager handles the ultimate drawing to the screen, it initializes
	/// The hardware graphics and keeps track of options such as window resolution and fullscreen preference.
	/// </summary>
	public class RenderManager
	{
		private bool _initialized = false;

		// XNA Properties used for drawing 2D Graphics
		internal SpriteBatch SpriteBatch { get; set; }
		internal GraphicsDeviceManager DeviceManager { get; set; }

		#region settings

		internal Color WindowBackgroundColor = Color.Black;
		internal bool IsFullscreen = false;

		#endregion settings

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.RenderManager"/> class.
		/// </summary>
		/// <param name="game">The GameManager, for initializing graphics.</param>
		internal RenderManager(GameManager game)
		{
			this.DeviceManager = new GraphicsDeviceManager(game);
		}

		/// <summary>
		/// Creates the device manager and sprite batch, and sets the initial display options.
		/// This needs to be done when the hardware has been initialized by the GameManager
		/// </summary>
		internal void Initialize()
		{
			this.SpriteBatch = new SpriteBatch (this.DeviceManager.GraphicsDevice);
			this.DeviceManager.IsFullScreen = IsFullscreen;
			this._initialized = true;
		}

		/// <summary>
		/// Sets standard/global draw options and trigger the draw event of the current scene.
		/// </summary>
		internal void Draw()
		{
			if (!_initialized) Initialize();

			DeviceManager.GraphicsDevice.Clear (WindowBackgroundColor.XnaColor);
			SpriteBatch.Begin (SpriteSortMode.BackToFront, BlendState.AlphaBlend);

			// Draws the selected scene
            if (Ludum.Scenes.CurrentScene != null)
			    Ludum.Scenes.CurrentScene.Draw();

			SpriteBatch.End ();
		}
	}
}