
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

namespace SenRestaurant
{
    [Activity(Label = "PhoMenuActivity", Icon = "@drawable/smallicon")]
    public class PhoMenuActivity : Activity
    {
        private ListView phoListView;
        private List<Pho> allPhos;
        private PhoDataService phoDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PhoMenuView);

            phoListView = FindViewById<ListView>(Resource.Id.phoListView);

            phoDataService = new PhoDataService();

            allPhos = phoDataService.GetAllPhos();
            phoListView.Adapter = new PhoListAdapter(this, allPhos);

            phoListView.ItemClick += PhoListView_ItemClick;
            phoListView.FastScrollEnabled = true;
        }

        private void PhoListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var pho = allPhos[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(PhoDetailActivity));
            intent.PutExtra("selectedPhoId", pho.PhoId);

            StartActivityForResult(intent, 100);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedPho = phoDataService.GetPhoById(data.GetIntExtra("selectedPhoId", 0));

                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Confirmation");
                dialog.SetMessage(string.Format("You've added {0} time(s) the {1}", data.GetIntExtra("amount", 0), selectedPho.Name));
                dialog.Show();
            }
        }
    }
}

