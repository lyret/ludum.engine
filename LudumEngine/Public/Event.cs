using System;
using System.Collections.Generic;

namespace LudumEngine
{
	/// <summary>
	/// Delegate that Defines the format of recived methods,
	/// the methods used when subscribing to events 
	/// must match the format of this delegate.
	/// * It must have zero arguments.
	/// * It must return void.
	/// </summary>
	public delegate void Delegate();

	/// <summary>
	/// The Event class allows components and managers to observers happenings
	/// between each other and execute specific methods when events are triggered.
	/// </summary>
	public sealed class Event
	{
		private int _nextDelegetaionId;
		private Dictionary<int, Delegate> _delegations;

		/// <summary>
		/// The number of subscribers to this event.
		/// </summary>
		/// <value>Number of subscribers.</value>
		internal int Subscribers { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.Event"/> class.
		/// </summary>
		public Event() {
			Subscribers = 0;
			_nextDelegetaionId = 0;

			_delegations = new Dictionary<int, Delegate>();
		}

		/// <summary>
		/// Sends a method to be executed when this event is triggered.
		/// </summary>
		/// <param name="delegationMethod">The method to execute.</param>
		/// <returns>A integer token to keep track of this subscription</returns>
		public int Subscribe(Delegate delegationMethod)
		{
			Subscribers++;

			int delegationId = _nextDelegetaionId++;

			_delegations [delegationId] = delegationMethod;

			return delegationId;
		}

		/// <summary>
		/// Unsubscribe a method from this event using the integer token
		/// created when subscribing.
		/// </summary>
		/// <param name="delegationId">the integer token.</param>
		public void Unsubscribe(int delegationId)
		{
			Subscribers--;

			_delegations.Remove(delegationId);
		}

		/// <summary>
		/// Trigger this Event, all subscribed methods will be executed.
		/// </summary>
		public void Trigger()
		{
			var delegations = new List<Delegate> (_delegations.Values);

			for (int i = 0; i < delegations.Count; i++) {
				
				try
				{
					delegations[i]();
				}
				catch (Exception)
				{
					//Ignore broken delegations, i.e. when subscribers
					//no longer exists.
					return;
				}
			}
		}
	}
}