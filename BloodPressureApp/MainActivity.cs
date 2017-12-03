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

            _txtLowVolume.KeyPress += (sender, e) =>
            {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    e.Handled = true;
                    BtnSaveOnClick(sender, e);
                    //add your logic here

                }
            };

            dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BPdatabase.db3");

            _txtHighVolume.RequestFocus();
            _txtHighVolume.NextFocusDownId = _txtLowVolume.Id;


            SQLiteConnection db = new SQLiteConnection(dbPath);
            db.CreateTable<BloodPressureMeasurement>();
            //db.DeleteAll<BloodPressureMeasurement>();
        }

        private void BtnSaveOnClick(object sender, EventArgs eventArgs)
        {

            SQLiteConnection db = SaveAction();

            TableQuery<BloodPressureMeasurement> table = db.Table<BloodPressureMeasurement>();

            string result = String.Empty;
            foreach (BloodPressureMeasurement item in table)
            {
                Console.WriteLine(item);
            }
            _txtHighVolume.Text = _txtLowVolume.Text = "";

        }

        private SQLiteConnection SaveAction()
        {
            string toastMessage = $"Saved: \n  HP: {_txtHighVolume.Text}\n  LB: {_txtLowVolume.Text}";

            Toast SaveSuccess = Toast.MakeText(this, toastMessage, ToastLength.Long);
            SaveSuccess.Show();

            BloodPressureMeasurement BP = new BloodPressureMeasurement();
            BP.HighValue = _txtHighVolume.Text;
            BP.LowValue = _txtLowVolume.Text;
            BP.InsertDate = DateTime.Now;
            SQLiteConnection db = new SQLiteConnection(dbPath);

            db.Insert(BP);
            return db;
        }

        private void BtnListAllOnClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(BloodPressureList));
            StartActivity(intent);
        }
    }
}

