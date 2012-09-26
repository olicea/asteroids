using Artemis;
using asteroids.Components;
using asteroids.Spatials;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteroids.Systems {
	class RenderSystem : EntityProcessingSystem {
		private GraphicsDevice graphicsDevice;
		private SpriteBatch spriteBatch;

		private ComponentMapper<Placement> placementMapper;
		private ComponentMapper<SpatialForm> spatialFormMapper;


		public RenderSystem(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
			: base(typeof(Placement), typeof(SpatialForm)) {
				this.graphicsDevice = graphicsDevice;
				this.spriteBatch = spriteBatch;
		}


		public override void Initialize() {
			this.placementMapper = new ComponentMapper<Placement>(world);
			this.spatialFormMapper = new ComponentMapper<SpatialForm>(world);
		}

		public override void Process(Entity entity) {
			Placement placement = this.placementMapper.Get(entity);

			switch (this.spatialFormMapper.Get(entity).Form) {
				case SpatialForms.Player:
					PlayerForm.Render(this.spriteBatch, placement);
					break;
			}
		}
	}
}
