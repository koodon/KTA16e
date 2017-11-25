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
using Java.Lang;

namespace Exercises
{
    public class CustomAdapter : BaseAdapter
    {
        List<Car> items;
        Activity context;

        public CustomAdapter(Activity context, List<Car> items) : base()
        {
            this.context = context;
            this.items = items;
        }       

        public override int Count
        {
            get { return items.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null; // could wrap a Contact in a Java.Lang.Object to return it here if needed
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = items[position].Name;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = items[position].Kw.ToString();
            view.FindViewById<TextView>(Resource.Id.Text3).Text = items[position].Model;
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(items[position].ImageResourceId);


            return view;
        }
    }
}