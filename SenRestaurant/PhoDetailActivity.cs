using Android.App;
using Android.Widget;
using Android.OS;
using SenRestaurant.Core;
using Android.Graphics;
using System.Net;
using SenRestaurant.Utility;
using System;
using Android.Content;

namespace SenRestaurant
{
    [Activity(Label = "Pho at Sen Restaurant", Icon = "@drawable/smallicon")]
    public class PhoDetailActivity : Activity
    {
        private ImageView phoImageView;
        private TextView phoNameTextView;
        private TextView shortDescriptionTextView;
        private TextView descriptionTextView;
        private TextView priceTextView;
        private EditText amountEditText;
        private Button cancelButton;
        private Button orderButton;
        private Pho selectedPho;
        private PhoDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.PhoDetailView);

            //early demos
            //PhoDataService dataService = new PhoDataService ();
            //selectedPho = dataService.GetPhoById (1);

            //FindViews();

            //BindData();
            //------------------------------------------------------------------

            //HandleEvents();

            //navigation demos
            var selectedPhoId = Intent.Extras.GetInt("selectedPhoId");

            dataService = new PhoDataService();
            selectedPho = dataService.GetPhoById(selectedPhoId);

            FindViews();

            BindData();

            HandleEvents();
        }

        private void HandleEvents()
        {
            orderButton.Click += (object sender, EventArgs e) =>
            {
                var amount = Int32.Parse(amountEditText.Text);
                AddToCart(selectedPho, amount);

                //var dialog = new AlertDialog.Builder(this);
                //dialog.SetTitle("Confirmation");
                //dialog.SetMessage("Your Pho has been added to your cart!");
                //dialog.Show();

                var intent = new Intent();
                intent.PutExtra("selectedPhoId", selectedPho.PhoId);
                intent.PutExtra("amount", amount);

                SetResult(Result.Ok, intent);

                this.Finish();
            };

            cancelButton.Click += (object sender, System.EventArgs e) =>
            {
                SetResult(Result.Canceled);

                this.Finish();
            };

        }

        public void AddToCart(Pho pho, int amount)
        {
            CartDataService cartDataService = new CartDataService();
            cartDataService.AddCartItem(pho, amount);
        }

        private void FindViews()
        {
            phoImageView = FindViewById<ImageView>(Resource.Id.phoImageView);
            phoNameTextView = FindViewById<TextView>(Resource.Id.phoNameTextView);
            shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }

        private void BindData()
        {

            phoNameTextView.Text = selectedPho.Name;
            shortDescriptionTextView.Text = selectedPho.ShortDescription;
            descriptionTextView.Text = selectedPho.Description;
            priceTextView.Text = "Price: " + selectedPho.Price;

            //var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://imgs.vietnamnet.vn/Images/" + selectedPho.ImagePath + ".jpg");
            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://imgs.vietnamnet.vn/Images/2017/04/02/09/20170402095649-pho-1.jpg");
            
            phoImageView.SetImageBitmap(imageBitmap);
        }
    }
}


