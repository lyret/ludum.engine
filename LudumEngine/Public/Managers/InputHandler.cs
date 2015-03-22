using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LudumEngine
{
	/// <summary>
	/// Generic keys that can be listned to.
	/// </summary>
	public enum Key {
		Up = Keys.Up,
		Down = Keys.Down,
		Left = Keys.Left,
		Right = Keys.Right,
		Enter = Keys.Enter
	}

	/// <summary>
	/// Possible events for each key.
	/// </summary>
	public enum KeyModifier {
		Pressed,
		Released,
		Held,
	}

	/// <summary>
	/// Possible mouse buttons that can be listned to.
	/// </summary>
	public enum MouseButton {
		Left,
		Right,
		Middle
	}

	/// <summary>
	/// Possible events on each mouse button.
	/// </summary>
	public enum ButtonModifier {
		Pressed,
		Released,
		Held,
	}

	/// <summary>
	/// The Input handler listens for keyboard and mouse actions and triggers events
	/// when they occure, this way components can just subscribe to the correct event.
	/// The Mouse position can also be accessed from this class.
	/// Each scene holds its own, seperate input manager.
	/// </summary>
	public class InputHandler
	{
		private Dictionary<Key, Dictionary<KeyModifier,Event>> _keyboardEvents;
		private Dictionary<MouseButton, Dictionary<ButtonModifier,Event>> _mouseEvents;

		private KeyboardState _currentKeyboardState;
		private KeyboardState _previousKeyboardState;
		private MouseState _currentMouseState;
		private MouseState _previousMouseState;

		/// <summary>
		/// Gets the x position of the mouse.
		/// </summary>
		/// <value>an x value.</value>
		public int MouseX { get; private set; }

		/// <summary>
		/// Gets the y position of the mouse.
		/// </summary>
		/// <value>an y value.</value>
		public int MouseY { get; private set; }
		
		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.InputHandler"/> class.
		/// </summary>
		internal InputHandler()
		{
			ClearContent();

			MouseX = 0;
			MouseY = 0;
		}

		/// <summary>
		/// Clears all registred events.
		/// </summary>
		internal void ClearContent()
		{
			// Create the dictionary for keyboard events and fill it with each possibility.
			_keyboardEvents = new Dictionary<Key, Dictionary<KeyModifier, Event>> ();
			foreach(Key key in Enum.GetValues(typeof(Keys)))
			{
				_keyboardEvents[key] = new Dictionary<KeyModifier, Event>();

				foreach (KeyModifier modifier in Enum.GetValues(typeof(KeyModifier)))
				{
					_keyboardEvents [key] [modifier] = new Event ();
				}
			}

			// Create the dictionary for mouse events and fill it with each possibility.
			_mouseEvents = new Dictionary<MouseButton, Dictionary<ButtonModifier, Event>> ();
			foreach(MouseButton button in Enum.GetValues(typeof(MouseButton)))
			{
				_mouseEvents[button] = new Dictionary<ButtonModifier, Event>();

				foreach (ButtonModifier modifier in Enum.GetValues(typeof(ButtonModifier)))
				{
					_mouseEvents [button] [modifier] = new Event ();
				}
			}
		}

		/// <summary>
		/// Returns the event that exists for a key and a modifier
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="modifier">Modifier.</param>
		public Event OnKeyboard(Key key, KeyModifier modifier)
		{
			return _keyboardEvents [key] [modifier];
		}

		/// <summary>
		/// Returns the event that exists for a mouse button and a modifier
		/// </summary>
		/// <param name="button">Button.</param>
		/// <param name="modifier">Modifier.</param>
		public Event OnMouse(MouseButton button, ButtonModifier modifier)
		{
			return _mouseEvents [button] [modifier];
		}

		/// <summary>
		/// Triggers event for keys on the keyboard.
		/// </summary>
		internal void CheckKeyboardStatus()
		{
			_currentKeyboardState = Keyboard.GetState();

			var keys = Enum.GetValues (typeof(Keys));

			// Check each key
			foreach(Key key in keys)
			{
				// If the key is released
				if ((_currentKeyboardState.IsKeyUp((Keys) key)) && (_previousKeyboardState.IsKeyDown((Keys) key))) {
					_keyboardEvents [key] [KeyModifier.Released].Trigger ();
				}
				// If the key is pressed
				if ((_currentKeyboardState.IsKeyDown((Keys) key)) && (_previousKeyboardState.IsKeyUp((Keys) key))) {
					_keyboardEvents [key] [KeyModifier.Pressed].Trigger ();
				}

				// If the key is held
				if (_currentKeyboardState.IsKeyDown((Keys) key)) {
					_keyboardEvents [key] [KeyModifier.Held].Trigger ();
				}
			}

			_previousKeyboardState = Keyboard.GetState();
		}

		/// <summary>
		/// Triggers event for mouse buttons.
		/// </summary>
		internal void CheckMouseStatus()
		{
			_currentMouseState = Mouse.GetState ();

			// Update the mouse position
			MouseX = _currentMouseState.X;
			MouseY = _currentMouseState.Y;

			// Left button is released
			if ((_currentMouseState.LeftButton == ButtonState.Released) && (_previousMouseState.LeftButton == ButtonState.Pressed)) {
				_mouseEvents [MouseButton.Left] [ButtonModifier.Released].Trigger ();
			}

			// Left button is pressed
			if ((_currentMouseState.LeftButton == ButtonState.Pressed) && (_previousMouseState.LeftButton == ButtonState.Released)) {
				_mouseEvents [MouseButton.Left] [ButtonModifier.Pressed].Trigger ();
			}

			// Left button is held
			if ((_currentMouseState.LeftButton == ButtonState.Pressed)) {
				_mouseEvents [MouseButton.Left] [ButtonModifier.Held].Trigger ();
			}

			// Middle button is released
			if ((_currentMouseState.MiddleButton == ButtonState.Released) && (_previousMouseState.MiddleButton == ButtonState.Pressed)) {
				_mouseEvents [MouseButton.Middle] [ButtonModifier.Released].Trigger ();
			}

			// Middle button is pressed
			if ((_currentMouseState.MiddleButton == ButtonState.Pressed) && (_previousMouseState.MiddleButton == ButtonState.Released)) {
				_mouseEvents [MouseButton.Middle] [ButtonModifier.Pressed].Trigger ();
			}

			// Middle button is held
			if ((_currentMouseState.MiddleButton == ButtonState.Pressed)) {
				_mouseEvents [MouseButton.Middle] [ButtonModifier.Held].Trigger ();
			}

			// Right button is released
			if ((_currentMouseState.RightButton == ButtonState.Released) && (_previousMouseState.RightButton == ButtonState.Pressed)) {
				_mouseEvents [MouseButton.Right] [ButtonModifier.Released].Trigger ();
			}

			// Right button is pressed
			if ((_currentMouseState.RightButton == ButtonState.Pressed) && (_previousMouseState.RightButton == ButtonState.Released)) {
				_mouseEvents [MouseButton.Right] [ButtonModifier.Pressed].Trigger ();
			}

			// Right button is held
			if ((_currentMouseState.RightButton == ButtonState.Pressed)) {
				_mouseEvents [MouseButton.Right] [ButtonModifier.Held].Trigger ();
			}

			_previousMouseState = Mouse.GetState();
		}
	}
}

