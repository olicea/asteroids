using asteroids.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteroids.Spatials {
	static class AsteroidForm {
		private static Texture2D texture;
		private static Vector2 center;

		public static void LoadContent(GraphicsDevice graphicsDevice) {
			texture = Texture2D.FromStream(graphicsDevice, TitleContainer.OpenStream("Content/asteroid.png"));

			center = new Vector2(texture.Width / 2, texture.Height / 2);
		}

		public static void Render(SpriteBatch spriteBatch, Placement placement) {
			Rectangle destination = new Rectangle(
				(int)(placement.X - center.X),
				(int)(placement.Y - center.Y),
				texture.Width,
				texture.Height
			);

			spriteBatch.Draw(texture,
				destination,
				null,
				Color.White,
				placement.RotationAsRadians,
				center,
				SpriteEffects.None,
				0
			);

			if (SpatialHelpers.IsReflected(ref destination, center, spriteBatch.GraphicsDevice.Viewport)) {
				spriteBatch.Draw(texture,
					destination,
					null,
					Color.White,
					placement.RotationAsRadians,
					center,
					SpriteEffects.None,
					0
				);
			}
		}
	}
}
