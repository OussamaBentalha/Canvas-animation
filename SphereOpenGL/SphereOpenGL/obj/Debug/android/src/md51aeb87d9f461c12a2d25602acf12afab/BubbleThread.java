package md51aeb87d9f461c12a2d25602acf12afab;


public class BubbleThread
	extends java.lang.Thread
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler\n" +
			"";
		mono.android.Runtime.register ("SphereOpenGL.SurfaceViewPanel.BubbleThread, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BubbleThread.class, __md_methods);
	}


	public BubbleThread ()
	{
		super ();
		if (getClass () == BubbleThread.class)
			mono.android.TypeManager.Activate ("SphereOpenGL.SurfaceViewPanel.BubbleThread, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public BubbleThread (java.lang.Runnable p0)
	{
		super (p0);
		if (getClass () == BubbleThread.class)
			mono.android.TypeManager.Activate ("SphereOpenGL.SurfaceViewPanel.BubbleThread, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public BubbleThread (java.lang.Runnable p0, java.lang.String p1)
	{
		super (p0, p1);
		if (getClass () == BubbleThread.class)
			mono.android.TypeManager.Activate ("SphereOpenGL.SurfaceViewPanel.BubbleThread, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public BubbleThread (java.lang.String p0)
	{
		super (p0);
		if (getClass () == BubbleThread.class)
			mono.android.TypeManager.Activate ("SphereOpenGL.SurfaceViewPanel.BubbleThread, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}


	public BubbleThread (java.lang.ThreadGroup p0, java.lang.Runnable p1)
	{
		super (p0, p1);
		if (getClass () == BubbleThread.class)
			mono.android.TypeManager.Activate ("SphereOpenGL.SurfaceViewPanel.BubbleThread, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.ThreadGroup, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public BubbleThread (java.lang.ThreadGroup p0, java.lang.Runnable p1, java.lang.String p2)
	{
		super (p0, p1, p2);
		if (getClass () == BubbleThread.class)
			mono.android.TypeManager.Activate ("SphereOpenGL.SurfaceViewPanel.BubbleThread, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.ThreadGroup, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public BubbleThread (java.lang.ThreadGroup p0, java.lang.Runnable p1, java.lang.String p2, long p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == BubbleThread.class)
			mono.android.TypeManager.Activate ("SphereOpenGL.SurfaceViewPanel.BubbleThread, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.ThreadGroup, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int64, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public BubbleThread (java.lang.ThreadGroup p0, java.lang.String p1)
	{
		super (p0, p1);
		if (getClass () == BubbleThread.class)
			mono.android.TypeManager.Activate ("SphereOpenGL.SurfaceViewPanel.BubbleThread, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.ThreadGroup, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}

	public BubbleThread (android.view.SurfaceHolder p0, com.eyes.SphereOpenGL.BubblePanel p1)
	{
		super ();
		if (getClass () == BubbleThread.class)
			mono.android.TypeManager.Activate ("SphereOpenGL.SurfaceViewPanel.BubbleThread, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.ISurfaceHolder, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:SphereOpenGL.SurfaceViewPanel.BubblePanel, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0, p1 });
	}


	public void run ()
	{
		n_run ();
	}

	private native void n_run ();

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
