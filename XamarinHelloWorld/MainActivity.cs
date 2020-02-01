using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace XamarinHelloWorld
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView showCurrentDate;

        private void setCurrentDate()
        {
            string TodaysDate = string.Format("{0}",
               DateTime.Now.ToString("M/d/yyyy").PadLeft(2, '0'));
            showCurrentDate.Text = TodaysDate;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += delegate { button.Text = "Hello world I am your first App"; };

            CheckBox checkMe = FindViewById<CheckBox>(Resource.Id.checkBox1);
            checkMe.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
                CheckBox check = (CheckBox)sender;
                if (check.Checked)
                {
                    check.Text = "Checkbox is checked";
                }
                else
                {
                    check.Text = "Checkbox is not checked";
                }
            };

            ToggleButton togglebutton = FindViewById<ToggleButton>(Resource.Id.togglebutton);
            togglebutton.Click += (o, e) => {
                if (togglebutton.Checked)
                    Toast.MakeText(this, "Torch is ON", ToastLength.Short).Show();
                else
                    Toast.MakeText(this, "Torch is OFF",
                    ToastLength.Short).Show();
            };


            DatePicker pickDate = FindViewById<DatePicker>(Resource.Id.datePicker1);
            showCurrentDate = FindViewById<TextView>(Resource.Id.txtShowDate);
            setCurrentDate();
            Button dateButton = FindViewById<Button>(Resource.Id.btnSetDate);
            dateButton.Click += delegate {
                showCurrentDate.Text = String.Format("{0}/{1}/{2}",
                   pickDate.Month, pickDate.DayOfMonth, pickDate.Year);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}