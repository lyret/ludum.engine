using System;
using LudumEngine;

namespace BelieveInKong
{
	/// <summary>
	/// Makes a entity moveable using the arrow keys.
	/// </summary>
	public class Moveable : Component
	{
		private Body _body;
		private Sound _sound;

		/// <summary>
		/// The movement speed.
		/// </summary>
		/// <value>The speed value.</value>
		public float Speed { get; set; } = 2;

		/// <summary>
		/// Initializes this component.
		/// </summary>
		public sealed override void Initialize() {

			//Get required components
			_body = RequiredComponent<Body>();
			_sound = RequiredComponent<Sound>();


			//Register on events
			SubscribeToEvent (Scene.Input.OnKeyboard(Key.Up, KeyModifier.Held), MoveUp);
			SubscribeToEvent (Scene.Input.OnKeyboard(Key.Right, KeyModifier.Held), MoveRight);
			SubscribeToEvent (Scene.Input.OnKeyboard(Key.Down, KeyModifier.Held), MoveDown);
			SubscribeToEvent (Scene.Input.OnKeyboard(Key.Left, KeyModifier.Held), MoveLeft);
		}

		// Move functions

		private void MoveUp()
		{
			_body.Y -= Speed;
		}

		private void MoveDown()
		{
			_body.Y += Speed;
		}

		private void MoveLeft()
		{
			_body.X -= Speed;
		}

		private void MoveRight()
		{
			_body.X += Speed;
		}
	}
}