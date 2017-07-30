using System;
using System.Collections.Generic;

namespace SenRestaurant.Core
{
	public class PhoGroup
	{
		public PhoGroup ()
		{
		}

		public int PhoGroupId {
			get;
			set;
		}

		public string Title {
			get;
			set;
		}

		public string ImagePath {
			get;
			set;
		}

		public List<Pho> Phos {
			get;
			set;
		}
	}
}

