using asteroids.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteroids.Spatials {
	static class SpatialHelpers {
		public static bool IsReflected(ref Rectangle destination, Vector2 center, Viewport viewport) {
			Rectangle mirror = new Rectangle(destination.X, destination.Y, destination.Width, destination.Height);

			if (mirror.X < center.X)
				mirror.X += viewport.Width;
			else
				if (mirror.X > viewport.Width - center.X)
					mirror.X -= viewport.Width;

			if (mirror.Y < center.Y)
				mirror.Y += viewport.Height;
			else
				if (mirror.Y > viewport.Height - center.Y)
					mirror.Y -= viewport.Height;

			if (mirror.X != destination.X || mirror.Y != destination.Y) {
				destination = mirror;

				return true;
			}

			return false;
		}
	}
}
