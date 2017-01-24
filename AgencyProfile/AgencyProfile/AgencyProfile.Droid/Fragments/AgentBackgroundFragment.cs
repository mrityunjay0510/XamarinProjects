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
    public class AgentBackgroundFragment : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view= inflater.Inflate(Resource.Layout.BackgroundFragment, container, false);
            view.FindViewById<RelativeLayout>(Resource.Id.layoutAboutOwner).Click += LayoutAboutOwner_Click;
            view.FindViewById<RelativeLayout>(Resource.Id.layoutWhyChooseAllState).Click += LayoutWhyChooseAllStater_Click;
          
            return view;
        }

        private void LayoutWhyChooseAllStater_Click(object sender, EventArgs e)
        {
            Toast.MakeText(Activity, "LayoutWhyChooseAllStater_Click Clicked!", ToastLength.Short).Show();
            var transaction = FragmentManager.BeginTransaction();
            var agentEditBackgroundFragment = new AgentWhyChooseAllStateFragment();
            agentEditBackgroundFragment.SetTargetFragment(this, 100);
            agentEditBackgroundFragment.Show(transaction, "WhyChooseAllStater_dialog_fragment");
        }

        private void LayoutAboutOwner_Click(object sender, EventArgs e)
        {
            Toast.MakeText(Activity, "layoutAboutOwner Clicked!", ToastLength.Short).Show();
            var transaction = FragmentManager.BeginTransaction();
            var agentEditBackgroundFragment = new AgentEditBackgroundFragment();
            agentEditBackgroundFragment.SetTargetFragment(this, 100);
            agentEditBackgroundFragment.Show(transaction, "agentEditBack_dialog_fragment");
        }
    }

    public class AgentEditBackgroundFragment : Android.Support.V4.App.DialogFragment
    {
        string[] _awards = { "Honor Ring", "Quality Agent", "Allstate Financial Leader Award", "Chairman's Conference", "Best In Company Award For Commercial" };

        string[] _services = { "13th District DAC and CAPS Program", "Salvation Army Chicago ARC Board of Directors", "Renters Insurance", "27th Ward Organization", "Life & Health Insurance", "Voluntary Benefits Insurance " };
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.AgentEditBackground, container, false);

            Spinner award1 = view.FindViewById<Spinner>(Resource.Id.spinAward1);
            Spinner award2 = view.FindViewById<Spinner>(Resource.Id.spinAward2);
            Spinner award3 = view.FindViewById<Spinner>(Resource.Id.spinAward3);
            Spinner service1 = view.FindViewById<Spinner>(Resource.Id.spinService1);
            Spinner service2 = view.FindViewById<Spinner>(Resource.Id.spinService2);
            Spinner service3 = view.FindViewById<Spinner>(Resource.Id.spinService3);
            ArrayAdapter<string> awardAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleSpinnerDropDownItem, _awards);
            awardAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            ArrayAdapter<string> serviceAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleSpinnerDropDownItem, _services);
            serviceAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            award1.Adapter = awardAdapter;
            award2.Adapter = awardAdapter;
            award3.Adapter = awardAdapter;
            service1.Adapter = serviceAdapter;
            service2.Adapter = serviceAdapter;
            service3.Adapter = serviceAdapter;
            return view;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
           // Dialog dialog1 = new Dialog(Activity, Android.Resource.Style.ThemeDeviceDefaultNoActionBarFullscreen);
            //dialog.Window.SetBackgroundDrawable(new Android.Graphics.Drawables.ColorDrawable(Android.Graphics.Color.Transparent));
            //return dialog;


            Dialog dialog = new Dialog(Activity, Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);// ThemeDeviceDefaultNoActionBarFullscreen
            dialog.Window.SetBackgroundDrawable(new Android.Graphics.Drawables.ColorDrawable(Android.Graphics.Color.Transparent));
            return dialog;
        }
    }

    public class AgentWhyChooseAllStateFragment : Android.Support.V4.App.DialogFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.AgentWhyChooseAllStateFrag, container, false);
            return view;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            Dialog dialog = new Dialog(Activity, Android.Resource.Style.ThemeDeviceDefaultNoActionBarFullscreen);
            dialog.Window.SetBackgroundDrawable(new Android.Graphics.Drawables.ColorDrawable(Android.Graphics.Color.Transparent));
            return dialog;
        }


    }
}