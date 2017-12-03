﻿
using Android.App;
using Android.OS;
using Android.Widget;
using SQLite;
using System;
using System.IO;
using Environment = System.Environment;

namespace BloodPressureApp
{
    [Activity(Label = "Blood Pressure List")]
    public class BloodPressureList : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BloodPressureList);

            TextView txtBloodList = FindViewById<TextView>(Resource.Id.textView1);

            txtBloodList.Text = RetrieveBloodPressureMeasures();

        }

        private string RetrieveBloodPressureMeasures()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BPdatabase.db3");


            SQLiteConnection db = new SQLiteConnection(dbPath);
            TableQuery<BloodPressureMeasurement> table = db.Table<BloodPressureMeasurement>();
            string result = string.Empty;

            foreach (BloodPressureMeasurement item in table)
            {
                result += item + "\n";
            }

            Console.WriteLine(result);
            return result;
        }
    }
}