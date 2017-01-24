using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AgencyProfile.Fragments
{
    public class AgentProfile : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            var textToDisplay = new StringBuilder().Insert(0, "Agent Profile ", 5).ToString();
            var view = inflater.Inflate(Resource.Layout.AgentProfile, container, false);
            var textView = view.FindViewById<TextView>(Resource.Id.frag_text_view2);
            textView.Text = textToDisplay;

            //Intent result = new Intent();
            //result.SetClass(Activity, typeof(AgentProfileActivity));

            //StartActivity(result);

            return view;
        }
    }
}