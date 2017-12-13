using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;


namespace Labb2
{
	
	[Activity(Label = "Bookkeeper", MainLauncher = true)]
	public class MainActivity : Activity
	{
		private Button button1;
		private Button button2;
		private Button button3;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

		
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			button1 = FindViewById<Button>(Resource.Id.button1);
			button2 = FindViewById<Button>(Resource.Id.button2);
			button3 = FindViewById<Button>(Resource.Id.button3);

			button1.Click += delegate {
				Intent i = new Intent(this, typeof(NewEvent));
				StartActivity(i);
			};

			button2.Click += delegate {
				Intent i = new Intent(this, typeof(Entries));
				StartActivity(i);
			};

			button3.Click += delegate {
				Intent i = new Intent(this, typeof(CreateReportsActivity));
				StartActivity(i);
			};


		}
	}
}

