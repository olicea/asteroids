using Artemis;
using asteriods.Components;
using asteriods.Spatials;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteriods.Systems {
	class RenderSystem : EntityProcessingSystem {
		private GraphicsDevice graphicsDevice;
		private SpriteBatch spriteBatch;

		private ComponentMapper<Transform> transformMapper;
		private ComponentMapper<SpatialForm> spatialFormMapper;


		public RenderSystem(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
			: base(typeof(Transform), typeof(SpatialForm)) {
				this.graphicsDevice = graphicsDevice;
				this.spriteBatch = spriteBatch;
		}


		public override void Initialize() {
			this.transformMapper = new ComponentMapper<Transform>(world);
			this.spatialFormMapper = new ComponentMapper<SpatialForm>(world);
		}

		public override void Process(Entity entity) {
			Transform transform = this.transformMapper.Get(entity);

			if (transform.X < 0
				&& transform.X >= this.graphicsDevice.Viewport.Width
				&& transform.Y < 0
				&& transform.Y >= this.graphicsDevice.Viewport.Height) {
					return;
			}

			switch (this.spatialFormMapper.Get(entity).Form) {
				case SpatialForms.Player:
					PlayerForm.Render(this.spriteBatch, transform);
					break;
			}
		}
	}
}
