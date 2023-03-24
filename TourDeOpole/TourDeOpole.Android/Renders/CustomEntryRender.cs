using Android.Content;
using TourDeOpole.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

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
                
            }
        }

    }
}