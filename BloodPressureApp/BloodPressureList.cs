
using Android.App;
using Android.OS;

namespace BloodPressureApp
{
    [Activity(Label = "BloodPressureList")]
    public class BloodPressureList : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BloodPressureList);
        }
    }
}