using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace LuckyNumber
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        SeekBar seekbar;
        TextView textview;
        Button rollButton;
        TextView currentNumber;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            seekbar = FindViewById<SeekBar>(Resource.Id.seekBar);
            textview = FindViewById<TextView>(Resource.Id.resultTextView);
            rollButton = FindViewById<Button>(Resource.Id.button1);
            currentNumber = FindViewById<TextView>(Resource.Id.textView2);
            seekbar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) =>
            {
                if (e.FromUser)
                {
                    currentNumber.Text = string.Format("Current number is {0}", e.Progress);
                }
            };
            rollButton.Click += RollButton_Click;
                
             
        }

        private void RollButton_Click(object sender, System.EventArgs e)
        {
            Random random = new Random();
            int luckyNumber = random.Next(1, seekbar.Progress + 1);
            textview.Text = $"{luckyNumber}";
        }
    }
}