using Artemis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteriods.Components {
	class Velocity : Component {
		private float velocity;
		private float angle;


		public Velocity() { }

		public Velocity(float velocity, float angle) {
			this.velocity = velocity;
			this.angle = angle;
		}


		public float Speed {
			get {
				return this.velocity;
			}
			set {
				velocity = value;
			}
		}

		public float Angle {
			get {
				return this.angle;
			}
			set {
				angle = value;
			}
		}

		public void AddAngle(float angle) {
			this.angle = (this.angle + angle) % 360;
		}

		public float AngleAsRadians {
			get {
				return (float)Math.PI * angle / 180.0f;
			}
		}
	}
}
