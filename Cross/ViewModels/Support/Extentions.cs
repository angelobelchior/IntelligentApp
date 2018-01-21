using IntelligentApp.Models;

namespace Microsoft.ProjectOxford
{
    public static class RectangleMethods
    {
        //PQ caralho não padronizaram essa merda??
        //Porra véi... é uma estrutura que representa um retângulo...

        public static Rectangle ToRectangle(this Face.Contract.FaceRectangle rectangle)
            => new Rectangle
            {
                Height = rectangle.Height,
                Width = rectangle.Width,
                Left = rectangle.Left,
                Top = rectangle.Top
            };

        public static Rectangle ToRectangle(this Vision.Contract.FaceRectangle rectangle)
            => new Rectangle
            {
                Height = rectangle.Height,
                Width = rectangle.Width,
                Left = rectangle.Left,
                Top = rectangle.Top
            };

        public static Rectangle ToRectangle(this Vision.Contract.Rectangle rectangle)
            => new Rectangle
            {
                Height = rectangle.Height,
                Width = rectangle.Width,
                Left = rectangle.Left,
                Top = rectangle.Top
            };

        public static Rectangle ToRectangle(this Common.Rectangle rectangle)
            => new Rectangle
            {
                Height = rectangle.Height,
                Width = rectangle.Width,
                Left = rectangle.Left,
                Top = rectangle.Top
            };
    }
}