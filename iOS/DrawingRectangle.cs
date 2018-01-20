using System;
using System.Collections.Generic;
using IntelligentApp.Models;
using IntelligentApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(IntelligentApp.iOS.DrawingRectangle))]
namespace IntelligentApp.iOS
{
    public class DrawingRectangle : IDrawingRectangle
    {
        public void Draw(string imagePath, List<Rectangle> rectangles)
        {
        }
    }
}