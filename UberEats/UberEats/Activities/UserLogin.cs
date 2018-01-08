
using System;
using System.Net.Http;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using UberEats.Model;

namespace UberEats.Activities
{
    [Activity(Label = "Login")]
    public class UserLogin : Activity
    {
        // public string url = "http://127.0.0.1:8080/api/Customers?email=bridgetrsk%40gmail.com%20&password=1233";
        HttpClient client;
        EditText txtEmail, txtPassword;
        Button btnLogin;
        Intent intent;
        Customer customer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.UserLogin);

            txtEmail = FindViewById<EditText>(Resource.Id.username);
            txtPassword = FindViewById<EditText>(Resource.Id.password);
            btnLogin = FindViewById<Button>(Resource.Id.email_sign_in_button);

            btnLogin.Click += Login_Click;
        }

        //LOGGING IN BUTTON
        protected void Login_Click(object sender, EventArgs e)
        {
            
            string url = "http://10.0.2.2:8080/api/Customers?email=" + txtEmail.Text + "&password=" + txtPassword.Text + "";
            client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            customer = new Customer();
            customer = JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result);

            if (string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtPassword.Text))
            {
                Toast.MakeText(this, "Enter Email and Password", ToastLength.Short).Show();
            }

            if (customer != null)
            {
                Toast.MakeText(this, "Successfully logged as  " + customer.Email, ToastLength.Short).Show();
                intent = new Intent(this, typeof(CustomerDashboardActivity));
                intent.PutExtra("id", customer.Id);
                intent.PutExtra("email", customer.Email);
                intent.PutExtra("firstName", customer.FirstName);
                intent.PutExtra("lastName", customer.LastName);
                StartActivity(intent);
            }
            else
            {
                
                Toast.MakeText(this, "User does not exist in our database , please register", ToastLength.Short).Show();
            }



        }
    }
}
