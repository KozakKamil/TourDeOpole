using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Widget;
using System;
using TourDeOpole.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Xaml;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRender), new[] {typeof(VisualMarker.DefaultVisual)})]
namespace TourDeOpole.Droid.Renders
{
    internal class CustomEntryRender:EntryRenderer
    {
        public CustomEntryRender(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                Control.Background = null;
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);


                //Control.SetTextCursorDrawable(0);
                Control.SetTextCursorDrawable(Resource.Drawable.my_cursor);

            }
        }

    }
}
