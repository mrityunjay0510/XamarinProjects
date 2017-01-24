using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using AgencyProfile.Model;
using Android.Content;

using com.refractored.fab;
using System;
using Android.Runtime;
using Android.App;
using System.Linq;
using AgencyProfile.Droid.Fragments;

namespace  AgencyProfile.Droid
{
    class History : Android.Support.V4.App.ListFragment, IScrollDirectorListener, AbsListView.IOnScrollListener, HistoryFilterFragment.IFilterDialogListener //, AdapterView.IOnItemClickListener
    {
        ListView _proposalListView;
        string[] _senders = { "ALL","A0B0001", "SAL48F10", "SHOA0701", "SCA50A10" };
        List<Proposals> _historylist;
        List<Proposals> _listContact;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.History, container, false);
            _proposalListView = view.FindViewById<ListView>(Android.Resource.Id.List);
            var fab = view.FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.AttachToListView(_proposalListView, this, this);
            fab.Click += (sender, args) =>
            {
                Toast.MakeText(Activity, "FAB Clicked!", ToastLength.Short).Show();
                var transaction = FragmentManager.BeginTransaction();
                var hisDialogFragment = new HistoryFilterFragment(_senders);
                hisDialogFragment.SetTargetFragment(this, 100);
                hisDialogFragment.Show(transaction, "filter_dialog_fragment");
            };

            var agentProfileLayout= view.FindViewById<LinearLayout>(Resource.Id.layout_agentProfile);
            agentProfileLayout.Click += AgentProfileLayout_Click;

            // mProgressBar = view.FindViewById<ProgressBar>(Resource.Id.progressBar1);

