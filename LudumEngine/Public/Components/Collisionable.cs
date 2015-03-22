using System;
using System.Collections.Generic;

namespace LudumEngine
{
	//TODO: this collision class
	public class Collisionable : Component
	{
		private Body _body;
		private List<Entity> _watchedEntities;

		/// <summary>
		/// Event triggered when this rectangle intersects another.
		/// </summary>
		public Event OnCollision;

		/// <summary>
		/// Gets the Entity this rectangle is colliding with
		/// when the OnCollision event triggers.
		/// </summary>
		/// <value>The entity in collision.</value>
		public Entity CollidingEntity { get; private set; }

		// Positional properties of the rectangle

		internal float Left
		{
			get { return _body.X; }
		}

		internal float Top
		{
			get { return _body.Y; }
		}

		internal float Right
		{
			get { return Left + _body.Width; }
		}

		internal float Bottom
		{
            get { return Top + _body.Height; }
		}

		/// <summary>
		/// Initializes this component.
		/// </summary>
		public override void Initialize()
		{
			// Create the event
			OnCollision = new Event();

			// Initialize the list of watched rectangles
			_watchedEntities = new List<Entity>();

			// Get the required components
			_body = RequiredComponent<Body>();

			// Listen for events
			SubscribeToUpdateEvent(Update);
		}

		/// <summary>
		/// Updates this instance, checks all watched entities for collision
		/// </summary>
		private void Update()
		{
			foreach (Entity entity in _watchedEntities)
			{
				//Check for intersection
				this.Intersects(entity);
			}
		}

		/// <summary>
		/// Adds an entity to be automaticly checked in the update loop.
		/// </summary>
		/// <param name="entity">Entity.</param>
		public void WatchFor(Entity entity)
		{
			if (entity.HasComponent<Collisionable>())
				_watchedEntities.Add(entity);
		}

		/// <summary>
		/// Checks if this rectangle intersects with another.
		/// </summary>
		/// <param name="rectangle">A collision rectangle.</param>
		/// <returns>True if colliding, otherwise false.</returns>
		private bool Intersects(Collisionable rectangle)
		{
			if (( this.Right >= rectangle.Left && this.Left <= rectangle.Right) && ( this.Bottom >= rectangle.Top && this.Top <= rectangle.Bottom))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Checks if this rectangle intersects with another entity.
		/// returns False if the entity does not have a collision rectangle component.
		/// </summary>
		/// <param name="entity">An Entity to check against.</param>
		/// <returns>True on collision, false otherwise.</returns>
		public bool Intersects(Entity entity)
		{
			if (entity.HasComponent<Collisionable>())
			{
				if (this.Intersects(entity.GetComponent<Collisionable>()))
				{
					// Trigger the event with the correct colliding entity set.
					CollidingEntity = entity;
					OnCollision.Trigger();
					CollidingEntity = null;

					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Checks if this collision rectangle collides with the
		/// collision rectangle of a list of other entities.
		/// If the list contains this rectangles entitity it is ignored.
		/// </summary>
		/// <param name="listOfEntities">A list of entities to check against.</param>
		/// <returns>A list of entities that are colliding, or an empty list.</returns>
		public List<Entity> Intersects(List<Entity> listOfEntities)
		{
			List<Entity> collidingEntities = new List<Entity>();

			foreach (Entity entity in listOfEntities)
			{
				
				// Do not check against itself
				if (this.Entity == entity) continue;

				// Check the entity
				if (this.Intersects(entity)) {
					collidingEntities.Add(entity);
				}
			}

			return collidingEntities;
		}
	}
}