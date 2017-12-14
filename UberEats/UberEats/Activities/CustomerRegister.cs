
using Android.App;
using Android.OS;

namespace UberEats.Activities
{
    [Activity(Label = "CustomerRegister")]
    public class CustomerRegister : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CustomerRegister);

        }
    }
}
