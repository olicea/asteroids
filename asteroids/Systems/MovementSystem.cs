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
		private ComponentMapper<Placement> placementMapper;
		private ComponentMapper<Velocity> velocityMapper;
		private ComponentMapper<Acceleration> accelerationMapper;

		private GraphicsDevice graphicsDevice;


		public MovementSystem(GraphicsDevice graphicsDevice) : base(typeof(Placement), typeof(Velocity)) {
			this.graphicsDevice = graphicsDevice;
		}


		public override void Initialize() {
			this.placementMapper = new ComponentMapper<Placement>(world);
			this.velocityMapper = new ComponentMapper<Velocity>(world);
			this.accelerationMapper = new ComponentMapper<Acceleration>(world);
		}

		public override void Process(Entity entity) {
			Placement placement = placementMapper.Get(entity);
			Velocity velocity = velocityMapper.Get(entity);

			if (entity.HasComponent<Acceleration>()) {
				Acceleration acceleration = accelerationMapper.Get(entity);

				if (acceleration.Boost > 0.0f) {
					velocity.Direction = velocity.Direction * velocity.Speed + acceleration.Direction * acceleration.Boost;

					Vector2 normalized = Vector2.Normalize(velocity.Direction);
					velocity.Speed = Math.Min(velocity.Direction.Length() / normalized.Length(), 10.0f);
					velocity.Direction = normalized;
				}
			}

			placement.Coordinates += velocity.Direction * velocity.Speed;

			placement.X = this.ApplyRange(placement.X, this.graphicsDevice.Viewport.Width);
			placement.Y = this.ApplyRange(placement.Y, this.graphicsDevice.Viewport.Height);
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
