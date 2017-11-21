using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using SQLite;
using System;
using System.IO;
using Environment = System.Environment;

namespace BloodPressureApp
{
    [Activity(Label = "Blood Pressure Save", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button _btnSave,
            _btnListAll;

        private EditText _txtHighVolume,
            _txtLowVolume;


        private string dbPath;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _btnSave = FindViewById<Button>(Resource.Id.btnSave);
            _btnListAll = FindViewById<Button>(Resource.Id.btnListAll);

            _txtHighVolume = FindViewById<EditText>(Resource.Id.txtHighVolume);
            _txtLowVolume = FindViewById<EditText>(Resource.Id.txtLowVolume);

            _btnSave.Click += BtnSaveOnClick;
            _btnListAll.Click += BtnListAllOnClick;

            dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BPdatabase.db3");

            var db = new SQLiteConnection(dbPath);

            db.CreateTable<BlodPressureMeasurement>();
        }

        private void BtnSaveOnClick(object sender, EventArgs eventArgs)
        {

            string toastMessage = $"Saved: \n  HP: {_txtHighVolume.Text}\n  LB: {_txtLowVolume.Text}";


            Toast SaveSuccess = Toast.MakeText(this, toastMessage, ToastLength.Long);
            SaveSuccess.Show();

            BlodPressureMeasurement BP = new BlodPressureMeasurement();
            BP.HighValue = _txtHighVolume.Text;
            BP.LowValue = _txtLowVolume.Text;
            BP.HeartRate = "55";
            BP.InsertDate = DateTime.Now;
            SQLiteConnection db = new SQLiteConnection(dbPath);

            db.Insert(BP);

            var table = db.Table<BlodPressureMeasurement>();

            foreach (var item in table)
            {
                Console.WriteLine(item);
            }
            _txtHighVolume.Text = _txtLowVolume.Text = "";

        }

        private void BtnListAllOnClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(BloodPressureList));
            StartActivity(intent);
        }
    }
}

