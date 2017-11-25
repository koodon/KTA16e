using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using SQLite;

namespace Exercises
{
    [Activity(Label = "DatabaseActivity")]
    public class DatabaseActivity : Activity
    {
        string pathToDatabase;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DatabaseLayout);

            //Otsime üles disainist nupud ja tekstiväljad
            var createTableButton = FindViewById<Button>(Resource.Id.button1);
            var addToDatabaseButton = FindViewById<Button>(Resource.Id.button2);
            var carNameEditText = FindViewById<EditText>(Resource.Id.editText1);
            var carModelEditText = FindViewById<EditText>(Resource.Id.editText2);
            var carKwEditText = FindViewById<EditText>(Resource.Id.editText3);
            var carListView = FindViewById<ListView>(Resource.Id.listView1);

            //Andmebaasi asukoht
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            pathToDatabase = System.IO.Path.Combine(docsFolder, "db_sqlite.db");

            //andmebaasist lugemine
            var carlist = updateCarList();
            carListView.Adapter = new CustomAdapter(this, carlist);

            addToDatabaseButton.Click += delegate
            {
                var car = new Car();
                car.Name = carNameEditText.Text;
                car.Model = carModelEditText.Text;
                car.Kw = int.Parse(carKwEditText.Text);
                car.ImageResourceId = Resource.Drawable.Lamborghini;
                insertUpdateData(car);
                carlist = updateCarList();
                carListView.Adapter = new CustomAdapter(this, carlist);
            };            
        }

        private List<Car> updateCarList()
        {
            var connection = new SQLiteConnection(pathToDatabase);
            var carlist = new List<Car>();
            var query = connection.Table<Car>();
            foreach (var i in query)
            {
                carlist.Add(i);
            }
            return carlist;
        }
        
        private string createDatabase()
        {
            try
            {
                //Loome andmebaasi
                var connection = new SQLiteConnection(pathToDatabase);
                connection.CreateTable<Car>();
                return "Andmebaas loodud";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        private string insertUpdateData(Car data)
        {
            try
            {
                var db = new SQLiteConnection(pathToDatabase);
                if (db.Insert(data) != 0)
                    db.Update(data);                
                return "Ühe kirje andmed lisatud või uuendatud";                
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }


        private string insertUpdateAllData(List<Car> data)
        {
            try
            {
                var db = new SQLiteConnection(pathToDatabase);
                if (db.InsertAll(data) != 0)
                    db.UpdateAll(data);
                return "Nimekiri andmeid lisatud või uuendatud";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
    }
}