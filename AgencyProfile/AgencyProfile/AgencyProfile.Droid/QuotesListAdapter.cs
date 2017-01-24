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
using AgencyProfile.Model;

namespace AgencyProfile
{
    class QuotesListAdapter : BaseAdapter<Quotes>
    {
        List<Quotes> _quotes;
        Activity _context;
        public QuotesListAdapter(Activity context, List<Quotes> quotes) : base()
        {
            this._context = context;
            this._quotes = quotes;
        }
        public override Quotes this[int position]
        {
            get
            {
                return _quotes[position];
            }
        }

        public override int Count
        {
            get
            {
                return _quotes.Count();
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _quotes[position];
            View view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.quotesList, null);
            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.quoteImage);
            imageView.SetImageResource(getImageId(item.ProductName));
            //view.FindViewById<TextView>(Resource.Id.quoteImage).Text = item.ProductName;
            view.FindViewById<TextView>(Resource.Id.txtControlNumber).Text = item.ControlNumber;
            view.FindViewById<TextView>(Resource.Id.txtQuoted).Text = item.Quoted;
            view.FindViewById<TextView>(Resource.Id.txtPremium).Text = item.Premium;
            view.FindViewById<TextView>(Resource.Id.txtSource).Text = item.Source;
            return view;
        }


        public int getImageId(string Name)
        {
            int Id = 0;
            switch(Name)
            {
                case "Auto":
                    Id = Resource.Drawable.Auto;
                    break;
                case "House":
                    Id = Resource.Drawable.HouseHold;
                    break;

                case "HouseHold":
                    Id = Resource.Drawable.HouseHold;
                    break;

                case "MotorCycle":
                    Id = Resource.Drawable.MotorCycle;
                    break;     
            }
            return  Id;
        }
    }
}