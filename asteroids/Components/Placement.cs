using Artemis;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteriods.Components {
	class Placement : Component {
		private Vector3 coordinates;


		public Placement() { }

		public Placement(Vector3 coordinates) {
			this.coordinates = coordinates;
		}


		public Vector3 Coordinates {
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
				return this.coordinates.Z;
			}
			set {
				this.coordinates.Z = value;
			}
		}

		public void AddRotation(float angle) {
			this.coordinates.Z = (this.coordinates.Z + angle) % 360;
		}

		public float RotationAsRadians {
			get {
				return (float)Math.PI * this.coordinates.Z / 180.0f;
			}
		}

		public float DistanceTo(Placement transform) {
			return Artemis.Utils.Distance(transform.X, transform.Y, X, Y);
		}
	}
}
