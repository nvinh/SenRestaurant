using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SenRestaurant.Core
{
	public class PhoWebRepository
	{
		string url = "http://fitmein.azurewebsites.net/phos.asp";

		public PhoWebRepository ()
		{
			Task.Run (() => this.LoadDataAsync (url)).Wait ();
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

		private static List<PhoGroup> phoGroups = new List<PhoGroup>();

		private async Task LoadDataAsync(string uri)
		{
			if (phoGroups != null) 
			{
				string responseJsonString = null;

				using (var httpClient = new HttpClient ()) 
				{
					try 
					{
						Task<HttpResponseMessage> getResponse = httpClient.GetAsync (uri);

						HttpResponseMessage response = await getResponse;

						responseJsonString = await response.Content.ReadAsStringAsync ();
						phoGroups = JsonConvert.DeserializeObject<List<PhoGroup>> (responseJsonString);
					} 
					catch (Exception ex) 
					{
						//handle any errors here, not part of the sample app
						string message = ex.Message;
					}
				}
			}
		}
	}
}