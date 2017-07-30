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
using SenRestaurant.Utility;

namespace SenRestaurant.Adapters
{
    public class CartAdapter: BaseAdapter<CartItem>
    {
        List<CartItem> items;
        Activity context;

        public CartAdapter(Activity context, List<CartItem> items): base()
		{
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override CartItem this[int position]
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

            //var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://imgs.vietnamnet.vn/Images/" + item.Pho.ImagePath + ".jpg");
            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://imgs.vietnamnet.vn/Images/2017/04/02/09/20170402095649-pho-1.jpg");

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.CartRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.phoNameTextView).Text = item.Pho.Name;
            convertView.FindViewById<TextView>(Resource.Id.amountTextView).Text = item.Amount.ToString();
            convertView.FindViewById<ImageView>(Resource.Id.phoImageView).SetImageBitmap(imageBitmap);

            return convertView;
        }
    }
}