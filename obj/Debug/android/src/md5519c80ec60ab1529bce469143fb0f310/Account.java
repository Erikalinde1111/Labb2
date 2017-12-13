package md5519c80ec60ab1529bce469143fb0f310;


public class Account
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_toString:()Ljava/lang/String;:GetToStringHandler\n" +
			"";
		mono.android.Runtime.register ("Labb2.Account, Labb2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Account.class, __md_methods);
	}


	public Account () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Account.class)
			mono.android.TypeManager.Activate ("Labb2.Account, Labb2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.String toString ()
	{
		return n_toString ();
	}

	private native java.lang.String n_toString ();

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
