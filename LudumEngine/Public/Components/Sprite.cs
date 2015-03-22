using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LudumEngine
{
	/// <summary>
	/// The Sprite Component is a drawn image that represents the entity.
	/// </summary>
	public class Sprite : Component
	{
		private Texture2D _texture;
		private Body _position;
        private bool _loaded = false;

		/// <summary>
		/// The file to load the sprite from.
		/// </summary>
		/// <value>A filename.</value>
		public string Filename { get; set; }

		/// <summary>
		/// The depth the sprite is drawn at,
		/// a lower is drawn closer to the camera.
		/// </summary>
		/// <value>A number between 0 and 1</value>
		public float Depth { get; set; }

		/// <summary>
		/// Set the specified filename and depth.
		/// </summary>
		/// <param name="filename">Filename.</param>
		/// <param name="depth">Depth.</param>
		public void Set(string filename, float depth = 0)
		{
			this.Filename = filename;
			this.Depth = depth;
		}

		/// <summary>
		/// Initializes this component.
		/// </summary>
		public override void Initialize() {

			// Get the position of the sprite
			_position = RequiredComponent<Body>();

			// Subscribe to events
            SubscribeToLoadEvent(Load);
			SubscribeToDrawEvent(Draw);
		}

        public void SetTexture(string filename)
        {
            _texture = Ludum.ResourceManager.GetTexture2D(filename); 
        }

		/// <summary>
		/// Load the resources demanded by this component.
		/// </summary>
        private void Load()
        {
        	// Mark the sprite as loaded
            _loaded = true; 

            // Load a texture
            _texture = Ludum.ResourceManager.GetTexture2D(this.Filename); 
        }

		/// <summary>
		/// Draws the sprite when called.
		/// </summary>
		private void Draw()
		{
            if (!_loaded) return;

			Ludum.RenderManager.SpriteBatch.Draw (
				_texture,
				new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height ),
				null,
				Microsoft.Xna.Framework.Color.White,
				0f,
				new Vector2(0, 0),
				SpriteEffects.None,
				this.Depth
			);
		}
	}
}