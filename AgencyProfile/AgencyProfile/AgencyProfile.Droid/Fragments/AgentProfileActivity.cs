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
using Android.Support.V4.App;
using Java.Lang;
using AgencyProfile.Services;
using AgencyProfile.Model;
using Android.Graphics;

namespace AgencyProfile.Fragments
{
    [Activity(Label = "Agent Profile",ParentActivity = typeof(MainActivity) , Theme = "@style/AgentProfileActionBarTheme")]
    public class AgentProfileActivity : FragmentActivity
    {

        TabHost tabHost;
        TabManager tabManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AgentProfileFrag_tabs);
            tabHost = FindViewById<TabHost>(Android.Resource.Id.TabHost);
            tabHost.Setup();

          

            tabManager = new TabManager(this, tabHost, Resource.Id.realtabcontent);

            Intent contactIntent = new Intent();
            Intent backgroundIntent = new Intent();
            Intent testimonialIntent = new Intent();

         
           // FetchDataFromService fetchData = new FetchDataFromService();
          //  AgentDetails agentData= fetchData.getAgentProfileData();
            

            tabManager.AddTab(tabHost.NewTabSpec("contact").SetIndicator(CreateTabView("Contact")).SetContent(contactIntent), Java.Lang.Class.FromType(typeof(AgentContactDetailsFragment)), null);
            tabManager.AddTab(tabHost.NewTabSpec("background").SetIndicator(CreateTabView("Background")).SetContent(backgroundIntent), Java.Lang.Class.FromType(typeof(AgentBackgroundFragment)), null);
            tabManager.AddTab(tabHost.NewTabSpec("custTestimonial").SetIndicator(CreateTabView("Testimonial")).SetContent(testimonialIntent), Java.Lang.Class.FromType(typeof(AgentCustTestimonialFragment)), null);


            if (savedInstanceState != null)
            {
                tabHost.SetCurrentTabByTag(savedInstanceState.GetString("tab"));
            }

         
        }

        private View CreateTabView(string tag)
        {
            var tabView = LayoutInflater.Inflate(Resource.Layout.tab_layout, null);
            var textView = tabView.FindViewById<TextView>(Resource.Id.tabLabel);
            textView.Text = tag;
            return tabView;
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutString("tab", tabHost.CurrentTabTag);

        }

        protected class TabManager : Java.Lang.Object, TabHost.IOnTabChangeListener
        {
            private FragmentActivity _activity;
            private TabHost _tabHost;
            private int _containerId;
            private Dictionary<string, TabInfo> _tabs = new Dictionary<string, TabInfo>();
            TabInfo _lastTab;

            public class TabInfo
            {
                public string tag;
                public Class clss;
                public Bundle args;
                public Android.Support.V4.App.Fragment fragment { get; set; }

                public TabInfo(string _tag, Class _class, Bundle _args)
                {
                    tag = _tag;
                    clss = _class;
                    args = _args;
                }
            }

            public class DummyTabFactory : Java.Lang.Object, TabHost.ITabContentFactory
            {
                private Context _context;

                public DummyTabFactory(Context context)
                {
                    _context = context;
                }

                public View CreateTabContent(string tag)
                {
                    var v = new View(_context);
                    v.SetMinimumHeight(0);
                    v.SetMinimumWidth(0);
                    return v;
                }
            }

            public TabManager(FragmentActivity activity, TabHost tabHost, int containerId)
            {
                _activity = activity;
                _tabHost = tabHost;
                _containerId = containerId;
                _tabHost.SetOnTabChangedListener(this);
            }

            public void AddTab(TabHost.TabSpec tabSpec, Class clss, Bundle args)
            {
                tabSpec.SetContent(new DummyTabFactory(_activity));
                var tag = tabSpec.Tag;

                var info = new TabInfo(tag, clss, args);

                // Check to see if we already have a fragment for this tab, probably
                // from a previously saved state.  If so, deactivate it, because our
                // initial state is that a tab isn't shown.
                info.fragment = _activity.SupportFragmentManager.FindFragmentByTag(tag);
                if (info.fragment != null && !info.fragment.IsDetached)
                {
                    var ft = _activity.SupportFragmentManager.BeginTransaction();
                    ft.Detach(info.fragment);
                    ft.Commit();
                }

                _tabs.Add(tag, info);
                _tabHost.AddTab(tabSpec);
            }

            public void OnTabChanged(string tabId)
            {
                var newTab = _tabs[tabId];
                if (_lastTab != newTab)
                {
                    var ft = _activity.SupportFragmentManager.BeginTransaction();
                    if (_lastTab != null)
                    {
                        if (_lastTab.fragment != null)
                        {
                            ft.Detach(_lastTab.fragment);
                        }
                    }
                    if (newTab != null)
                    {
                        if (newTab.fragment == null)
                        {
                            newTab.fragment = Android.Support.V4.App.Fragment.Instantiate(_activity, newTab.clss.Name, newTab.args);
                            ft.Add(_containerId, newTab.fragment, newTab.tag);
                        }
                        else
                        {
                            ft.Attach(newTab.fragment);
                        }
                    }

                    _lastTab = newTab;
                    ft.Commit();
                    _activity.SupportFragmentManager.ExecutePendingTransactions();
                }
            }
        }
    }
}