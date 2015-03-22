//
// a very old component
//
//using System;
//using LudumEngine;
//
//namespace BelieveInKong
//{
//	public class FollowMouse : Component
//	{
//		private Position _position;
//
//		public sealed override void Initialize() {
//
//			//Get required components
//			_position = Entity.GetComponent<Position> ();
//
//			//Register on events
//			SubscribeToEvent (Ludum.Input.OnMouse(MouseButton.Left, ButtonModifier.Released), Follow);
//			SubscribeToEvent (Ludum.Input.OnMouse(MouseButton.Right, ButtonModifier.Released), Destroy);
//		}
//
//		private void Follow()
//		{
//			_position.X = Ludum.Input.MouseX;
//			_position.Y = Ludum.Input.MouseY;
//		}
//		private void Destroy()
//		{
//			Entity.Delete ();
//		}
//
//	}
//}