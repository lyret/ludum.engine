using System;
using Microsoft.Xna.Framework.Audio;

namespace LudumEngine
{
	/// <summary>
	/// The sound component allows for a sound effect to be played at any given time.
	/// </summary>
	public class Sound : Component
	{
		protected SoundEffectInstance _effect;
        protected float _volume = 1;
        protected bool _loaded = false;

		/// <summary>
		/// The volume of this sound.
		/// </summary>
		/// <value>A value between 0 and 1.</value>
		public float Volume
		{
			get {
				if (_loaded)
					return _effect.Volume;
				return _volume;
			}
			set {
				if (_loaded)
					_effect.Volume = Math.Min(1, Math.Max(0, value ));
				else
					_volume = Math.Min(1, Math.Max(0, value ));
			}
		}

		/// <summary>
		/// The file to load the sound from.
		/// </summary>
		/// <value>A filename.</value>
		public string Filename { get; set; }

		/// <summary>
		/// Set the filename and optionaly the volume.
		/// </summary>
		/// <param name="filename">A filename.</param>
		/// <param name="volume">A volume level between 0 and 1.</param>
		public void Set(string filename, float volume = 1)
		{
			this.Filename = filename;
            this._volume = volume;
		}

		/// <summary>
		/// Initializes this component.
		/// </summary>
		public override void Initialize()
		{
			//Register itselfs on the load event of the scene
			SubscribeToLoadEvent(Load);

			//Register itselfs on events in the audio manager
			SubscribeToEvent(Ludum.AudioManager.OnPauseSounds, Pause);
			SubscribeToEvent(Ludum.AudioManager.OnPlaySounds, Play);
			SubscribeToEvent(Ludum.AudioManager.OnStopSounds, Stop);
		}

		/// <summary>
		/// Load the resources demanded by this component.
		/// </summary>
        private void Load()
        {
        	// Mark the sound as loaded
            _loaded = true; 

			//Load a sound effect
			_effect = Ludum.ResourceManager.GetSoundEffect (this.Filename).CreateInstance();

            //Set volume to the effect
			_effect.Volume = _volume;
        }

		/// <summary>
		/// Play this sound.
		/// </summary>
		public void Play()
		{
			if (!_loaded) return;

			if (_effect.State == SoundState.Paused)
				_effect.Resume();

			if (_effect.State == SoundState.Stopped)
				_effect.Play();
		}

		/// <summary>
		/// Pause this sound.
		/// </summary>
		public void Pause()
		{
			if (!_loaded) return;

			_effect.Pause();
		}

		/// <summary>
		/// Stop this sound.
		/// </summary>
		public void Stop()
		{
			if (!_loaded) return;

			_effect.Stop();
		}
	}
}