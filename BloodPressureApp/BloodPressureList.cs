
using Android.App;
using Android.OS;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
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

            ListView txtBloodList = FindViewById<ListView>(Resource.Id.listView1);

            IList<string> data = RetrieveBloodPressureMeasures();

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, data);

            txtBloodList.Adapter = adapter;

            txtBloodList.LongClick += (sender, args) =>
            {
                Console.WriteLine(sender);
                Console.WriteLine(args);
            };

        }

        private IList<string> RetrieveBloodPressureMeasures()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BPdatabase.db3");


            SQLiteConnection db = new SQLiteConnection(dbPath);
            TableQuery<BloodPressureMeasurement> table = db.Table<BloodPressureMeasurement>();
            IList<string> result = new List<string>();

            foreach (BloodPressureMeasurement item in table)
            {
                result.Add(item.ToString());
            }

            Console.WriteLine(result);
            return result;
        }
    }
}