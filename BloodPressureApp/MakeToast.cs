using Android.Content;
using Android.Widget;

namespace BloodPressureApp
{
    public static class MakeToast
    {
        public static void Show(Context context, string toastMessage, ToastLength toastLength)
        {
            Toast saveSuccess = Toast.MakeText(context, toastMessage, toastLength);
            saveSuccess.Show();
        }
    }
}