using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using UberEats.Model;

namespace UberEats.Adapter
{
    public class ProductAdapter : RecyclerView.Adapter
    {
        public List<Products> products = new List<Products>();

        public Context context;
        public event EventHandler<int> ItemClick;

        public ProductAdapter(List<Products> products, Context context)
        {
            this.products = products;
            this.context = context;

        }

        public override int ItemCount => products.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ProductViewHolder vh = holder as ProductViewHolder;

            vh.ProductImg.SetImageBitmap(BitmapFactory.DecodeByteArray(products[position].ItemImage, 0, products[position].ItemImage.Length));
            vh.ProductName.Text = products[position].ItemName + " - " + products[position].Description;
            vh.ProductPrice.Text = Convert.ToString(products[position].ItemPrice);
            vh.ProductType.Text = products[position].ItemType;

        }

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(context).
                            Inflate(Resource.Layout.CustomerCardView, parent, false);
            ProductViewHolder vh = new ProductViewHolder(itemView, OnClick);
            return vh;
        }

        public class ProductViewHolder : RecyclerView.ViewHolder
        {

            public ImageView ProductImg { get; private set; }
            public TextView ProductName { get; private set; }
            public TextView ProductPrice { get; private set; }
            public TextView ProductType { get; private set; }
             
            public ProductViewHolder(View itemView, Action<int> listener) : base(itemView)
            {
                // Locate and cache view references:
                ProductImg = itemView.FindViewById<ImageView>(Resource.Id.productImg);
                ProductName = itemView.FindViewById<TextView>(Resource.Id.productName);
                ProductPrice = itemView.FindViewById<TextView>(Resource.Id.productPrice);
                ProductType = itemView.FindViewById<TextView>(Resource.Id.productType);

                itemView.Click += (sender, e) => listener(LayoutPosition);
            }
        }
    }
}
