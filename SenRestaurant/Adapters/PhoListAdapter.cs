using System;
using Android.Widget;
using SenRestaurant.Core;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using SenRestaurant.Utility;

namespace SenRestaurant
{
	
	public class PhoListAdapter: BaseAdapter<Pho>
	{
		List<Pho> items;
		Activity context;

		public PhoListAdapter(Activity context, List<Pho> items): base()
		{
			this.context = context;
			this.items = items;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override Pho this[int position]
		{   
			get 
			{ 
				return items[position]; 
			} 
		}

		public override int Count 
		{
			get 
			{
				return items.Count;
			} 
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];

            //first demo
            //if (convertView == null)
            //{
            //    convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            //}
            //convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;
            //return convertView;


            //built-in template demo
            //var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://imgs.vietnamnet.vn/Images/" + item.ImagePath + ".jpg");

            //if (convertView == null)
            //{
            //    convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null);
            //}
            //convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;
            //convertView.FindViewById<ImageView>(Android.Resource.Id.Icon).SetImageBitmap(imageBitmap);

            //return convertView;

            //custom row view demo
            //var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://imgs.vietnamnet.vn/Images/" + item.ImagePath + ".jpg");
            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://imgs.vietnamnet.vn/Images/2017/04/02/09/20170402095649-pho-1.jpg");

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.PhoRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.phoNameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.shortDescriptionTextView).Text = item.ShortDescription;
            convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "$ " + item.Price;
            convertView.FindViewById<ImageView>(Resource.Id.phoImageView).SetImageBitmap(imageBitmap);

            return convertView;
        }
	}
}

