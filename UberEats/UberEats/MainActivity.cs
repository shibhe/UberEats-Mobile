using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using UberEats.Activities;
using System;

namespace UberEats
{
    [Activity(Label = "UberEats", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        Button btnLogin, showPopupMenu;
        TextView uberText;
        ImageView uberImg;
        Intent intent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnLogin = FindViewById<Button>(Resource.Id.userLogin);
            // btnCustReg = FindViewById<Button>(Resource.Id.custRegister);
            // btnRestReg = FindViewById<Button>(Resource.Id.resRegister);
            showPopupMenu = FindViewById<Button>(Resource.Id.showPopupMenu);


            btnLogin.Click += delegate
            {
                intent = new Intent(this, typeof(UserLogin));
                StartActivity(intent);
            };

            showPopupMenu.Click += (s, arg) =>
            {
                PopupMenu menu = new PopupMenu(this, showPopupMenu);
                menu.Inflate(Resource.Menu.userMenu);

                menu.MenuItemClick += (s1, arg1) =>
                {

                    if (arg1.Item.ItemId == Resource.Id.customer)
                    {
                        intent = new Intent(this, typeof(CustomerRegister));
                        StartActivity(intent);
                    }
                    else if (arg1.Item.ItemId == Resource.Id.driver)
                    {
                        intent = new Intent(this, typeof(DriverRegister));
                        StartActivity(intent);
                    }
                    else if (arg1.Item.ItemId == Resource.Id.restaurant)
                    {
                        intent = new Intent(this, typeof(RestaurantRegister));
                        StartActivity(intent);
                    }
                };
                menu.Show();
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            uberImg = FindViewById<ImageView>(Resource.Id.uberImg);
            uberText = FindViewById<TextView>(Resource.Id.uberText);

            Android.Animation.ObjectAnimator image = Android.Animation.ObjectAnimator.OfFloat(uberImg, "scaleX", 0.5f, 1f);
            image.SetDuration(900);

            Android.Animation.ObjectAnimator text = Android.Animation.ObjectAnimator.OfFloat(uberText, "scaleX", 0.4f, 1f);
            text.SetDuration(900);

            image.Start();
            text.Start();
        }


    }
}

