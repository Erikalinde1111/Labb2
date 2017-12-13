
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Labb2
{
	[Activity(Label = "CreateReportsActivity")]
	public class CreateReportsActivity : Activity
	{
		private Button button2;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			SetContentView(Resource.Layout.TaxRate);
			base.OnCreate(savedInstanceState);
			button2 = FindViewById<Button>(Resource.Id.button2);

			button2.Click += delegate {
				Intent i = new Intent(this, typeof(TaxRateActivity));
				StartActivity(i);	
			};
			// Create your application here
		}


	}
}
