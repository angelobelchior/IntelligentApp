using IntelligentApp.Models;
using System.Collections.Generic;

namespace IntelligentApp.Services
{
    public interface IDrawingRectangle
    {
        void Draw(string imagePath, List<Rectangle> rectangles);
    }
}