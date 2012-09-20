using asteriods.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteriods.Spatials {
	static class PlayerForm {
		private static Texture2D texture;

		public static void LoadContent(GraphicsDevice graphicsDevice) {
			texture = Texture2D.FromStream(graphicsDevice, TitleContainer.OpenStream("Content/player.png"));
		}

		public static void Render(SpriteBatch spriteBatch, Placement placement) {
			Rectangle destination = new Rectangle(
				(int)(placement.X - texture.Width / 2),
				(int)(placement.Y - texture.Height / 2),
				texture.Width,
				texture.Height
			);

			spriteBatch.Draw(texture,
				destination,
				null,
				Color.White,
				placement.RotationAsRadians,
				new Vector2(texture.Width / 2, texture.Height / 2),
				SpriteEffects.None,
				0
			);


			if (SpatialHelpers.IsGoingBeyond(ref destination, spriteBatch.GraphicsDevice.Viewport)) {
				spriteBatch.Draw(texture,
					destination,
					null,
					Color.White,
					placement.RotationAsRadians,
					new Vector2(texture.Width / 2, texture.Height / 2),
					SpriteEffects.None,
					0
				);
			}
		}
	}
}
