package md51eb794f2c86c850286abc6f987c50903;


public class AgentProfileActivity_TabManager
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.widget.TabHost.OnTabChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTabChanged:(Ljava/lang/String;)V:GetOnTabChanged_Ljava_lang_String_Handler:Android.Widget.TabHost/IOnTabChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("AgencyProfile.Droid.Fragments.AgentProfileActivity+TabManager, AgencyProfile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AgentProfileActivity_TabManager.class, __md_methods);
	}


	public AgentProfileActivity_TabManager () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AgentProfileActivity_TabManager.class)
			mono.android.TypeManager.Activate ("AgencyProfile.Droid.Fragments.AgentProfileActivity+TabManager, AgencyProfile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public AgentProfileActivity_TabManager (android.support.v4.app.FragmentActivity p0, android.widget.TabHost p1, int p2) throws java.lang.Throwable
	{
		super ();
		if (getClass () == AgentProfileActivity_TabManager.class)
			mono.android.TypeManager.Activate ("AgencyProfile.Droid.Fragments.AgentProfileActivity+TabManager, AgencyProfile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Support.V4.App.FragmentActivity, Xamarin.Android.Support.Fragment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:Android.Widget.TabHost, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void onTabChanged (java.lang.String p0)
	{
		n_onTabChanged (p0);
	}

	private native void n_onTabChanged (java.lang.String p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
