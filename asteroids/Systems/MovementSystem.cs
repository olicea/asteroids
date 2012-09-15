using Artemis;
using asteriods.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteriods.Systems {
	class MovementSystem : EntityProcessingSystem {
		private ComponentMapper<Transform> transformMapper;
		private ComponentMapper<Velocity> velocityMapper;


		public MovementSystem() : base(typeof(Transform), typeof(Velocity)) { }


		public override void Initialize() {
			this.transformMapper = new ComponentMapper<Transform>(world);
			this.velocityMapper = new ComponentMapper<Velocity>(world);
		}

		public override void Process(Entity entity) {
			Transform transform = transformMapper.Get(entity);
			Velocity velocity = velocityMapper.Get(entity);

			transform.X += (TrigLUT.Cos(velocity.AngleAsRadians) * velocity.Speed * world.Delta);
			transform.Y += (TrigLUT.Sin(velocity.AngleAsRadians) * velocity.Speed * world.Delta);
		}
	}
}
