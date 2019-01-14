package md5ceeada832cc5c34ba4092a01b8cbb997;


public class AdListenerEx
	extends com.google.android.gms.ads.AdListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAdLoaded:()V:GetOnAdLoadedHandler\n" +
			"n_onAdClosed:()V:GetOnAdClosedHandler\n" +
			"n_onAdOpened:()V:GetOnAdOpenedHandler\n" +
			"";
		mono.android.Runtime.register ("LooneyInvaders.Droid.AdListenerEx, LooneyInvaders.Droid", AdListenerEx.class, __md_methods);
	}


	public AdListenerEx ()
	{
		super ();
		if (getClass () == AdListenerEx.class)
			mono.android.TypeManager.Activate ("LooneyInvaders.Droid.AdListenerEx, LooneyInvaders.Droid", "", this, new java.lang.Object[] {  });
	}

	public AdListenerEx (com.google.android.gms.ads.AdView p0)
	{
		super ();
		if (getClass () == AdListenerEx.class)
			mono.android.TypeManager.Activate ("LooneyInvaders.Droid.AdListenerEx, LooneyInvaders.Droid", "Android.Gms.Ads.AdView, Xamarin.GooglePlayServices.Ads.Lite", this, new java.lang.Object[] { p0 });
	}


	public void onAdLoaded ()
	{
		n_onAdLoaded ();
	}

	private native void n_onAdLoaded ();


	public void onAdClosed ()
	{
		n_onAdClosed ();
	}

	private native void n_onAdClosed ();


	public void onAdOpened ()
	{
		n_onAdOpened ();
	}

	private native void n_onAdOpened ();

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
