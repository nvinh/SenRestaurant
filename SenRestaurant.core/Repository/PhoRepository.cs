using System;
using System.Collections.Generic;
using System.Linq;

namespace SenRestaurant.Core
{
	public class PhoRepository
	{
		public PhoRepository ()
		{
		}

		public List<Pho> GetAllPhos()
		{
			IEnumerable <Pho> phos = 
				from phoGroup in phoGroups
				from pho in phoGroup.Phos
					
				select pho;
			return phos.ToList<Pho> ();
		}

		public List<PhoGroup> GetGroupedPhos()
		{
			return phoGroups;
		}

		public List<Pho> GetPhosForGroup(int phoGroupId)
		{
			var group =  phoGroups.Where (h => h.PhoGroupId == phoGroupId).FirstOrDefault();

			if (group != null) 
			{
				return group.Phos;
			}
			return null;
		}

		public List<Pho> GetFavoritePhos()
		{
			IEnumerable <Pho> phos = 
				from phoGroup in phoGroups
				from pho in phoGroup.Phos
					where pho.IsFavorite
				select pho;
			
			return phos.ToList<Pho> ();
		}

		public Pho GetPhoById(int phoId)
		{
			IEnumerable <Pho> phos = 
				from phoGroup in phoGroups
				from pho in phoGroup.Phos
					where pho.PhoId == phoId
				select pho;
			
			return phos.FirstOrDefault();
		}

		private static List<PhoGroup> phoGroups = new List<PhoGroup>()
		{
			new PhoGroup()
			{
				PhoGroupId = 1, Title = "Meat lovers", ImagePath = "", Phos = new List<Pho>()
				{
					new Pho()
					{
						PhoId = 1, 
						Name = "Beef Noodle", 
						ShortDescription = "The best you have heard on earth", 
						Description = "Pho cooked with beef.",
						ImagePath = "pho1", 
						Available = true,
						PrepTime= 10,
						Ingredients = new List<string>(){"Beef", "Noodle", "Garlic"},
						Price = 15,
						IsFavorite = true
					}, 
					new Pho()
					{
						PhoId = 2, 
						Name = "Chicken Noodle", 
						ShortDescription = "Classic noodle", 
						Description = "Pho cooked with chicken. ",
						ImagePath = "pho2", 
						Available = true,
						PrepTime= 15,
						Ingredients = new List<string>(){"Chicken", "Noodle", "Garlic"},
						Price = 12,
						IsFavorite = false
					}, 
					new Pho()
					{
						PhoId = 3, 
						Name = "Double Beef Noodle", 
						ShortDescription = "For when a regular one isn't enough", 
						Description = "Double regular one.",
						ImagePath = "pho3", 
						Available = true,
						PrepTime= 25,
						Ingredients = new List<string>(){"Extra long beef", "Extra long noodle", "More garlic"},
						Price = 25,
						IsFavorite = true
					}
				}
			},
			new PhoGroup()
			{
				PhoGroupId = 2, Title = "Veggie lovers", ImagePath = "", Phos = new List<Pho>()
				{
					new Pho()
					{
						PhoId = 4, 
						Name = "Beef Pho", 
						ShortDescription = "Vietnamese style for non-meat-lovers", 
						Description = "Pho cooked with fake beef.",
						ImagePath = "pho4", 
						Available = true,
						PrepTime= 10,
						Ingredients = new List<string>(){"Fake Beef", "Noodle", "Garlic"},
						Price = 18,
						IsFavorite = false
					}, 
					new Pho()
					{
						PhoId = 5, 
						Name = "Chicken Pho", 
						ShortDescription = "Classy and veggie", 
						Description = "Pho cooked with fake chicken",
						ImagePath = "pho5", 
						Available = true,
						PrepTime= 15,
						Ingredients = new List<string>(){"Fake chicken", "Noodle", "Garlic"},
						Price = 15,
						IsFavorite = true
					}, 
					new Pho()
					{
						PhoId = 6, 
						Name = "Extra Long Beef Pho", 
						ShortDescription = "For when a regular one isn't enough", 
						Description = "Double regular one",
						ImagePath = "pho6", 
						Available = true,
						PrepTime= 10,
						Ingredients = new List<string>(){"Extra long fake beef", "Extra long noodle", "More garlic"},
						Price = 30,
						IsFavorite = false
					}
				}
			}
		};
	}
}