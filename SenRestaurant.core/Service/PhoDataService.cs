using System;
using System.Collections.Generic;
using System.Linq;

namespace SenRestaurant.Core
{
	public class PhoDataService
	{
		//private static PhoWebRepository phoRepository = new PhoWebRepository();
		private static PhoRepository phoRepository = new PhoRepository();

		public PhoDataService ()
		{
		}

		public List<Pho> GetAllPhos()
		{
			return phoRepository.GetAllPhos();
		}

		public List<PhoGroup> GetGroupedPhos()
		{
			return phoRepository.GetGroupedPhos ();
		}

		public List<Pho> GetPhosForGroup(int phoGroupId)
		{
			return phoRepository.GetPhosForGroup (phoGroupId);
		}

		public List<Pho> GetFavoritePhos()
		{
			return phoRepository.GetFavoritePhos ();
		}

		public Pho GetPhoById(int phoId)
		{
			return phoRepository.GetPhoById (phoId);
		}

	}
}

