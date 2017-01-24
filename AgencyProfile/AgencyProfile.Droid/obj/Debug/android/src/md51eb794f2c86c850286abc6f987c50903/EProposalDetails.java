package md51eb794f2c86c850286abc6f987c50903;


public class EProposalDetails
	extends android.support.v4.app.FragmentActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("AgencyProfile.Droid.Fragments.EProposalDetails, AgencyProfile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", EProposalDetails.class, __md_methods);
	}


	public EProposalDetails () throws java.lang.Throwable
	{
		super ();
		if (getClass () == EProposalDetails.class)
			mono.android.TypeManager.Activate ("AgencyProfile.Droid.Fragments.EProposalDetails, AgencyProfile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
