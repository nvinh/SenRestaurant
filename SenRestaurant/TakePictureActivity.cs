using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Provider;
using Java.IO;
using Android.Graphics;
using SenRestaurant.Utility;

namespace SenRestaurant
{

    [Activity(Label = "Extract text from a photo", Icon = "@drawable/smallicon")]
    public class TakePictureActivity: Activity
    {
        private ImageView senPictureImageView;
        private Button takePictureButton;
        private File imageDirectory;
        private File imageFile;
        private Bitmap imageBitmap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TakePictureView);

            FindViews();

            HandleEvents();

            imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                Android.OS.Environment.DirectoryPictures), "SenRestaurant");

            if (!imageDirectory.Exists())
            {
                imageDirectory.Mkdirs();
            }
        }

        private void FindViews()
        {
            senPictureImageView = FindViewById<ImageView>(Resource.Id.senPictureImageView);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            takePictureButton.Click += TakePictureButton_Click;
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            imageFile = new File(imageDirectory, String.Format("PhotoWithSen_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));

            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            int height = senPictureImageView.Height;
            int width = senPictureImageView.Width;
            imageBitmap = ImageHelper.GetImageBitmapFromFilePath(imageFile.Path, width, height);

                if (imageBitmap != null)
                {
                    senPictureImageView.SetImageBitmap(imageBitmap);
                    imageBitmap = null;
                }

                //required to avoid memory leaks!
                GC.Collect();
        }


    }
}