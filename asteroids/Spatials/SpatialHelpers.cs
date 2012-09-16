using asteriods.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteriods.Spatials {
	static class SpatialHelpers {
		public static bool IsGoingBeyond(ref Rectangle destination, Viewport viewport) {
			if (destination.X + destination.Width <= viewport.Width
				&& destination.Y + destination.Height <= viewport.Height) {
				return false;
			}

			if (destination.X + destination.Width - viewport.Width > 0) destination.X -= viewport.Width;
			if (destination.Y + destination.Height - viewport.Height > 0) destination.Y -= viewport.Height;

			return true;
		}
	}
}
