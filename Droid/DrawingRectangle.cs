using Android.Graphics;
using IntelligentApp.Models;
using IntelligentApp.Services;
using System.Collections.Generic;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(IntelligentApp.Droid.DrawingRectangle))]
namespace IntelligentApp.Droid
{
    public class DrawingRectangle : IDrawingRectangle
    {
        public void Draw(string imagePath, List<Rectangle> rectangles)
        {
            var bitmap = BitmapFactory.DecodeFile(imagePath);
            var workingBitmap = Bitmap.CreateBitmap(bitmap);
            var mutableBitmap = workingBitmap.Copy(Bitmap.Config.Argb8888, true);

            var canvas = new Canvas(mutableBitmap);
            var paint = new Paint
            {
                Color = Color.OrangeRed,
                StrokeWidth = 6,
            };
            paint.SetStyle(Paint.Style.Stroke);

            foreach (var r in rectangles)
            {
                var rect = new Rect(r.Left, r.Top, r.Width + r.Left, r.Height + r.Top);
                canvas.DrawRect(rect, paint);
            }

            canvas.Save();

            using (var fs = File.Open(imagePath, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                mutableBitmap.Compress(Bitmap.CompressFormat.Png, 90, fs);
                fs.Flush();
                fs.Close();
            }
        }
    }
}