using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Exercises
{
    [Activity(Label = "Exercises", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var button1 = FindViewById<Button>(Resource.Id.button1);
            var button2 = FindViewById<Button>(Resource.Id.button2);
            var button3 = FindViewById<Button>(Resource.Id.button3);
            var button4 = FindViewById<Button>(Resource.Id.button4);
            var button5 = FindViewById<Button>(Resource.Id.button5);

            var textview1 = FindViewById<TextView>(Resource.Id.textView1);

            button1.Click += delegate
            {
                var secondActivity = new Intent(this, typeof(SecondActivity));
                secondActivity.PutExtra("MyData", "Hello World");
                StartActivity(secondActivity);                
            };

            button2.Click += delegate 
            {
                textview1.Text = "Tekst muutus";
            };

            button3.Click += delegate
            {
                var webviewActivity = new Intent(this, typeof(WebviewActivity));                
                StartActivity(webviewActivity);
            };

            button4.Click += delegate
            {
                var listviewActivity = new Intent(this, typeof(ListOfThingsActivity));
                StartActivity(listviewActivity);
            };

            button5.Click += delegate
            {
                var databaseActivity = new Intent(this, typeof(DatabaseActivity));
                StartActivity(databaseActivity);
            };
        }
    } 
}



