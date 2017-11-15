using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace BloodPressureApp
{
    [Activity(Label = "Blood Pressure Save", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button _btnSave,
            _btnListAll;

        private EditText _txtHighVolume,
            _txtLowVolume;
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
        }

        private void BtnSaveOnClick(object sender, EventArgs eventArgs)
        {

            string toastMessage = $"Saved: \n  HP: {_txtHighVolume.Text}\n  LB: {_txtLowVolume.Text}";
            _txtHighVolume.Text = _txtLowVolume.Text = "";

            Toast SaveSuccess = Toast.MakeText(this, toastMessage, ToastLength.Long);
            SaveSuccess.Show();
        }

        private void BtnListAllOnClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(BloodPressureList));
            StartActivity(intent);
        }
    }
}

