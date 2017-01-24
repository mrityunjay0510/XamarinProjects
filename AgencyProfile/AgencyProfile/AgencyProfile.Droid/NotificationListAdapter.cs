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
using Android.Text.Util;
using Android.Text;

namespace AgencyProfile
{
    class NotificationListAdapter : BaseAdapter<NotificationList>
    {
        List<NotificationList> _notifications;
        Activity _context;
        public NotificationListAdapter(Activity context, List<NotificationList> notifications) : base()
        {
            this._context = context;
            this._notifications = notifications;
        }
        public override NotificationList this[int position]
        {
            get
            {
                return _notifications[position];
            }
        }

        public override int Count
        {
            get
            {
                return _notifications.Count();
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _notifications[position];
            View view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.NotificationList, null);
            view.FindViewById<TextView>(Resource.Id.txtMessage).Text = item.proposalNumber +" "+item.proposalText;
            return view;
        }
    }

    public class NotificationList
    {
        public string proposalNumber { get; set; }
        public string proposalText { get; set; }
    }

}