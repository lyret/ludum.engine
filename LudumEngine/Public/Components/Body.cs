using System;
using Microsoft.Xna.Framework;

namespace LudumEngine
{
	/// <summary>
	/// Body Components, represents that object has a two dimensional physcal body, It consists of
	/// of a position, a size a rotation and a relative body origin coordinate for transformations.
	/// </summary>
	public class Body : Component
	{
		private Vector2 _current = new Vector2(0,0);
		private Vector2 _previous  = new Vector2(0,0);

		/// <summary>
		/// The positional X & Y coordinates as a 2d vector
		/// </summary>
		/// <value>A vector2.</value>
		public Vector2 PositionVector {
			get { return _current; }
			set {
				this._previous = this._current;
				this._current = value;
			}
		}

        /// <summary>
        /// The previous positional X & Y coordinates as a 2d vector
        /// </summary>
        /// <value>A vector2.</value>
        public Vector2 PreviousPositionVector
        {
            get { return new Vector2(X, Y); }
        }

        /// <summary>
		/// The width and height as a 2d vector.
		/// </summary>
		/// <value>A vector2.</value>
		public Vector2 SizeVector {
			get { return new Vector2 (Width, Height); }
			set { this.Width = value.X; this.Height = value.Y; }
		}

        /// <summary>
		/// The deteremining origin x and y coordinates as a 2d vector
		/// </summary>
		/// <value>A vector2.</value>
		public Vector2 OriginVector {
			get { return new Vector2 (OriginX, OriginY); }
			set { this.Width = value.X; this.Height = value.Y; }
		}

		/// <summary>
		/// The body rotation in deegrees.
		/// </summary>
		/// <value>a float value.</value>
		public float Rotation { get; set; }

		/// <summary>
		/// The position coordinate in the X dimension.
		/// </summary>
		/// <value>a float value.</value>
		public float X {
			get { return _current.X; }

			set {
				this._previous.X = X;
				this._current.X = value;
			}
		}

		/// <summary>
		/// The position coordinate in the Y dimension.
		/// </summary>
		/// <value>a float value.</value>
		public float Y {
			get  { return _current.Y; }

			set {
				this._previous.Y = Y;
				this._current.Y = value;
			}
		}

        /// <summary>
		/// The width, size in the X dimension.
		/// </summary>
		/// <value>A float value.</value>
		public float Width { get; set; }

		/// <summary>
		/// The height, size in the Y dimension.
		/// </summary>
		/// <value>A float value.</value>
		public float Height { get; set; }

        /// <summary>
        /// The X origin coordinate of this body.
        /// </summary>
        /// <value>A float value.</value>
        public float OriginX { get; set; }

        /// <summary>
        /// The Y origin coordinate of this body.
        /// </summary>
        /// <value>A float value.</value>
        public float OriginY { get; set; }

		/// <summary>
		/// Set the position of this component
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public void SetPosition(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

        /// <summary>
        /// Set the width and height of this body
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public void SetSize(float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Set the origin coordinates for this body
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public void SetOrigin(float x, float y)
        {
            this.OriginX = x;
            this.OriginY = y;
        }

		/// <summary>
        /// Set the rotation of this 
        /// </summary>
        /// <param name="width">Rotation in deegres.</param>
        /// <param name="height">Height.</param>
        public void SetRotation(float deegres)
        {
            this.Rotation = deegres;
        }

		/// <summary>
		/// Initializes this component.
		/// </summary>
		public override void Initialize() {}
	}
}