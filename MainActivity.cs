using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace IncomePlanner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText incomePerHourEditText;
        EditText workHourPerDayEditText;
        EditText taxRateEditText;
        EditText savingRateEditText;

        TextView workSummaryTextView;
        TextView grossIncomeTextView;
        TextView taxPayableTextView;
        TextView annualSavingsTextView;
        TextView spendableIncomeTextView;

        Button calculateButtion;
        RelativeLayout resultLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            ConnectViews();
        }
        
        void ConnectViews()
        {
            incomePerHourEditText = FindViewById<EditText>(Resource.Id.incomePerHourEditText);
            workHourPerDayEditText = (EditText)FindViewById(Resource.Id.workHoursEditText);
            taxRateEditText = (EditText)FindViewById(Resource.Id.TaxRateEditText);
            savingRateEditText = (EditText)FindViewById(Resource.Id.savingsRateEditText);

            workSummaryTextView = (TextView)FindViewById(Resource.Id.workSummaryTextView);
            grossIncomeTextView = (TextView)FindViewById(Resource.Id.grossIncomeTextView);
            taxPayableTextView = (TextView)FindViewById(Resource.Id.taxPayableTextView);
            annualSavingsTextView = (TextView)FindViewById(Resource.Id.savingsTextView);
            spendableIncomeTextView = (TextView)FindViewById(Resource.Id.spendableIncomeTextView);

            calculateButtion = (Button)FindViewById(Resource.Id.calculateButton);
            resultLayout = (RelativeLayout)FindViewById(Resource.Id.resultLayout);

            calculateButtion.Click += CalculateButtion_Click;
        }

        private void CalculateButtion_Click(object sender, EventArgs e)
        {
            double incomePerHour = double.Parse(incomePerHourEditText.Text);
            double workHourPerDay = double.Parse(workHourPerDayEditText.Text);
            double taxRate = double.Parse(taxRateEditText.Text);
            double savingsRate = double.Parse(savingRateEditText.Text);

            // calculate Annual Tax  Icome Savings 
            double annualWorkHourSummary = workHourPerDay * 5 * 50;
            double annualIncome = incomePerHour * workHourPerDay * 5 * 50;
            double taxPayable = (taxRate / 100) * annualIncome;
            double annualSavings = (savingsRate / 100) * annualIncome;
            double spendableIcome = annualIncome - taxPayable - annualSavings;

            // Display result of the calculations 
            grossIncomeTextView.Text = annualIncome.ToString() + " USD";
            workSummaryTextView.Text = annualWorkHourSummary.ToString() + " HRS";
            taxPayableTextView.Text = taxPayable.ToString() + " USD";
            annualSavingsTextView.Text = annualSavings.ToString() + " USD";
            spendableIncomeTextView.Text = spendableIcome.ToString() + " USD";

            resultLayout.Visibility = Android.Views.ViewStates.Visible;
        }
    }
}