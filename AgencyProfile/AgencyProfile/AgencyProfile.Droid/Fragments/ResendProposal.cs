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
    public class ResendProposal : Android.Support.V4.App.DialogFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view= inflater.Inflate(Resource.Layout.ResendInsuranceProposal, container, false);
            view.FindViewById<Button>(Resource.Id.btnSendSms).Click += ResendProposalViaSms_Click;
            view.FindViewById<Button>(Resource.Id.btnSendEmail).Click += ResendProposalViaEmail_Click;
            return view;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }

        private void ResendProposalViaEmail_Click(object sender, EventArgs e)
        {
            var email = new Intent(Android.Content.Intent.ActionSend);
            email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] { "hariom0510@gmail.com"});
            email.PutExtra(Android.Content.Intent.ExtraCc, new string[] { "person3@xamarin.com" });
            email.PutExtra(Android.Content.Intent.ExtraSubject, "Hello Email");
            email.PutExtra(Android.Content.Intent.ExtraText, "Hello from Xamarin.Android");
            email.SetType("message/rfc822");
            StartActivity(email);
        }

        private void ResendProposalViaSms_Click(object sender, EventArgs e)
        {
            var smsUri = Android.Net.Uri.Parse("smsto:1234567890");
            var smsIntent = new Intent(Intent.ActionSendto, smsUri);
            smsIntent.PutExtra("sms_body", "Hello from Xamarin.Android");
            StartActivity(smsIntent);
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            Dialog dialog = new Dialog(Activity, Android.Resource.Style.ThemeDeviceDefaultLightNoActionBarFullscreen);
            dialog.Window.SetBackgroundDrawable(new Android.Graphics.Drawables.ColorDrawable(Android.Graphics.Color.Transparent));
            return dialog;
        }
    }
}