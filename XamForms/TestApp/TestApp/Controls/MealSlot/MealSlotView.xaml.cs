using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace TestApp.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MealSlotView : ContentView
	{
		public MealSlotView ()
		{
			InitializeComponent ();
		}

        SKPath plusPath = SKPath.ParseSvgPathData(
            "M 400 400 H 800" +
            "M 600 400" +
            "M 600 400" +
            "M 600 600 V 200" +
            "M 50 200 V 50 H 200" +
            "M 600 400" +
            "M 1000 50 H 1150 V 200" +
            "M 600 400" +
            "M 600 400" +
            "M 1150 600 V 750 H 1000" +
            "M 600 400" +
            "M 200 750 H 50 V 600"
            );


        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Gray.ToSKColor(),
                StrokeWidth = 30
            };

            canvas.Clear();

            SKRect bounds;
            plusPath.GetBounds(out bounds);

            canvas.Translate(info.Width / 2, info.Height / 2);

            canvas.Scale(0.9f * (info.Width / bounds.Width), 0.9f * (info.Height / bounds.Height));
            //canvas.Scale(0.9f);

            canvas.Translate(-bounds.MidX, -bounds.MidY);

            canvas.DrawPath(plusPath, paint);

            //canvas.DrawCircle(info.Width / 2, info.Height / 2, 0.45f * info.Width, paint);
            //paint.Style = SKPaintStyle.Fill;
            //paint.Color = SKColors.Blue;
            //canvas.DrawCircle(info.Width / 2, info.Height / 2, 0.45f * info.Width, paint);






        }
    }
}