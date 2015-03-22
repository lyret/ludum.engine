using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LudumEngine
{
	/// <summary>
	/// The Game Manager extends XNA Game, it manages the game time (automatic at the moment through XNA).
	/// It also triggers both the update event and the the draw loop, although all actuall rendering
	/// is done in the render manager.
	/// </summary>
	public class GameManager : Game
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.GameManager"/> class.
		/// </summary>
		public GameManager() {}

		/// <summary>
		/// Starts the game at the selected scene.
		/// </summary>
		internal void Start()
		{
			this.Run();
		}

		/// <summary>
		/// Initializes the managers that needs information from XNA,
		/// possibly this does all kinds of XNA initialization as well.
		/// </summary>
		protected override void Initialize()
		{
            Ludum.Scenes.GoTo(Ludum.Scenes.CurrentScene);
			base.Initialize();
		}

		/// <summary>
		/// Performs XNA LoadContent.
		/// </summary>
		protected override void LoadContent()
		{
			base.LoadContent();
		}

		/// <summary>
		/// Returns the XNA ContentManager.
		/// </summary>
		/// <returns>The content manager.</returns>
		internal ContentManager GetContent()
		{
			return this.Content;
		}

		/// <summary>
		/// The update loop.
		/// </summary>
		/// <param name="gameTime">XNA GameTime.</param>
		protected override void Update (GameTime gameTime)
		{
			// Check global mouse and keyboard actions
			Ludum.GlobalInputs.CheckKeyboardStatus();
			Ludum.GlobalInputs.CheckMouseStatus();

			// Update the current scene
            if (Ludum.Scenes.CurrentScene != null)
            {
			    Ludum.Scenes.CurrentScene.Update();
				Ludum.Scenes.CurrentScene.Input.CheckKeyboardStatus();
				Ludum.Scenes.CurrentScene.Input.CheckMouseStatus();
			}
			base.Update (gameTime);
		}

		/// <summary>
		/// The draw loop
		/// </summary>
		/// <param name="gameTime">XNA GameTime.</param>
		protected override void Draw (GameTime gameTime)
		{
			Ludum.RenderManager.Draw ();
			base.Draw(gameTime);
		}
	}
}