
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using UberEats.Adapter;
using UberEats.Model;
using UberEats.Services;

namespace UberEats.Activities
{
    [Activity(Label = "Customer Dashboard")]
    public class CustomerDashboardActivity : Activity
    {

        public RecyclerView mRecyclerView;
        public ProductAdapter mAdapter;
        public List<Products> products = new List<Products>();
        public string uri = "http://10.0.2.2:8080/api/Product";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CustomerDashboard);

            FetchProducts fetchProduct = new FetchProducts(uri, this, products);
            fetchProduct.Execute();

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            LinearLayoutManager mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            // Plug in my adapter:
            mAdapter = new ProductAdapter(products, this);
            mRecyclerView.SetAdapter(mAdapter);



            mAdapter.ItemClick += OnItemClick;
        }

        void OnItemClick(object sender, int position)
        {
            int productNum = position + 1;
            Toast.MakeText(this, "This is photo number " + productNum, ToastLength.Short).Show();
        }
    }
}