            return view;
        }

        private void AgentProfileLayout_Click(object sender, EventArgs e)
        {
            Intent result = new Intent();
            result.SetClass(Activity, typeof(AgentProfileActivity));
            StartActivity(result);
        }

        public override void OnAttach(Context context)
        {
            base.OnAttach(this.Context);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            _listContact = GetlistContact();
            ProposalListAdapter adapter = new ProposalListAdapter(Activity, _listContact);
            _proposalListView.Adapter = adapter;
            //int agentid = 099;
            //FetchDataFromService fetchData = new FetchDataFromService();
            //_historylist = fetchData.getProposalHistoryList(agentid);
            //ProposalListAdapter adapter = new ProposalListAdapter(Activity, _historylist);
            //_proposalListView.Adapter = adapter;

        }

        public List<Proposals> GetlistContact()
        {
            List<Proposals> _proposal = new List<Proposals>();

            _proposal.Add(new Proposals() { proposalId = "37b60e09dd5b4cceb370fdbb4c109e09", sender = "A0B0001", firstName = "LOZANO", lastname = "MARK", createdDate = "8/2/2016 12:40", viewedDate = "8/2/2016 12:40", quotes = "Renters" });
            _proposal.Add(new Proposals() { proposalId = "f3e8d8843565442fad458b34c46eec63", sender = "A0B0001", firstName = "NAVARRO", lastname = "NATHANIEL", createdDate = "8/2/2016 0:37", viewedDate = "8/2/2016 0:35", quotes = "Homeowners" });
            _proposal.Add(new Proposals() { proposalId = "81ac82ba50384322b9c2c5810dd46baa", sender = "A0B0001", firstName = "FIGUEROA", lastname = "MICHAEL", createdDate = "8/1/2016 11:29", viewedDate = "8/1/2016 11:29", quotes = "Motorcycle,Boat" });
            _proposal.Add(new Proposals() { proposalId = "a04390647f65441a9385cb4ae5471209", sender = "A0B0001", firstName = "BURNSIDE", lastname = "CHERI", createdDate = "7/29/2016 5:57", viewedDate = "7/29/2016 5:50", quotes = "Personal Umbrella Policy" });
            _proposal.Add(new Proposals() { proposalId = "22d7d0c567da41cca88542c11bcff11d", sender = "SAL48F10", firstName = "MATTAY", lastname = "RAGHAV", createdDate = "5/9/2016 16:54", viewedDate = "5/9/2016 16:54", quotes = "Motorcycle" });
            _proposal.Add(new Proposals() { proposalId = "f8afb803521a4e6cbd14fe1a6824d709", sender = "A0B0001", firstName = "HARRISON", lastname = "KIMBERLEE", createdDate = "5/9/2016 13:56", viewedDate = "5/9/2016 13:56", quotes = "Homeowners" });
            _proposal.Add(new Proposals() { proposalId = "c4cd426a2b6d456bb7d70ffb11aed365", sender = "SHOA0701", firstName = "FLANTINIS", lastname = "KYRIAKOS", createdDate = "8/24/2015 5:08", viewedDate = "5/9/2016 11:32", quotes = "Condominium,Auto" });
            _proposal.Add(new Proposals() { proposalId = "d9718576c1864575978bb08f86701919", sender = "SCA50A10", firstName = "MUTHUVELU", lastname = "BHARATHKUMAR", createdDate = "3/18/2016 16:19", viewedDate = "3/18/2016 16:19", quotes = "Auto" });
            _proposal.Add(new Proposals() { proposalId = "b36bbf447dd74e969c06af10c11773bb", sender = "A0B0001", firstName = "OLDEN", lastname = "DARLENE", createdDate = "2/29/2016 23:11", viewedDate = "2/29/2016 23:07", quotes = "Landlords,Auto,Homeowners" });
            _proposal.Add(new Proposals() { proposalId = "498e2a276bb74f5eb53d30f2495af24e", sender = "A0B0001", firstName = "WENZEL", lastname = "EDWIN", createdDate = "3/11/2016 16:16", viewedDate = "2/28/2016 12:14", quotes = "Personal Umbrella Policy,Auto,Homeowners,Renters,Motorcycle,Boat" });
            _proposal.Add(new Proposals() { proposalId = "368b2cadf151427d82a6d316d5741a4c", sender = "A0B0001", firstName = "WENZEL", lastname = "EDWIN", createdDate = "7/21/2016 10:46", viewedDate = "7/21/2016 10:46", quotes = "Homeowners" });
            _proposal.Add(new Proposals() { proposalId = "7f4b12d0e6584ccebc4bb583e470b364", sender = "A0B0001", firstName = "RIED-ELIZONDO", lastname = "ANGELA", createdDate = "7/18/2016 3:28", viewedDate = "7/18/2016 3:26", quotes = "Boat,Motorcycle" });

            return _proposal;
        }


        public override void OnListItemClick(ListView lValue, View vValue, int position, long id)
        {
            Toast.MakeText(Activity, "List Item Clicked", ToastLength.Short).Show();
            base.OnListItemClick(lValue, vValue, position, id);
            string proposalId =vValue.FindViewById<TextView>(Resource.Id.proposalId).Text;
            string customerName = vValue.FindViewById<TextView>(Resource.Id.customerName).Text;
            Intent result = new Intent();
            result.SetClass(Activity, typeof(EProposalDetails));
            result.PutExtra("proposalId", proposalId);
            result.PutExtra("customerName", customerName);
            StartActivity(result);
        }

        public void OnScrollDown()
        {
            Console.WriteLine("ListViewFragment: OnScrollDown");
        }

        public void OnScrollUp()
        {
            Console.WriteLine("ListViewFragment: OnScrollUp");
        }

        public void OnScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount)
        {
            Console.WriteLine("ListViewFragment: OnScroll");
        }

        public void OnScrollStateChanged(AbsListView view, [GeneratedEnum] ScrollState scrollState)
        {
            Console.WriteLine("ListViewFragment: OnScrollChanged");
        }

        public void onDialogFilterClick(string firstName, string lastName, string sender)
        {
            // Toast.MakeText(Activity, firstName +" "+ lastName +" "+sender, ToastLength.Short).Show();
            List<Proposals> filterList;

            ////StringBuilder queryString = new StringBuilder();
            ////queryString.Append("(from fp in _listContact where");

            ////if (!string.IsNullOrEmpty(firstName))
            ////{
            ////    queryString.Append("fp.firstName.Contains(firstName, StringComparison.OrdinalIgnoreCase)");
            ////    queryString.Append((string.IsNullOrEmpty(firstName) ? string.Empty : "&&"));
            ////}
            ////if (!string.IsNullOrEmpty(lastName))
            ////{
            ////    queryString.Append("fp.lastname.Contains(lastName, StringComparison.OrdinalIgnoreCase)");
            ////    queryString.Append((string.IsNullOrEmpty(lastName) ? string.Empty : "&&"));
            ////}
            ////if(!(sender=="ALL"))
            ////{
            ////    queryString.Append("fp.sender.Contains(sender, StringComparison.OrdinalIgnoreCase)");
            ////}

            ////queryString.Append("Select fp");

            //filterList =(from fp in _listContact
            //             where (!string.IsNullOrEmpty(firstName) || fp.firstName.Contains(firstName, StringComparison.OrdinalIgnoreCase)) &&
            //              (!string.IsNullOrEmpty(lastName) || fp.lastname.Contains(lastName, StringComparison.OrdinalIgnoreCase)) &&
            //              (!string.IsNullOrEmpty(sender) || fp.sender.Contains(sender, StringComparison.OrdinalIgnoreCase))
            //              select fp).ToList();

            //    if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(sender))
            //{
            //    filterList=(from fp in _listContact
            //     where fp.firstName.Contains(firstName, StringComparison.OrdinalIgnoreCase) && fp.lastname.Contains(lastName, StringComparison.OrdinalIgnoreCase) && fp.sender.Contains(sender, StringComparison.OrdinalIgnoreCase)
            //     select fp).ToList();
            //} else if()
            //List<Proposals> filterList = (from fp in _listContact
            //                              where fp.firstName.Contains(firstName, StringComparison.OrdinalIgnoreCase) || fp.lastname.Contains(lastName, StringComparison.OrdinalIgnoreCase) || fp.sender.Contains(sender, StringComparison.OrdinalIgnoreCase)
            //                              select fp).ToList();

            filterList = (from fp in _historylist
                          where fp.firstName == firstName
                          select fp).ToList(); ;
            ProposalListAdapter adapter = new ProposalListAdapter(Activity, filterList);
            _proposalListView.Adapter = adapter;

        }
    }




    public class HistoryFilterFragment : Android.Support.V4.App.DialogFragment
    {
        private string[] _serders;

        public interface IFilterDialogListener
        {
            void onDialogFilterClick(string firstName,string lastName,string sender);
        }
        IFilterDialogListener filterListner;

        public HistoryFilterFragment(string[] senders)
        {
            _serders = senders;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            try
            {
                filterListner = (IFilterDialogListener)TargetFragment;
            }
            catch (Exception e)
            {
                throw;
            }
        }
      
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.HistoryFilterFragment, container, false);

            Spinner s1 = view.FindViewById<Spinner>(Resource.Id.spnSender);

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleSpinnerDropDownItem, _serders);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            s1.Adapter = adapter;

            s1.ItemSelected += delegate (object sender, AdapterView.ItemSelectedEventArgs e) {
                Toast.MakeText(Activity, "Spinner1: position=" + e.Position + " id=" + e.Id, ToastLength.Short).Show();
            };

            s1.NothingSelected += delegate (object sender, AdapterView.NothingSelectedEventArgs e) {
                Toast.MakeText(Activity, "Spinner1: unselected", ToastLength.Short).Show();
            };

            view.FindViewById<Button>(Resource.Id.btnFilter).Click += delegate
            {
                Toast.MakeText(Activity, "btnFilter Clicked", ToastLength.Short).Show();
                var firstNametxt = view.FindViewById<EditText>(Resource.Id.txtFirstName);
                var lastNametxt = view.FindViewById<EditText>(Resource.Id.txtLastName);
                var sendertxt = view.FindViewById<Spinner>(Resource.Id.spnSender);
                filterListner.onDialogFilterClick(firstNametxt.Text.ToString(), lastNametxt.Text, sendertxt.SelectedItem.ToString());
                Dismiss();
            };
            view.FindViewById<Button>(Resource.Id.btnReset).Click += delegate
            {
                Toast.MakeText(Activity, "btnReset Clicked", ToastLength.Short).Show();
            };
            return view;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            Dialog dialog = base.OnCreateDialog(savedInstanceState);
            return dialog;
        }
    }
}