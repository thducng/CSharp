using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AppMockUpTest
{
	[Activity (Label = "AppMockUpTest", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			MakeScreen (Resource.Layout.LOSecondScreen);

		}
	

		public void MakeScreen(int LO){
			SecondScreen.LOid = LO;

			Intent intent = new Intent (this, typeof(SecondScreen));
			StartActivity (intent);
		}

	}
}


