using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using NavigationDrawerLayout.src.Interface;

namespace NavigationDrawerLayout.src.Activity
{
  public  class ProductListAdapter : RecyclerView.Adapter
    {
        String[] data;
        String[] prodImg;
        internal Action<object, int> ItemClick;
        public Context mContext;


        public ProductListAdapter(Context mContext, String[] prodImgData)
        {
 
            this.prodImg = prodImgData;
            this.mContext = mContext;
         
        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.listRow, parent, false);
            PhotoViewHolder vh = new PhotoViewHolder(itemView);
            return vh;
        }
        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder vh = holder as PhotoViewHolder;

            //image loading 
            var imageBitmap = GetImageBitmapFromUrl(prodImg[position % prodImg.Length]);
            vh.Image.SetImageBitmap(imageBitmap);
            // vh.Image.SetImageResource(mPhotoAlbum[position].PhotoID);
            // vh.Caption.Text = "data";

        }

        

        public override int ItemCount
        {
            get { return prodImg.Length; }
        }

       



    }
    class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image;
        public TextView Caption;
        public RowClick rowclick;

        public PhotoViewHolder(View itemView) : base(itemView)
        {
            // Locate and cache view references:
            Image = itemView.FindViewById<ImageView>(Resource.Id.type);
            itemView.Click += (sender, e) =>
            {
                var context = itemView.Context;
                var intent = new Intent(context, typeof(ProductDetail));
                context.StartActivity(intent);
                //   rowclick = (RowClick)mContext;
                //    rowclick.clickListner(1);


            };
        }

    }
}