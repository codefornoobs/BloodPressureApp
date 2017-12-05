using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
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
        private EditText _txtHighVolume,
            _txtLowVolume;


        private string _dbPath;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _txtHighVolume = FindViewById<EditText>(Resource.Id.txtHighVolume);
            _txtLowVolume = FindViewById<EditText>(Resource.Id.txtLowVolume);

            Button btnSave = FindViewById<Button>(Resource.Id.btnSave);
            Button btnListAll = FindViewById<Button>(Resource.Id.btnListAll);

            btnSave.Click += BtnSaveOnClick;
            btnListAll.Click += BtnListAllOnClick;

            _txtLowVolume.KeyPress += TxtLowVolumeOnEnterPress;

            _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BPdatabase.db3");

            _txtHighVolume.RequestFocus();
            _txtHighVolume.NextFocusDownId = _txtLowVolume.Id;


            SQLiteConnection db = new SQLiteConnection(_dbPath);
            db.CreateTable<BloodPressureMeasurement>();
            //db.DeleteAll<BloodPressureMeasurement>();
        }

        private void TxtLowVolumeOnEnterPress(object sender, View.KeyEventArgs eventArgs)
        {
            eventArgs.Handled = false;
            if (eventArgs.Event.Action == KeyEventActions.Down && eventArgs.KeyCode == Keycode.Enter)
            {
                eventArgs.Handled = true;
                BtnSaveOnClick(sender, eventArgs);
            }

        }

        private void BtnSaveOnClick(object sender, EventArgs eventArgs)
        {
            string toastMessage = $"Saved:\n  LP: {_txtLowVolume.Text}\n  HP: {_txtHighVolume.Text}";
            MakeToast.Show(this, toastMessage, ToastLength.Long);

            BloodPressureMeasurement newBPvalue = new BloodPressureMeasurement()
            {
                HighBloodPressure = _txtHighVolume.Text,
                LowBloodPressure = _txtLowVolume.Text,
                InsertDate = DateTime.Now
            };

            SQLiteConnection dBConnection = new SQLiteConnection(_dbPath);
            dBConnection.Insert(newBPvalue);

            _txtHighVolume.Text = _txtLowVolume.Text = "";
        }

        private void BtnListAllOnClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(BloodPressureList));
            StartActivity(intent);
        }
    }
}

