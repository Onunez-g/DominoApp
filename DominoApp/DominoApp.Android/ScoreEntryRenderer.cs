using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DominoApp.Controls;
using DominoApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ScoreEntry), typeof(ScoreEntryRenderer))]
namespace DominoApp.Droid
{
    class ScoreEntryRenderer : EntryRenderer
    {
        public ScoreEntryRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(Android.Graphics.Color.ParseColor("#043353"));
                gd.SetCornerRadius(15);
                gd.SetStroke(2, Android.Graphics.Color.ParseColor("#FAF8F0"));
                Control.SetPadding(30, 5, 5, 0);
                Control.Background = gd;
                Control.TextAlignment = Android.Views.TextAlignment.ViewEnd;
                Control.SetTextColor(Android.Graphics.Color.ParseColor("#FAF8F0"));
                Control.SetHintTextColor(Android.Graphics.Color.ParseColor("#E44652"));
            }
        }
    }
}