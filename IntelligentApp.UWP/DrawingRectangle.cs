using IntelligentApp.Models;
using IntelligentApp.Services;
using System.Collections.Generic;

[assembly: Xamarin.Forms.Dependency(typeof(IntelligentApp.UWP.DrawingRectangle))]
namespace IntelligentApp.UWP
{
    public class DrawingRectangle : IDrawingRectangle
    {
        public async void Draw(string imagePath, List<Rectangle> rectangles)
        {
            //var bytes = File.ReadAllBytes(imagePath);
            //var stream = bytes.AsBuffer().AsStream();
            //var decoder = BitmapDecoder.CreateAsync(BitmapDecoder.JpegDecoderId, stream.AsRandomAccessStream());
            //var softwareBitmap = decoder.GetResults();
        }
    }
}
