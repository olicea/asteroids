using Artemis;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteroids.Components {
	class Placement : Component {
		private Vector2 coordinates;
		private float rotation;


		public Placement() { }

		public Placement(Vector2 coordinates, float rotation) {
			this.coordinates = coordinates;
			this.rotation = rotation;
		}


		public Vector2 Coordinates {
			get {
				return this.coordinates;
			}
			set {
				this.coordinates = value;
			}
		}

		public float X {
			get {
				return this.coordinates.X;
			}
			set {
				this.coordinates.X = value;
			}
		}

		public float Y {
			get {
				return this.coordinates.Y;
			}
			set {
				this.coordinates.Y = value;
			}
		}

		public void SetLocation(float x, float y) {
			this.coordinates.X = x;
			this.coordinates.Y = y;
		}

		public float Rotation {
			get {
				return this.rotation;
			}
			set {
				this.rotation = value;
			}
		}

		public void AddRotation(float angle) {
			this.rotation = (this.rotation + angle) % 360;
		}

		public float RotationAsRadians {
			get {
				return MathHelper.ToRadians(this.rotation);
			}
		}

		public float DistanceTo(Placement placement) {
			return Artemis.Utils.Distance(placement.X, placement.Y, X, Y);
		}
	}
}
