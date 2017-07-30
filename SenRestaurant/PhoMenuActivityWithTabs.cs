
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using SenRestaurant.Core;
//using SenRestaurant.Fragments;

//namespace SenRestaurant
//{
//    [Activity(Label = "PhoMenuActivity")]
//    public class PhoMenuActivity : Activity
//    {
//        private ListView phoListView;
//        private List<Pho> allPhos;
//        private PhoDataService phoDataService;

//        protected override void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);

//            SetContentView(Resource.Layout.PhoTabbedMenu);

//            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

//            AddTab("Favorites", Resource.Drawable.FavoritesIcon, new FavoritePhoFragment());
//            AddTab("Meat Lovers", Resource.Drawable.MeatLoversIcon, new MeatLoversFragment());
//            AddTab("Veggie Lovers", Resource.Drawable.VeggieLoversIcon, new VeggieLoversFragment());

//        }

//        private void AddTab(string tabText, int iconResourceId, Fragment view)
//        {
//            var tab = this.ActionBar.NewTab();
//            tab.SetText(tabText);
//            tab.SetIcon(iconResourceId);

//            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
//            {
//                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
//                if (fragment != null)
//                    e.FragmentTransaction.Remove(fragment);
//                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
//            };
//            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
//            {
//                e.FragmentTransaction.Remove(view);
//            };

//            this.ActionBar.AddTab(tab);

//        }

//        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
//        {
//            base.OnActivityResult(requestCode, resultCode, data);

//            if (resultCode == Result.Ok && requestCode == 100)
//            {
//                var selectedPho = phoDataService.GetPhoById(data.GetIntExtra("selectedPhoId", 0));

//                var dialog = new AlertDialog.Builder(this);
//                dialog.SetTitle("Confirmation");
//                dialog.SetMessage(string.Format("You've added {0} time(s) the {1}", data.GetIntExtra("amount", 0), selectedPho.Name));
//                dialog.Show();
//            }
//        }
//    }
//}

