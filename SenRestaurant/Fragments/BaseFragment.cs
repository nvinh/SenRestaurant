using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SenRestaurant.Core;

namespace SenRestaurant.Fragments
{
    public class BaseFragment: Fragment
    {
        protected ListView listView;
        protected PhoDataService phoDataService;
        protected List<Pho> phos;

        public BaseFragment()
        {
            phoDataService = new PhoDataService();
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }
        protected void FindViews()
        {
            listView = this.View.FindViewById<ListView>(Resource.Id.phoListView);
        }

        protected void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var pho = phos[e.Position];

            var intent = new Intent();
            intent.SetClass(this.Activity, typeof(PhoDetailActivity));
            intent.PutExtra("selectedPhoId", pho.PhoId);

            StartActivityForResult(intent, 100);
        }

    }
}