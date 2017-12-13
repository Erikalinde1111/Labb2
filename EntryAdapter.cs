using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Labb2
{
	public class EntryAdapter : BaseAdapter
	{
		private Activity context;
		private List<Entry> entry_list;

		public EntryAdapter(Activity activity, List<Entry> entryList)
		{
			this.context = activity;
			this.entry_list = entryList;
		}

		public override int Count
		{
			get
			{
				return entry_list.Count;
			}
		}

		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view;
			if (convertView == null)
			{
				view = context.LayoutInflater.Inflate(Resource.Layout.LayoutEntry, parent, false);
			}
			else
			{
				view = convertView;
			}

			//view.FindViewById<TextView>(Resource.Id.idEntry).Text = entry_list[position].Id + " idE ";
			//view.FindViewById<TextView>(Resource.Id.idMoney).Text = entry_list[position].idMoneyAccount + " idM";
			//view.FindViewById<TextView>(Resource.Id.idType).Text = entry_list[position].idTypeAccount + " idTy";
			//view.FindViewById<TextView>(Resource.Id.idTaxrate).Text = entry_list[position].idTaxrate + " idT";
			//view.FindViewById<TextView>(Resource.Id.isIncome).Text = entry_list[position].isIncome + " ic?";
			view.FindViewById<TextView>(Resource.Id.date).Text = entry_list[position].date + "";
			view.FindViewById<TextView>(Resource.Id.description).Text = entry_list[position].desciption + "";
			view.FindViewById<TextView>(Resource.Id.total).Text = entry_list[position].total + " kr";

			return view;
		}
	}
}
