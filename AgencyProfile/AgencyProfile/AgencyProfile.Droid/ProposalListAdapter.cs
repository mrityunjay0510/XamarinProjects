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
    class ProposalListAdapter : BaseAdapter<Proposals>, IFilterable //RecyclerView.Adapter<ProposalViewHolder> 
    {
        List<Proposals> _proposals;
        Activity _context;

        public ProposalListAdapter(Activity context, List<Proposals> proposals) : base()
        {
            this._context = context;
            this._proposals = proposals;
        }


        public override Proposals this[int position]
        {
            get
            {
                return _proposals[position];
            }
        }

        public override int Count
        {
            get
            {
                return _proposals.Count();
            }
        }

        public Filter Filter
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _proposals[position];
            ////View view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.HistoryProposalsList, null);
            ////view.FindViewById<TextView>(Resource.Id.proposalId).Text = item.proposalId;
            ////view.FindViewById<TextView>(Resource.Id.customerName).Text = item.firstName + " " + item.lastname;
            ////view.FindViewById<TextView>(Resource.Id.createdDate).Text = item.createdDate;
            ////view.FindViewById<TextView>(Resource.Id.sender).Text = item.sender;
            ////view.FindViewById<TextView>(Resource.Id.viewedDate).Text = item.viewedDate;

            ////List<string> QuoteNames = item.quotes.Split(',').ToList<string>();
            ////int quoteCount = QuoteNames.Count();
            ////for (int i = 0; i < quoteCount; i++)
            ////{
            ////    ImageView image = new ImageView(_context);
            ////    image.SetImageResource(getImageId(QuoteNames[i]));
            ////    view.FindViewById<LinearLayout>(Resource.Id.linearLayoutImage).AddView(image, 80, 80);
            ////    image = null;
            ////}

            View view = convertView;
            ViewHolder holder = null;
            if (view == null)
            {

                // LayoutInflater inflator = (LayoutInflater)getSystemService(Context.LAYOUT_INFLATER_SERVICE);
                view = _context.LayoutInflater.Inflate(Resource.Layout.HistoryProposalsList, null);
                holder = new ViewHolder(view);
                view.SetTag(Resource.Id.proposalList, holder);
            }
            else
            {
                holder = (ViewHolder)view.GetTag(Resource.Id.proposalList);
            }
            holder.proposalId.Text = item.proposalId;
            holder.customerName.Text = item.firstName + " " + item.lastname;
            holder.createdDate.Text = item.createdDate;
            holder.sender.Text = item.sender;
            holder.viewedDate.Text = item.viewedDate;
            List<string> quoteNames = item.quotes.Split(',').ToList<string>();
            int quoteCount = quoteNames.Count();

            //int[] images = new int[quoteCount];
            //for (int i = 0; i < quoteCount; i++)
            //{
            //    images[i] = getImageId(quoteNames[i]);
            //}
            //foreach (var itemdata in images)
            //{
            //    holder.linearLayoutImage.AddView(getImageView(itemdata),80,80);
            //}
            holder.linearLayoutImage.RemoveAllViews();
            for (int i = 0; i < quoteCount; i++)
            {         
                ImageView image = new ImageView(_context);
                image.SetImageResource(getImageId(quoteNames[i]));
                //ViewGroup.LayoutParams parm = new ViewGroup.LayoutParams()
                //FrameLayout.LayoutParams imgViewParams = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.WrapContent, FrameLayout.LayoutParams.WrapContent, 0.0f);
                //imgViewParams.SetMargins(-20, 0, 0, 0);
                //image.LayoutParameters = imgViewParams;

                holder.linearLayoutImage.AddView(image, 75,75);
                //holder.linearLayoutImage.AddView(image, 80, 80);
            }


            return view;
        }
        private View getImageView(int image)
        {
            ImageView imageView = new ImageView(_context);
            LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
           // imageView.Setimage (lp);
            imageView.SetImageResource(image);
            return imageView;
        }


        public int getImageId(string Name)
        {
            int Id = 0;
            switch (Name)
            {
                case "Auto":
                    Id = Resource.Drawable.Auto;
                    break;
                case "Homeowners":
                    Id = Resource.Drawable.HouseHold;
                    break;
                case "Motorcycle":
                    Id = Resource.Drawable.MotorCycle;
                    break;
                case "Personal Umbrella Policy":
                    Id = Resource.Drawable.perUmbrella;
                    break;
                case "Renters":
                    Id = Resource.Drawable.Renter;
                    break;
                case "Boat":
                    Id = Resource.Drawable.boat;
                    break;
                case "Condominium":
                    Id = Resource.Drawable.Condo;
                    break;
                case "Landlords":
                    Id = Resource.Drawable.landlord;
                    break;
                case "Manufactured Home":
                    Id = Resource.Drawable.manufacturedHome;
                    break;
            }
            return Id;
        }

        public class ViewHolder : Java.Lang.Object
        {
            public TextView proposalId { get; set; }
            public TextView customerName { get; set; }
            public TextView createdDate { get; set; }
            public TextView sender { get; set; }
            public TextView viewedDate { get; set; }
            public LinearLayout linearLayoutImage { get; set; }
           // private View view { get; set; }

            public ViewHolder(View view)
            {
                proposalId = view.FindViewById<TextView>(Resource.Id.proposalId);
                customerName = view.FindViewById<TextView>(Resource.Id.customerName);
                createdDate = view.FindViewById<TextView>(Resource.Id.createdDate);
                sender = view.FindViewById<TextView>(Resource.Id.sender);
                viewedDate = view.FindViewById<TextView>(Resource.Id.viewedDate);
                linearLayoutImage = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutImage);
            }
        }
    }
    
}

