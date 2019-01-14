package md5ceeada832cc5c34ba4092a01b8cbb997;


public class AdListenerInterstitial
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
			"n_onAdFailedToLoad:(I)V:GetOnAdFailedToLoad_IHandler\n" +
			"";
		mono.android.Runtime.register ("LooneyInvaders.Droid.AdListenerInterstitial, LooneyInvaders.Droid", AdListenerInterstitial.class, __md_methods);
	}


	public AdListenerInterstitial ()
	{
		super ();
		if (getClass () == AdListenerInterstitial.class)
			mono.android.TypeManager.Activate ("LooneyInvaders.Droid.AdListenerInterstitial, LooneyInvaders.Droid", "", this, new java.lang.Object[] {  });
	}

	public AdListenerInterstitial (com.google.android.gms.ads.InterstitialAd p0, android.app.Activity p1)
	{
		super ();
		if (getClass () == AdListenerInterstitial.class)
			mono.android.TypeManager.Activate ("LooneyInvaders.Droid.AdListenerInterstitial, LooneyInvaders.Droid", "Android.Gms.Ads.InterstitialAd, Xamarin.GooglePlayServices.Ads.Lite:Android.App.Activity, Mono.Android", this, new java.lang.Object[] { p0, p1 });
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


	public void onAdFailedToLoad (int p0)
	{
		n_onAdFailedToLoad (p0);
	}

	private native void n_onAdFailedToLoad (int p0);

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
