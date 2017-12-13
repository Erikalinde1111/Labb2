
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
	[Activity(Label = "New Entry")]
	public class NewEvent : Activity
	{
		private RadioButton incomeButton;
		private RadioButton outcomeButton;
		private Spinner typeOfAccountSpinner;
		private Spinner moneyAccountsSpinner;
		private Spinner taxRatesSpinner;
		private ArrayAdapter adapter;
		private ArrayAdapter adapter2;
		private ArrayAdapter adapter3;
		private Button button;
		private Account type;
		private Account money;
		private TaxRate taxRate;
		private string date;
		private string desc;
		private EditText number;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			SetContentView(Resource.Layout.NewEvent);
			base.OnCreate(savedInstanceState);
			typeOfAccountSpinner = FindViewById<Spinner>(Resource.Id.spinner1);
			incomeButton = FindViewById<RadioButton>(Resource.Id.radioInkomst);
			outcomeButton = FindViewById<RadioButton>(Resource.Id.radioUtgift);
			moneyAccountsSpinner = FindViewById<Spinner>(Resource.Id.spinner2);
			taxRatesSpinner = FindViewById<Spinner>(Resource.Id.spinner3);
			button = FindViewById<Button>(Resource.Id.button1);

			number = FindViewById<EditText>(Resource.Id.editText3);

			adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, BookkeeperManager.Instance.OutcomeAccounts);
			adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			typeOfAccountSpinner.Adapter = adapter;

			adapter2 = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, BookkeeperManager.Instance.MoneyAccounts);
			adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			moneyAccountsSpinner.Adapter = adapter2;

			adapter3 = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, BookkeeperManager.Instance.Taxrates);
			adapter3.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			taxRatesSpinner.Adapter = adapter3;

			incomeButton.Click += toggleTypeOfAccount;
			outcomeButton.Click += toggleTypeOfAccount;

			button.Click += setEntryVal;
				//nedan funkar inte med spinner
				/*typeOfAccountSpinner.ItemClick += (sender, args) =>
				{
					type = ((ArrayAdapter<Account>)typeOfAccountSpinner.Adapter).GetItem((int)args.Id);
				};*/
				//typeOfAccountSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(callback);
				//läs in ifrån xml skall bli properties till entryt som skapas nedan
		}
		private void setEntryVal(object sender, EventArgs e)
		{
			bool income;
			type = (Account)typeOfAccountSpinner.SelectedItem;
			money = (Account)moneyAccountsSpinner.SelectedItem;
			taxRate = (TaxRate)taxRatesSpinner.SelectedItem;
			int amount = int.Parse(number.Text);
			desc = FindViewById<EditText>(Resource.Id.editDesc).Text;
			date = FindViewById<EditText>(Resource.Id.editDatum).Text;

			//if (type.typeOfAccount.Equals("Inkomst"))
			if(incomeButton.Checked)
			{
				income = true;
			}
			else
			{
				income = false;
			}
			//sätt det nya entryt till sina properties där id skall ändras 
			Entry eg = new Entry() {
				idTypeAccount = type.Id,
				idMoneyAccount = money.Id,
				idTaxrate = taxRate.Id,
				TaxRate = taxRate.Moms,
				isIncome = income,
				date = date,
				desciption = desc,
				total = amount
			};
			Console.WriteLine(eg.idTaxrate);
			BookkeeperManager.Instance.AddEntry(eg);
		}


		private void toggleTypeOfAccount(object sender, EventArgs e)
		{
			if (incomeButton.Checked)
			{
				//skall en lista med alla incomeaccountsnames skrivas ut i spinnern
				adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, BookkeeperManager.Instance.IncomeAccounts);
				adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
				typeOfAccountSpinner.Adapter = adapter;
			}
			else
			{
				//skall en lista med alla outcomeaccountsnames skrivas ut i spinnern
				adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, BookkeeperManager.Instance.OutcomeAccounts);
				adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
				typeOfAccountSpinner.Adapter = adapter;
			}

		}


	}
}
