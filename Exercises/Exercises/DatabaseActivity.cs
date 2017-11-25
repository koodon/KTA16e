﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Exercises
{
    [Activity(Label = "DatabaseActivity")]
    public class DatabaseActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DatabaseLayout);

            //Andmebaasi asukoht
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_sqlite.db");            

            //Lisame andmebaasi ühe auto
            var car1 = new Car();
            car1.Name = "Ferrari";
            car1.Model = "F2004";
            car1.Kw = 325;
            car1.ImageResourceId = Resource.Drawable.Lamborghini;

            var car2 = new Car();
            car2.Name = "Audi";
            car2.Model = "A6";
            car2.Kw = 21;
            car2.ImageResourceId = Resource.Drawable.Lamborghini;

            var message = insertUpdateData(car1, pathToDatabase);
            var message2 = insertUpdateData(car2, pathToDatabase);


            //andmebaasist lugemine
            var connection = new SQLiteConnection(pathToDatabase);
            List<Car> carlist = new List<Car>();
            var query = connection.Table<Car>().Where(x => x.ID == 1);
            foreach(var car in query)
            {                
                carlist.Add(car);
            }
        }

        private string createDatabase(string path)
        {
            try
            {
                //Loome andmebaasi
                var connection = new SQLiteConnection(path);
                connection.CreateTable<Car>();
                return "Andmebaas loodud";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        private string insertUpdateData(Car data, string path)
        {
            try
            {
                var db = new SQLiteConnection(path);
                if (db.Insert(data) != 0)
                    db.Update(data);
                return "Ühe kirje andmed lisatud või uuendatud";                
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }


        private string insertUpdateAllData(List<Car> data, string path)
        {
            try
            {
                var db = new SQLiteConnection(path);
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