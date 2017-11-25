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

namespace Exercises
{
    [Activity(Label = "ListOfThingsActivity")]
    public class ListOfThingsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ListOfThingsLayout);
            var ourList = FindViewById<ListView>(Resource.Id.listView1);
            var carList = GenerateCars();    
            
            ourList.Adapter = new CustomAdapter(this,carList);
            ourList.ItemClick += OurList_ItemClick;
        }        

        private void OurList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Android.Widget.Toast.MakeText(this, "Vajutasid", Android.Widget.ToastLength.Short).Show();
        }

        private List<Car> GenerateCars()
        {
            var listOfCars = new List<Car>();
                                  
            var car1 = new Car();
            car1.Name = "Ferrari";
            car1.Model = "F2004";
            car1.Kw = 325;
            car1.ImageResourceId = Resource.Drawable.Lamborghini;
            listOfCars.Add(car1);
            
            var car2 = new Car();
            car2.Name = "Lamborghini";
            car2.Model = "Diablo";
            car2.Kw = 124;
            car2.ImageResourceId = Resource.Drawable.Lamborghini;
            listOfCars.Add(car2);

            var car3 = new Car();
            car3.Name = "BMW";
            car3.Model = "Z4";
            car3.Kw = 346;
            car3.ImageResourceId = Resource.Drawable.Lamborghini;
            listOfCars.Add(car3);

            var car4 = new Car();
            car4.Name = "Volkswagen";
            car4.Model = "Touareg";
            car4.Kw = 2;
            car4.ImageResourceId = Resource.Drawable.vw;
            listOfCars.Add(car4);

            var car5 = new Car();
            car5.Name = "Lada";
            car5.Model = "Niva";
            car5.Kw = 34;
            car5.ImageResourceId = Resource.Drawable.Lamborghini;
            listOfCars.Add(car5);

            var car6 = new Car();
            car6.Name = "Opel";
            car6.Model = "Insignia";
            car6.Kw = 63;
            car6.ImageResourceId = Resource.Drawable.Lamborghini;
            listOfCars.Add(car6);

            var car7 = new Car();
            car7.Name = "Skoda";
            car7.Model = "Fabia";
            car7.Kw = 25;
            car7.ImageResourceId = Resource.Drawable.Lamborghini;
            listOfCars.Add(car7);

            var car8 = new Car();
            car8.Name = "Alfa";
            car8.Model = "158";
            car8.Kw = 78;
            car8.ImageResourceId = Resource.Drawable.vw;
            listOfCars.Add(car8);

            var car9 = new Car();
            car9.Name = "Jaguar";
            car9.Model = "XF";
            car9.Kw = 700;
            car9.ImageResourceId = Resource.Drawable.vw;
            listOfCars.Add(car9);

            return listOfCars;
        }
    }
}