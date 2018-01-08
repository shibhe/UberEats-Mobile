using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Android.App;
using Android.Content;
using Android.OS;
using Java.Lang;
using Newtonsoft.Json;
using UberEats.Adapter;
using UberEats.Model;

namespace UberEats.Services
{
    public class FetchProducts : AsyncTask
    {
        string uri;
        Context context;
        public ProgressDialog progressBar;
        public ProductAdapter mAdapter;

        public FetchProducts(string uri,Context context)
        {
            this.uri = uri;
            this.context = context;
           // this.products = products;
        }

        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            HttpClient client = new HttpClient();

            Uri url = new Uri(uri);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(url).Result;
            var restaurant = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<Products>>(restaurant);

            foreach (var g in result)
            {
                mAdapter.products.Add(g);
            }

            return true;
        }

        protected override void OnPreExecute()
        {
            base.OnPreExecute();

            progressBar = new ProgressDialog(context);
            progressBar.SetCancelable(true);
            progressBar.SetMessage("Please Wait while loading products...");
            progressBar.SetProgressStyle(ProgressDialogStyle.Spinner);
            progressBar.Show();
        }

        protected override void OnPostExecute(Java.Lang.Object result)
        {
            base.OnPostExecute(result);
            progressBar.Cancel();
            //listView.Adapter = new ProImageAdapter(context, rest);
        }
    }
}
