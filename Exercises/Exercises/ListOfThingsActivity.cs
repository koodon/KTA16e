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

            var items = new string[] {"Bmw", "Audi", "Ferrari", "Mercedes", "Lada"};
            ourList.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
        }
    }
}