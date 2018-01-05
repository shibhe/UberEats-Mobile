using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using UberEats.Model;

namespace UberEats.Activities
{
    [Activity(Label = "Customer Register")]
    public class CustomerRegister : Activity
    {
        public string url = "http://10.0.2.2:8080/api/Customers";
        public HttpClient client;
        public EditText FirstName, LastName, PhoneNumber, Email, Password, CreditCard, CVV, ExpiryDate, ZipCode, UserRole;
        public Button register, signIn;
        public Intent intent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CustomerRegister);

            FirstName = FindViewById<EditText>(Resource.Id.firstName);
            LastName = FindViewById<EditText>(Resource.Id.lastName);
            PhoneNumber = FindViewById<EditText>(Resource.Id.phoneNumber);
            Email = FindViewById<EditText>(Resource.Id.email);
            Password = FindViewById<EditText>(Resource.Id.password);
            CreditCard = FindViewById<EditText>(Resource.Id.creditCard);
            CVV = FindViewById<EditText>(Resource.Id.cvv);
            ExpiryDate = FindViewById<EditText>(Resource.Id.expiryDate);
            ZipCode = FindViewById<EditText>(Resource.Id.zipCode);
            register = FindViewById<Button>(Resource.Id.registerCust);
            signIn = FindViewById<Button>(Resource.Id.btn_reset_password);

            register.Click += Insert_Click;

            signIn.Click += delegate {
                intent = new Intent(this, typeof(UserLogin));
                StartActivity(intent);
            };
           
        }

        public async void Insert_Click(object sender, EventArgs e)
        {

            try
            {
                client = new HttpClient();

                var customer = new Customer
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    PhoneNumber = PhoneNumber.Text,
                    Email = Email.Text,
                    Password = Password.Text,
                    CreditCard = CreditCard.Text,
                    CVV = CVV.Text,
                    ExpiryDate = ExpiryDate.Text,
                    ZipCode = ZipCode.Text,
                    UserRole = "Customer"

                };


                var uri = new Uri(string.Format(url));
                var json = JsonConvert.SerializeObject(customer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Customer custs = JsonConvert.DeserializeObject<Customer>(data);
                    Toast.MakeText(this, "You are now registered", ToastLength.Long).Show();
                    intent = new Intent(this, typeof(UserLogin));
                    StartActivity(intent);
                    this.OverridePendingTransition(Resource.Animation.abc_slide_in_top, Resource.Animation.abc_slide_out_bottom);

                }
            }
            catch (Exception ex)
            {
                
                Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();

            }

        }
    }
}
