using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TemplateList {
    public class ListAdapter : BaseAdapter<TableItem>
    {
        List<TableItem> items;
        Activity context;
        public ListAdapter(Activity context, List<TableItem> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override TableItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.listitem, null);
            view.FindViewById<TextView>(Resource.Id.text_name).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.text_description).Text = item.Description;
            return view;
        }
    }
}