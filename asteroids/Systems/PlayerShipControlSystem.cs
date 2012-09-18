using Artemis;
using asteriods.Components;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteriods.Systems {
	class PlayerShipControlSystem : TagSystem {
		private readonly float speed = 0.001f;
		private readonly float rotation = 0.1f;

		private ComponentMapper<Placement> placementMapper;
		private ComponentMapper<Velocity> velocityMapper;
		private KeyboardState oldState;


		public PlayerShipControlSystem() : base("PLAYER") { }


		public override void Initialize() {
			this.placementMapper = new ComponentMapper<Placement>(world);
			this.velocityMapper = new ComponentMapper<Velocity>(world);
			this.oldState = Keyboard.GetState();
		}

		public override void Process(Entity entity) {
			Velocity velocity = velocityMapper.Get(entity);

			KeyboardState state = Keyboard.GetState();

			if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W)) {
				velocity.Speed += world.Delta * this.speed;
			}
			else if (this.oldState.IsKeyDown(Keys.Up) || this.oldState.IsKeyDown(Keys.W)) {
				velocity.Speed -= world.Delta * this.speed;
			}

			Placement placement = placementMapper.Get(entity);

			if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A)) {
				placement.AddRotation(world.Delta * -this.rotation);
			}
			if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D)) {
				placement.AddRotation(world.Delta * this.rotation);
			}

			this.oldState = state;
		}
	}
}
