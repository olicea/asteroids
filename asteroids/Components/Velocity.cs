using Artemis;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteriods.Components {
	class Velocity : Component {
		private Vector2 direction;
		private float speed;


		public Velocity() { }

		public Velocity(float velocity, float angle) {
			this.direction = Vector2.Normalize(new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)));
			this.speed = velocity;
		}


		public Vector2 Direction {
			get {
				return this.direction;
			}
			set {
				this.direction = value;
			}
		}

		public float Speed {
			get {
				return this.speed;
			}
			set {
				this.speed = value;
			}
		}
	}
}
