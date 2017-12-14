using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using UberEats.Activities;

namespace UberEats
{
    [Activity(Label = "UberEats", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        Button btnLogin, btnRestReg, btnCustReg, btnDriverReg;
        Intent intent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnLogin = FindViewById<Button>(Resource.Id.userLogin);
            btnCustReg = FindViewById<Button>(Resource.Id.custRegister);
            btnRestReg = FindViewById<Button>(Resource.Id.resRegister);
            btnDriverReg = FindViewById<Button>(Resource.Id.driverRegister);


            btnLogin.Click += delegate {
                intent = new Intent(this, typeof(UserLogin));
                StartActivity(intent);
            };

            btnCustReg.Click += delegate {
                intent = new Intent(this, typeof(CustomerRegister));
                StartActivity(intent);
            };

            btnRestReg.Click += delegate {
                intent = new Intent(this, typeof(RestaurantRegister));
                StartActivity(intent);
            };

            btnDriverReg.Click += delegate {
                intent = new Intent(this, typeof(DriverRegister));
                StartActivity(intent);
            };
         
        }
    }
}

