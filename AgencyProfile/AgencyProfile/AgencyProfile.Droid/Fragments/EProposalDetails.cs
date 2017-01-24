using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using AgencyProfile.Model;

namespace AgencyProfile.Fragments
{
    [Activity]
    public class EProposalDetails : FragmentActivity 
    {
        Android.Support.V4.App.Fragment proposalSummFrag, quotesFrag, detailsHistoryFrag;
        string proposalNumber = "";
        string customerName = "";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.EProposalDetails);

            string text = Intent.GetStringExtra("proposalId");
            customerName  = Intent.GetStringExtra("customerName"); 
            proposalNumber = text;
            Toast.MakeText(this, text, ToastLength.Short).Show();
            var fragmentManager = SupportFragmentManager;
         
            proposalSummFrag = fragmentManager.FindFragmentById(Resource.Id.frg_propsalSum);
            quotesFrag = fragmentManager.FindFragmentById(Resource.Id.frg_Quotes);
            detailsHistoryFrag = fragmentManager.FindFragmentById(Resource.Id.frgDetaildHis);

            AddShowHideListener(Resource.Id.btnProposalSummary, proposalSummFrag);
            AddShowHideListener(Resource.Id.btnQuotes, quotesFrag);
            AddShowHideListener(Resource.Id.btnDetailedHistory, detailsHistoryFrag);

            var fragmentTrans = fragmentManager.BeginTransaction();

            fragmentTrans.Hide(quotesFrag);
            fragmentTrans.Hide(detailsHistoryFrag);
            fragmentTrans.Commit();

