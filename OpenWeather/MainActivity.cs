using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using OpenWeatherN.Services;
using OpenWeatherN.ViewModel;
using Xamarin.Essentials;


namespace OpenWeather
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        MainViewModel mainViewModel;
        TextView result;
        EditText cityNameHolder;
        private ProgressBar progress;

        public MainActivity()
        {
            mainViewModel = new MainViewModel(new WeatherService());
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            progress = FindViewById<ProgressBar>(Resource.Id.progressbar);
            
            progress.Visibility = ViewStates.Invisible;
            Button goButton = FindViewById<Button>(Resource.Id.search_temp_button);
            result = FindViewById<TextView>(Resource.Id.temperature_result);
            cityNameHolder = FindViewById<EditText>(Resource.Id.cityName);
            result.Text = "";
            goButton.Click += GetTemperature;
        }


        private void GetTemperature(object sender, EventArgs eventArgs)
        {
            
            if (cityNameHolder.Text == string.Empty)
                return;
            View view = (View)sender;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                result.Text = "";
                mainViewModel.cityName = cityNameHolder.Text;
                mainViewModel.onWeatherEventHandler += onTemperatureresult;
                progress.Visibility = ViewStates.Visible;
                mainViewModel.getTemperature();
            }
            else
            {
                Snackbar.Make(view, "Sorry there is no active internet connection", Snackbar.LengthLong)
                    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            }
        }

        public void onTemperatureresult(WeatherArgs args)
        {
            if (args != null && args._weatherInfo != null && args._weatherInfo?.TemperatureInfo != null)
            {
                result.Text = "The weather is " + args._weatherInfo?.Weather[0]?.Description + " and the Temperature is " + args._weatherInfo?.TemperatureInfo?.Temp + " Kelvin" ;
            }
            else
            {
                Snackbar.Make(result, "Sorry there is an error.Please try again", Snackbar.LengthLong)
                   .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            }
            progress.Visibility = ViewStates.Invisible;
            mainViewModel.onWeatherEventHandler -= onTemperatureresult;

        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
