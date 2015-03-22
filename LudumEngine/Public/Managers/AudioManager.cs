using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace LudumEngine
{
	/// <summary>
	/// The Audio manager manages playback of all active sound effects and
	/// music components. It also controlls the master volume of the game.
	/// </summary>
	public class AudioManager
	{
		// Internal events for controlling music and sounds
		internal Event OnStopMusic = new Event();
		internal Event OnPlayMusic = new Event();
		internal Event OnPauseMusic = new Event();
		internal Event OnStopSounds = new Event();
		internal Event OnPlaySounds = new Event();
		internal Event OnPauseSounds = new Event();

		/// <summary>
		/// The master volume, affects all sound and music.
		/// </summary>
		/// <value>A value between 0 and 1.</value>
		public float MasterVolume {

			get {
				return SoundEffect.MasterVolume;
			}

			set {
				SoundEffect.MasterVolume = Math.Min (1, Math.Max (0, value));
			}
		}

		/// <summary>
		/// Stops all audio, both sounds and music.
		/// </summary>
		public void StopAll() { OnStopMusic.Trigger(); OnStopSounds.Trigger(); }

		/// <summary>
		/// Starts or resumes the playback of all sounds and all music.
		/// </summary>
		public void PlayAll() { OnPlayMusic.Trigger(); OnPlaySounds.Trigger(); }

		/// <summary>
		/// Pauses everything, both sounds and music.
		/// </summary>
		public void PauseAll() { OnPauseMusic.Trigger(); OnPauseSounds.Trigger(); }

		/// <summary>
		/// Stops all music.
		/// </summary>
		public void StopMusic() { OnStopMusic.Trigger(); }

		/// <summary>
		/// Plays or resumes all music.
		/// </summary>
		public void PlayMusic() { OnPlayMusic.Trigger(); }

		/// <summary>
		/// Pauses all playing music.
		/// </summary>
		public void PauseMusic() { OnPauseMusic.Trigger(); }

		/// <summary>
		/// Stops the playback of all sounds.
		/// </summary>
		public void StopSounds() { OnStopSounds.Trigger(); }

		/// <summary>
		/// Starts or resumes the playback of all sounds.
		/// </summary>
		public void PlaySounds() { OnPlaySounds.Trigger(); }

		/// <summary>
		/// Pauses all playing sounds.
		/// </summary>
		public void PauseSounds() { OnPauseSounds.Trigger(); }
		
		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.AudioManager"/> class.
		/// </summary>
		public AudioManager() {
			MasterVolume = 1;
		}
	}
}