package com.eyes.SphereOpenGL;


public class MyGLSurfaceView
	extends android.opengl.GLSurfaceView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SphereOpenGL.MyGLSurfaceView, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyGLSurfaceView.class, __md_methods);
	}


	public MyGLSurfaceView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MyGLSurfaceView.class)
			mono.android.TypeManager.Activate ("SphereOpenGL.MyGLSurfaceView, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public MyGLSurfaceView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MyGLSurfaceView.class)
			mono.android.TypeManager.Activate ("SphereOpenGL.MyGLSurfaceView, SphereOpenGL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}

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
