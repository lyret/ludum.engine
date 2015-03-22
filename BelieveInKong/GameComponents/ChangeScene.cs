using System;
using LudumEngine;

namespace BelieveInKong
{
	/// <summary>
	/// Uses the keyboard to change between scenes.
	/// </summary>
	public class ChangeScene : Component
	{
		string targetScene;

		public void SetScene(string scene)
		{
			targetScene = scene;
		}

		/// <summary>
		/// Initializes this component.
		/// </summary>
		public sealed override void Initialize()
		{
			//Register on events
			SubscribeToEvent (Scene.Input.OnKeyboard(Key.Enter, KeyModifier.Released), Switch);
		}

		// Keyboard functions

		private void Switch()
		{
			Ludum.Scenes.GoTo(Ludum.Scenes.GetScene(targetScene));
		}
	}
}