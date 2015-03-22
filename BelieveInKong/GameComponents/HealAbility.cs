//
// a very old component
//
//using System;
//using LudumEngine;
//
//namespace BelieveInKong
//{
//	public class HealAbility : Component
//	{
//		public int HealingFactor { get; set; } = 5;
//
//		private Health _health;
//
//		public sealed override void Initialize()
//		{
//			//Interacting components
//
//			_health = Entity.GetComponent<Health> ();
//
//			//Events
//			SubscribeToEvent (Ludum.RenderManager.OnDraw, IncreaseHealth); //SHOULD BE THE UPDTE LOOP
//
//		}
//
//		public void IncreaseHealth() {
//			_health.Value += 5;
//		}
//	}
//
//}
//
