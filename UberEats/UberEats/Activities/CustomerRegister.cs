
using System.Collections;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using UberEats.Model;

namespace UberEats.Activities
{
    [Activity(Label = "CustomerRegister")]
    public class CustomerRegister : Activity
    {

        public List<Customer> ListCustomer;
        public Customer customer;
        public EditText FirstName, LastName, PhoneNumber, Email, Password, CreditCard, CVV, ExpiryDate, ZipCode, UserRole;
        public Button register;
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

            register.Click += delegate {
                
                customer = new Customer
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


                ListCustomer = new List<Customer>
                {
                    customer
                };

                Toast.MakeText(this, "Successfully added", ToastLength.Long).Show();
                Toast.MakeText(this, customer.FirstName + " " + customer.LastName, ToastLength.Long).Show();
                intent = new Intent(this, typeof(UserLogin));
                StartActivity(intent);
                customer = new Customer();
            };
        }
    }
}