            FindViewById<Button>(Resource.Id.btn_Notification).Click += btn_NotificationClick;
        }

        private void btn_NotificationClick(object sender, EventArgs e)
        {
            // Set up an intent so that tapping the notifications returns to this app:
            Intent intent = new Intent(this, typeof(NotificationActivity));

            intent.PutExtra("message", "KEVIN JEFF have seen proposal, would you like to talk.Please call on 8934837483");
            // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            const int pendingIntentId = 0;
            PendingIntent pendingIntent = PendingIntent.GetActivity(this, pendingIntentId, intent, PendingIntentFlags.OneShot);

            // Instantiate the builder and set notification elements, including pending intent:
            Notification.Builder builder = new Notification.Builder(this)
                .SetSmallIcon(Resource.Drawable.ic_allstate_notification)
                .SetContentIntent(pendingIntent)
                .SetContentTitle("Proposal Viewed")
                .SetContentText(customerName + " have seen proposal, would you like to talk.");
              

            // Build the notification:
            Notification notification = builder.Build();

            // Get the notification manager:
            NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            // Publish the notification:
            const int notificationId = 1;
            notificationManager.Notify(notificationId, notification);

            // Database Opearation
            SQLite_Android db = new SQLite_Android();
            db.Cleartable();
            db.insertNotificationData(proposalNumber,customerName);
        }

       

        private void AddShowHideListener(int buttonId, Android.Support.V4.App.Fragment fragment)
        {
            var button = FindViewById<Button>(buttonId);
            button.Click += (sender, e) =>
            {
                var ft = SupportFragmentManager.BeginTransaction();
                ft.SetCustomAnimations(Android.Resource.Animation.FadeIn, Android.Resource.Animation.FadeOut);               
                if (fragment.IsHidden)
                {
                    ft.Show(fragment);
                    button.SetBackgroundColor(Android.Graphics.Color.ParseColor("#3498DB"));
                    if (fragment.Id != Resource.Id.frg_propsalSum && fragment.Id != Resource.Id.frg_Quotes)
                    {
                        if (proposalSummFrag.IsVisible)
                        {
                            ft.Hide(proposalSummFrag);
                            (FindViewById<Button>(Resource.Id.btnProposalSummary)).SetBackgroundColor(Android.Graphics.Color.ParseColor("#004a88"));
                        }
                        else
                        {
                            ft.Hide(quotesFrag);
                            (FindViewById<Button>(Resource.Id.btnQuotes)).SetBackgroundColor(Android.Graphics.Color.ParseColor("#004a88"));
                        }
                    }
                    else if (fragment.Id != Resource.Id.frg_Quotes && fragment.Id != Resource.Id.frgDetaildHis)
                    {
                        if (quotesFrag.IsVisible)
                        {
                            ft.Hide(quotesFrag);
                            (FindViewById<Button>(Resource.Id.btnQuotes)).SetBackgroundColor(Android.Graphics.Color.ParseColor("#004a88"));
                        }
                        else
                        {
                            ft.Hide(detailsHistoryFrag);
                            (FindViewById<Button>(Resource.Id.btnDetailedHistory)).SetBackgroundColor(Android.Graphics.Color.ParseColor("#004a88"));
                        }
                    }
                    else if (fragment.Id != Resource.Id.frg_propsalSum && fragment.Id != Resource.Id.frgDetaildHis)
                    {
                        if (proposalSummFrag.IsVisible)
                        {
                           
                            var b = proposalSummFrag.View.FindViewById<Button>(Resource.Id.btnProposalSummary);
                            ft.Hide(proposalSummFrag);
                            (FindViewById<Button>(Resource.Id.btnProposalSummary)).SetBackgroundColor(Android.Graphics.Color.ParseColor("#004a88"));
                        }
                        else
                        {
                            ft.Hide(detailsHistoryFrag);
                            (FindViewById<Button>(Resource.Id.btnDetailedHistory)).SetBackgroundColor(Android.Graphics.Color.ParseColor("#004a88"));
                        }
                    }
                }
                else
                {
                    ft.Hide(fragment);
                    button.SetBackgroundColor(Android.Graphics.Color.ParseColor("#004a88"));
                }
                ft.Commit();
            };
        }

        public class DetailedHistoryFragment : Android.Support.V4.App.Fragment
        {
            public override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
            }

            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                var view = inflater.Inflate(Resource.Layout.DetailedHistoryFragment, container, false);
                return view;
            }
        }
        public class ProposalSummaryFragment : Android.Support.V4.App.Fragment
        {
            public override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
            }

            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                var view = inflater.Inflate(Resource.Layout.ProposalSummaryFragment, container, false);
                view.FindViewById<Button>(Resource.Id.btnResend).Click += ProposalSummaryFragment_Click;
                view.FindViewById<Button>(Resource.Id.btnViewEProposal).Click += ProposalbtnViewEProposal_Click;
                return view;
            }

            private void ProposalbtnViewEProposal_Click(object sender, EventArgs e)
            {
                var uri = Android.Net.Uri.Parse("https://10.0.2.2/MyInsuranceProposal/eProposal/Show?cid=EMC-0000&data=Fy11lfy4I1WytwopeReZi2iu05pWS3Y%2B1PButfaGmx0T2FpJR8RVb%2Bbpw%2F9xfWvsxup6DrItD3vyuJrpuhsJ6w%3D%3D");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            }

            private void ProposalSummaryFragment_Click(object sender, EventArgs e)
            {
                //Intent result = new Intent();
                //result.SetClass(Activity, typeof(ResendProposal));
                //StartActivity(result);
                var transaction = FragmentManager.BeginTransaction();
                var agentEditBackgroundFragment = new ResendProposal();
                agentEditBackgroundFragment.SetTargetFragment(this, 100);
                agentEditBackgroundFragment.Show(transaction, "resend_dialog_fragment");

                //var transaction = FragmentManager.BeginTransaction();
                //var resendProposalFragment = new ResendProposal();         
                //transaction.Show(resendProposalFragment);
                //transaction.Commit();
            }
        }

        public class QuotesFragment : Android.Support.V4.App.Fragment
        {
            ListView _quoteListView;
            public override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
            }

            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                var view = inflater.Inflate(Resource.Layout.QuotesFragment, container, false);
                _quoteListView = view.FindViewById<ListView>(Resource.Id.lstQuotes);
                return view;
            }

            public override void OnActivityCreated(Bundle savedInstanceState)
            {
                base.OnActivityCreated(savedInstanceState);
                List<Quotes> listContact = GetQuotelistContent();
                QuotesListAdapter adapter = new QuotesListAdapter(Activity, listContact);
                _quoteListView.Adapter = adapter;
            }

            public List<Quotes> GetQuotelistContent()
            {
                List<Quotes> list = new List<Quotes>();
                list.Add(new Quotes { ProductName = "Auto", Premium = "$220.50", Quoted = "6/30/2016", Source = "Agency", ControlNumber = "0423232323232443" });
                list.Add(new Quotes { ProductName = "House", Premium = "$220.50", Quoted = "6/30/2016", Source = "Agency", ControlNumber = "0423232323232443" });
                list.Add(new Quotes { ProductName = "HouseHold", Premium = "$220.50", Quoted = "6/30/2016", Source = "Agency", ControlNumber = "0423232323232443" });
                list.Add(new Quotes { ProductName = "MotorCycle", Premium = "$220.50", Quoted = "6/30/2016", Source = "Agency", ControlNumber = "0423232323232443" });
                return list;
            }
        }
    }
}