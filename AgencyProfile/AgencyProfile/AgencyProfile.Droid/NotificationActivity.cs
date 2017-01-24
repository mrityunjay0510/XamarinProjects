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

namespace AgencyProfile
{
    [Activity(Label = "NotificationActivity")]
    public class NotificationActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            int count = 1;// Intent.Extras.GetInt("count", -1);

            // No count was passed? Then just return.
            if (count <= 0)
                return;

            // Display the count sent from the first activity:
            SetContentView(Resource.Layout.Notification);
           // TextView textView = FindViewById<TextView>(Resource.Id.textView);
           // string message = Intent.Extras.GetString("message", "");

           // textView.Text = String.Format(message);


            // Get the notification manager:
            NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            notificationManager.CancelAll();

            //List<NotificationList> _listNotification = getNotification();
            //NotificationListAdapter adaptor = new NotificationListAdapter(this, _listNotification);
            //ListView notificationListView;
            //notificationListView = FindViewById<ListView>(Android.Resource.Id.List);
            //notificationListView.Adapter = adaptor;

            // Database Opearation

            SQLite_Android db = new SQLite_Android();
            var data=db.getNotificationData();
            List<NotificationList> _notificationList = new List<NotificationList>();
            foreach (var item in data)
            {
                _notificationList.Add(new NotificationList() { proposalNumber=item.proposalNumber,proposalText=item.proposalText });
            }
            NotificationListAdapter adaptor = new NotificationListAdapter(this, _notificationList);
            ListView notificationListView;
            notificationListView = FindViewById<ListView>(Android.Resource.Id.List);
            notificationListView.Adapter = adaptor;
            // Create your application here
        }

        public List<NotificationList> getNotification()
        {
            List<NotificationList> _notifiy = new List<NotificationList>();

            _notifiy.Add(new NotificationList() { proposalNumber = "2132333334343", proposalText = "KEVIN JEFF have seen proposal, would you like to talk. Please call on 8934837483" });
            _notifiy.Add(new NotificationList() { proposalNumber = "2132333tew43434", proposalText = "KEVIN JEFF have seen proposal, would you like to talk. Please call on 8934837483" });
            _notifiy.Add(new NotificationList() { proposalNumber = "21323435ret565e", proposalText = "KEVIN JEFF have seen proposal, would you like to talk. Please call on 8934837483" });
            _notifiy.Add(new NotificationList() { proposalNumber = "2132333334343", proposalText = "KEVIN JEFF have seen proposal, would you like to talk. Please call on 8934837483" });
            _notifiy.Add(new NotificationList() { proposalNumber = "2132333tew43434", proposalText = "KEVIN JEFF have seen proposal, would you like to talk. Please call on 8934837483" });
            _notifiy.Add(new NotificationList() { proposalNumber = "21323435ret565e", proposalText = "KEVIN JEFF have seen proposal, would you like to talk. Please call on 8934837483" });
            _notifiy.Add(new NotificationList() { proposalNumber = "2132333334343", proposalText = "KEVIN JEFF have seen proposal, would you like to talk. Please call on 8934837483" });
            _notifiy.Add(new NotificationList() { proposalNumber = "2132333tew43434", proposalText = "KEVIN JEFF have seen proposal, would you like to talk. Please call on 8934837483" });
            _notifiy.Add(new NotificationList() { proposalNumber = "21323435ret565e", proposalText = "KEVIN JEFF have seen proposal, would you like to talk. Please call on 8934837483" });
            _notifiy.Add(new NotificationList() { proposalNumber = "2132333334343", proposalText = "KEVIN JEFF have seen proposal, would you like to talk. Please call on 8934837483" });
            _notifiy.Add(new NotificationList() { proposalNumber = "2132333tew43434", proposalText = "KEVIN JEFF have seen proposal, would you like to talk. Please call on 8934837483" });
            _notifiy.Add(new NotificationList() { proposalNumber = "21323435ret565e", proposalText = "KEVIN JEFF have seen proposal, would you like to talk. Please call on 8934837483" });

            return _notifiy;
        }
    }
}