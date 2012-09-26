using Artemis;
using asteroids.Spatials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asteroids.Components {
	class SpatialForm : Component {
		private SpatialForms form;


		public SpatialForm() { }

		public SpatialForm(SpatialForms form) {
			this.form = form;
		}


		public SpatialForms Form {
			get {
				return this.form;
			}
			set {
				this.form = value;
			}
		}
	}
}
