using Artemis;
using asteriods.Components;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteriods.Systems {
	class MovementSystem : EntityProcessingSystem {
		private ComponentMapper<Transform> transformMapper;
		private ComponentMapper<Velocity> velocityMapper;

		private GraphicsDevice graphicsDevice;


		public MovementSystem(GraphicsDevice graphicsDevice) : base(typeof(Transform), typeof(Velocity)) {
			this.graphicsDevice = graphicsDevice;
		}


		public override void Initialize() {
			this.transformMapper = new ComponentMapper<Transform>(world);
			this.velocityMapper = new ComponentMapper<Velocity>(world);
		}

		public override void Process(Entity entity) {
			Transform transform = transformMapper.Get(entity);
			Velocity velocity = velocityMapper.Get(entity);

			transform.X = this.ApplyRange(
				transform.X + TrigLUT.Cos(velocity.AngleAsRadians) * velocity.Speed * world.Delta, 
				this.graphicsDevice.Viewport.Width);

			transform.Y = this.ApplyRange(
				transform.Y + TrigLUT.Sin(velocity.AngleAsRadians) * velocity.Speed * world.Delta,
				this.graphicsDevice.Viewport.Height);
		}

		private float ApplyRange(float value, float range) {
			if (value < 0) {
				return value + range;
			}

			if (value > range) {
				return value - range;
			}

			return value;
		}
	}
}
