using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FractalsLibrary
{
    // TODO: в отдельный файл
    interface IFractal
    {
        void Create();
        Bitmap FractalBitmap { get; set; }
    }

    // TODO: в отдельный файл
    // TODO: добавить недостающие реализации фракталов
    public abstract class FractalBase : IFractal
    {
        public FractalBase(int width, int height)
        {
            Width = width;
            Height = height;
            FractalBitmap = new Bitmap(Width, Height);
        }
        public int Width { get; set; }
        public int Height { get; set; }

        public abstract void Create();

        public Bitmap FractalBitmap { get; set; }
    }

    public class PifagorTree : FractalBase
    {
        public PifagorTree(int width, int height)
            : base(width, height)
        {
            //StartPoint = startPoint;
            //Iteration = iteration;
            //Angle = angle;
        }

        public Point StartPoint { get; set; }

        public double Iteration { get; set; }

        public double Angle { get; set; }

        public override void Create()
        {
            CreateTree(StartPoint, MathHelper.Angle90);
        }

        private void CreateTree(Point pOld, double angle)
        {
            if (Iteration > 2)
            {
                Iteration *= 0.7;

                // Считаем координаты для вершины-ребенка
                var xNew = (int)Math.Round(pOld.X + Iteration * Math.Cos(angle));
                var yNew = (int)Math.Round(pOld.Y - Iteration * Math.Sin(angle));
                var pNew = new Point(xNew, yNew);

                // Рисуем линию между вершинами
                DrawLine(pOld, pNew);

                // Переприсваеваем координаты
                pOld.X = xNew;
                pOld.Y = yNew;

                // Вызываем рекурсивную функцию для левого и правого ребенка
                CreateTree(pOld, angle + MathHelper.Angle45);
                CreateTree(pOld, angle - MathHelper.Angle30);
            }
        }

        private void DrawLine(Point p1, Point p2)
        {
            // graphics.DrawLine(pen, (float)pOld.X, (float)pOld.Y, (float)xnew, (float)ynew);
            // Строка выше, только для Bitmap

            // Вектор от p1 к p2
            // Окрасить пиксели в направлении вектора между точками в выбранный цвет
            // TODO: алгоритм построения линии
            this.FractalBitmap.SetPixel(p1.X, p2.Y, Color.Red);
        }
    }
}