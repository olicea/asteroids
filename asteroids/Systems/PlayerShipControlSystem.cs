using Artemis;
using asteroids.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteroids.Systems {
	class PlayerShipControlSystem : TagSystem {
		private readonly float speed = 0.3f;
		private readonly float rotation = 0.3f;

		private ComponentMapper<Placement> placementMapper;
		private ComponentMapper<Acceleration> accelerationMapper;
		private KeyboardState oldState;


		public PlayerShipControlSystem() : base("PLAYER") { }


		public override void Initialize() {
			this.placementMapper = new ComponentMapper<Placement>(world);
			this.accelerationMapper = new ComponentMapper<Acceleration>(world);
			this.oldState = Keyboard.GetState();
		}

		public override void Process(Entity entity) {
			Placement placement = placementMapper.Get(entity);
			Acceleration acceleration = accelerationMapper.Get(entity);

			KeyboardState state = Keyboard.GetState();

			if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W)) {
				acceleration.Direction = Vector2.Normalize(
					new Vector2((float)Math.Cos(placement.RotationAsRadians), (float)Math.Sin(placement.RotationAsRadians))
				);
				
				acceleration.Boost = this.speed;
			}
			else {
				acceleration.Boost = 0.0f;
			}

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
