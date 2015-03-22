using System;
using Microsoft.Xna.Framework.Audio;

namespace LudumEngine
{
	/// <summary>
	/// The Music component allows for a sound effect to be played at any given time.
	/// In contrast to sound components they can be looped and controlled more precisely
	/// from the audio manager.
	/// </summary>
	public class Music : Sound
	{
		protected bool _looping = false;

		/// <summary>
		/// Controlls whenever this music should be continiously looped 
		/// </summary>
		/// <value><c>true</c> if it should loop; otherwise, <c>false</c>.</value>
		public bool Looping
		{
			get {
				if (_loaded)
					return _effect.IsLooped;
				else
					return _looping;
			}

			set {
				if (_loaded)
					_effect.IsLooped = value;
				else
					_looping = value;
			}
		}

		/// <summary>
		/// Initializes this component.
		/// </summary>
		public override void Initialize()
		{
			//Register itselfs on the load event of the scene
			SubscribeToLoadEvent(Load);

			//Register itselfs on events in the audio manager
			SubscribeToEvent(Ludum.AudioManager.OnPauseMusic, Pause);
			SubscribeToEvent(Ludum.AudioManager.OnPlayMusic, Play);
			SubscribeToEvent(Ludum.AudioManager.OnStopMusic, Stop);
		}

		/// <summary>
		/// Load the resources demanded by this component.
		/// </summary>
        private void Load()
        {
        	// Mark the music component as loaded
            _loaded = true; 

			// Load a sound effect
			_effect = Ludum.ResourceManager.GetSoundEffect (this.Filename).CreateInstance();

			// Set it to loop or not.
			_effect.IsLooped = Looping;

			// Set volume to the effect
			_effect.Volume = _volume;
        }
	}
}