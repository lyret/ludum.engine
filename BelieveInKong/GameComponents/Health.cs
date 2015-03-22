//
// a very old component
//
//using System;
//using LudumEngine;
//
//namespace BelieveInKong
//{
//	public class Health : Component
//	{
//		public int StartingValue { get; set; }
//
//
//		public void Set(int startingValue = 100) {
//			this.StartingValue = startingValue;
//		}
//
//		public sealed override void Initialize() {
//			OnDeath = new Event ();
//			Value = StartingValue;
//		}
//
//		public bool IsDead { get; private set;} = false;
//
//		public int Value {
//
//			get {
//				return _value;
//			}
//
//			set {
//				_value = value;
//
//				if (_value <= 0) {
//
//					//Trigger death if the health value passes below 0
//					if (!IsDead)
//						OnDeath.Trigger ();
//
//					IsDead = true;
//				} else {
//					IsDead = false;
//				}
//			}
//		}
//
//		public Event OnDeath;
//
//		private int _value;
//	}
//}
//
