using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalsLibrary
{
    interface IDrawableShape
    {
        void DrawShape();
    }

    interface IDraw
    {
        void Draw(IDrawableShape shape);
    }

    class WindowFormsDrawer : IDraw
    {
        public void Draw(IDrawableShape shape)
        {
            // 1
            shape.DrawShape();

            // 2
            switch (shape.GetType())
            {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}