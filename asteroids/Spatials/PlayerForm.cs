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

		public static void Render(SpriteBatch spriteBatch, Transform transform) {
			Rectangle destination = new Rectangle((int)transform.X, (int)transform.Y, texture.Width, texture.Height);

			spriteBatch.Draw(texture, destination, Color.White);


			if (SpatialHelpers.IsGoingBeyond(ref destination, spriteBatch.GraphicsDevice.Viewport)) {
				spriteBatch.Draw(texture, destination, Color.White);
			}
		}
	}
}
