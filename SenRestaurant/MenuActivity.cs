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
using Todo;
using System.Data.SqlClient;

//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

namespace SenRestaurant
{
    [Activity(Label = "Sen Vietnamese Restaurant", MainLauncher = true, Icon = "@drawable/smallicon")]
    public class MenuActivity : Activity
    {
        private Button orderButton;
        private Button cartButton;
        private Button aboutButton;
        private Button mapButton;
        private Button takePictureButton;
        private Button analyticButton;
        private EditText analyticText;
        private Button queryButton;
        ITextTranslationService textTranslationService;
        ITextAnalyticService textAnalyticService;
        IBingSpellCheckService bingSpellCheckService;
        ITestQueryService testQueryService;
        static ITodoItemRepository todoItemRepository;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.MainMenu);

            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
            cartButton = FindViewById<Button>(Resource.Id.cartButton);
            aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
            mapButton = FindViewById<Button>(Resource.Id.mapButton);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
            analyticButton = FindViewById<Button>(Resource.Id.analyticButton);
            analyticText = FindViewById<EditText>(Resource.Id.analyticText);
            queryButton = FindViewById<Button>(Resource.Id.queryButton);
        }

        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            cartButton.Click += CartButton_Click;
            aboutButton.Click += AboutButton_Click;
            mapButton.Click += MapButton_Click;
            takePictureButton.Click += TakePictureButton_Click;
            analyticButton.Click += analyticButton_Click;
            queryButton.Click += queryButton_Click;
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePictureActivity));
            StartActivity(intent);
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SenMapActivity));
            StartActivity(intent);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        private void CartButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CartActivity));
            StartActivity(intent);
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(PhoMenuActivity));
            StartActivity(intent);
        }

        async void analyticButton_Click(object sender, EventArgs e)
        {
            string translatedText = string.Empty;
            translatedText = analyticText.Text;
            try
            {
                if (!string.IsNullOrWhiteSpace(translatedText))
                {
                    //IsProcessing = true;
                    //textTranslationService = new TextTranslationService(new AuthenticationService(Constants.TextTranslatorApiKey));
                    //string t = await textTranslationService.TranslateTextAsync(translatedText);
                    
                    //textAnalyticService = new TextAnalyticService(new AuthenticationService(Constants.TextAnalyticApiKey));
                    //string t = await textAnalyticService.AnalyticTextAsync(translatedText);

                    bingSpellCheckService = new BingSpellCheckService();
                    var spellCheckResult = await bingSpellCheckService.SpellCheckTextAsync(translatedText);
                    foreach (var flaggedToken in spellCheckResult.FlaggedTokens)
                    {
                        translatedText = translatedText.Replace(flaggedToken.Token, flaggedToken.Suggestions.FirstOrDefault().Suggestion);
                    }
                    analyticText.Text = translatedText;
                    //OnPropertyChanged("TodoItem");
                    //analyticText.Text = t;
                    //string t = "";
                    //IsProcessing = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                analyticText.Text += ex.Message; // " error";
            }
        }

        async void queryButton_Click(object sender, EventArgs e)
        {
            try
            {
                //IsProcessing = true;
                string t = analyticText.Text;
                testQueryService = new TestQueryService(new AuthenticationService(Constants.TestQueryApiKey));
                var queryResult = await testQueryService.TestQueryAsync(t);
                analyticText.Text = queryResult;
                //IsProcessing = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                analyticText.Text += ex.Message; // " error";
            }
        }

        async void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(analyticText.Text))
                {
                    await App.TodoManager.SaveAnalyticTextAsync(analyticText.Text);
                }
                //await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                analyticText.Text += ex.Message; // " error";
            }            
        }
    }
}