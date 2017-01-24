using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.App;
using AgencyProfile.Droid.Fragments;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V4.Widget;

namespace AgencyProfile.Droid
{
   // [Activity(MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme")]
    [Activity(Icon = "@drawable/icon", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        private SupportToolbar mToolbar;
        private SupportFragment mCurrentFragment;
        private History mHistoryFrag;
        private Stack<SupportFragment> mStackFragment;


        ListView mAgentNoDrawer;
        List<string> mAgentNumbers = new List<string>();
        ActionBarDrawerToggle mAgentDrawerToggle;
        DrawerLayout mAgentDrawerLayout;
        ArrayAdapter mAgentAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mStackFragment = new Stack<SupportFragment>();
            mHistoryFrag = new History();
            mAgentDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.myDrawer);
            mAgentNoDrawer = FindViewById<ListView>(Resource.Id.agentListView);

            mToolbar.Title = "";
            SetSupportActionBar(mToolbar);

            mAgentNumbers.Add("First Left Item");
            mAgentNumbers.Add("Second Left Item");
            mAgentAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, mAgentNumbers);
            mAgentNoDrawer.Adapter = mAgentAdapter;
            mAgentDrawerToggle = new ActionBarDrawerToggle(this, mAgentDrawerLayout, mToolbar, Resource.String.open_drawer, Resource.String.close_drawer);        
          
            mAgentDrawerLayout.SetDrawerListener(mAgentDrawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            mAgentDrawerToggle.SyncState();
            

            var trans = SupportFragmentManager.BeginTransaction();
            trans.Add(Resource.Id.fragmentContainer, mHistoryFrag, "History");
            trans.Commit();


        }
        #region 
        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            mAgentDrawerToggle.SyncState();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            if (mAgentDrawerLayout.IsDrawerOpen((int)GravityFlags.Left))
            {
                outState.PutString("DrawerState", "Opened");
            }

            else
            {
                outState.PutString("DrawerState", "Closed");
            }
        }
        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            mAgentDrawerToggle.OnConfigurationChanged(newConfig);
        }
        #endregion

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
   

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.ItemId)
            {
                case Resource.Id.action_setting:
                    Toast.MakeText(this, "Setting Selected", ToastLength.Short).Show();
                    break;
                //case Resource.Id.action_notification:
                //    ShowFragment(mHistoryFrag);
                //    return true;
                case Resource.Id.action_notification:
                    Intent result = new Intent();
                    result.SetClass(this, typeof(NotificationActivity));
                    StartActivity(result);
                    return true;
                default: break;
            }
            return base.OnOptionsItemSelected(item);
        }

        public void ShowFragment(SupportFragment fragment)
        {
            var trans=SupportFragmentManager.BeginTransaction();
            trans.Hide(mCurrentFragment);
            trans.Show(fragment);
            trans.AddToBackStack(null);
            trans.Commit();

            mStackFragment.Push(mCurrentFragment);
            mCurrentFragment = fragment;
        }

        public SupportFragment GetCurrentFragement()
        {
                return mCurrentFragment;
        }

        public override void OnBackPressed()
        {
            if(SupportFragmentManager.BackStackEntryCount >0)
            {
                SupportFragmentManager.PopBackStack();
                mCurrentFragment = mStackFragment.Pop();
            }
            else
            {
                base.OnBackPressed();
            }
        }


    }
}

