
using System;
using System.Net.Http;
using Android.App;
using Android.OS;
using Android.Widget;
using UberEats.Model;

namespace UberEats.Activities
{
    [Activity(Label = "Login")]
    public class UserLogin : Activity
    {
        public string url = "http://127.0.0.1:8080/api/Customers?email=bridgetrsk%40gmail.com%20&password=1233";
        TextView text;
        HttpClient client;
        EditText txtE, txtP;
        Button btnLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.UserLogin);


        }

        //LOGGING IN BUTTON
        private void Login_Click(object sender, EventArgs e)
        {

           /** try
            {
                client = new HttpClient();

                DataAccess datA = new DataAccess();

                Customer cust = datA.GetCust(txtE.Text, txtP.Text);


                if (txtE.Text == cust.CustEmail && txtP.Text == cust.CustPassword)
                {
                    Toast.MakeText(this, "Welcome " + cust.CustName, ToastLength.Short).Show();
                    Intent ti = new Intent(this, typeof(RestaurantActivity));
                    StartActivity(ti);
                    this.OverridePendingTransition(Resource.Animation.abc_slide_in_top, Resource.Animation.abc_slide_out_bottom);
                }

                else if (String.IsNullOrEmpty(txtE.Text) && String.IsNullOrEmpty(txtP.Text))
                {
                    Toast.MakeText(this, "Please Provide Correct Information", ToastLength.Short).Show();
                }

                else
                {
                    Toast.MakeText(this, "Incorrect Login Details", ToastLength.Short).Show();
                    Intent ti = new Intent(this, typeof(RestaurantActivity));
                    StartActivity(ti);
                    this.OverridePendingTransition(Resource.Animation.abc_slide_in_top, Resource.Animation.abc_slide_out_bottom);
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }**/


        }
    }
}
