using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace LudumEngine
{
	/// <summary>
	/// The Resource Manager loads and unloads resources from files, its purpose is making sure
	/// the same resource is not loaded several times during the game, as its a demanding procedure, and
	/// also making sure that the same resource is not loaded multiple times and stored in indvidual components.
	/// </summary>
	public class ResourceManager
	{
		private bool _initialized = false;
		private Dictionary<string, Texture2D> _loadedTexture2D;
		private Dictionary<string, SoundEffect> _loadedSoundEffects;

		// XNA Properties
		internal ContentManager ContentManager { get; set; }

		#region settings

		internal String AssetsDirectory { get; set; }

		#endregion settings

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.ResourceManager"/> class.
		/// </summary>
		internal ResourceManager()
		{
			ClearContent();
		}

		/// <summary>
		/// Sets the correct XNA Content pipline, this is done when the game is initialized by the
		/// Game Manager.
		///<param name="content">The content manager for the game</param>
		/// </summary>
		internal void Initialize()
		{
			this.ContentManager = Ludum.Game.GetContent();
			this.ContentManager.RootDirectory = AssetsDirectory;
		}

		/// <summary>
		/// Clears all loaded content from memory.
		/// </summary>
		internal void ClearContent()
		{
			_loadedTexture2D = new Dictionary<string, Texture2D>();
			_loadedSoundEffects = new Dictionary<string, SoundEffect>();
		}

		/// <summary>
		/// Loads a texture from a filename and returns the resulting texture reference.
		/// If its already loaded it is simply returned.
		/// </summary>
		/// <returns>A 2D Texture.</returns>
		/// <param name="filename">The filename, without extension, located in the Assets Directory</param>
		public Texture2D GetTexture2D(string filename)
		{
			if (!_initialized) Initialize();

			try
			{
				if (_loadedTexture2D.ContainsKey(filename)) {
					return _loadedTexture2D[filename];
				}

				Texture2D texture = ContentManager.Load<Texture2D>(filename);
				_loadedTexture2D[filename] = texture;
		
				return texture;
			}
			catch (Exception e)
			{
				throw Ludum.Error.General("Failed to load the texture named '" + filename +"'.", e);
			}
		}

		/// <summary>
		/// Loads a sound effect (if its not already loaded) from a filename and returns it, it is also stored for later
		/// retrival through the same function.
		/// </summary>
		/// <returns>A Sound Effect.</returns>
		/// <param name="filename">The filename, without extension, located in the Assets Directory</param>
		public SoundEffect GetSoundEffect(string filename)
		{
			if (!_initialized) Initialize();

			try
			{
				if (_loadedSoundEffects.ContainsKey(filename)) {
					return _loadedSoundEffects[filename];
				}

				SoundEffect effect = ContentManager.Load<SoundEffect>(filename);
				_loadedSoundEffects.Add(filename, effect);

				return effect;
			}
			catch (Exception e)
			{
				throw Ludum.Error.General("Failed to load the sound named '" + filename +"'.", e);
			}
		}
	}
}