using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LudumEngine
{

	/// <summary>
	/// The Settings Manager handles the initial setup of the engine, it could
	/// be extended to load settings from a file. Its properties should be set before
	/// the game engine is initialized.
	/// It is the single code node for editing settings for the game.
	/// </summary>
	public class SettingsManager
	{
		#region errors

		/// <summary>
		/// Controlls if reported errors without actual exceptions should be ignored or not
		/// </summary>
		public Boolean IgnoreErrors { get { return Ludum.Error.Ignore; } set { Ludum.Error.Ignore = value; } }

		#endregion

		#region resources

		/// <summary>
		/// The directory to load assets from
		/// </summary>
		/// <value>A directory.</value>
		public String AssetsDirectory { get { return Ludum.ResourceManager.AssetsDirectory; } set { Ludum.ResourceManager.AssetsDirectory = value; } }
	
		#endregion

		#region rendering

		/// <summary>
		///  Indicates whether this instance is fullscreen or not.
		/// </summary>
		/// <value><c>true</c> if in fullscreen mode; otherwise, <c>false</c>.</value>
		public Boolean Fullscreen { get { return Ludum.RenderManager.IsFullscreen; } set { Ludum.RenderManager.IsFullscreen = value; } }

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.SettingsManager"/> class.
		/// </summary>
		public SettingsManager() {}
	}
}