using Artemis;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteroids.Components {
	class Acceleration : Component {
		private Vector2 direction;
		private float boost;


		public Acceleration() { }


		public Vector2 Direction {
			get {
				return this.direction;
			}
			set {
				this.direction = value;
			}
		}

		public float Boost {
			get {
				return this.boost;
			}
			set {
				this.boost = value;
			}
		}
	}
}
