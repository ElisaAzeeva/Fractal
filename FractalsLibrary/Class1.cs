using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FractalsLibrary
{
    interface IFractal
    {
        void Create();
        Bitmap FractalBitmap { get; set; }
    }

    abstract class FractalBase : IFractal
    {
        public FractalBase(int width, int height)
        {
            FractalBitmap = new Bitmap(width, height);
        }
        public abstract void Create();

        public Bitmap FractalBitmap { get; set; }
    }

    public class PifagorTree : FractalBase
    {
        public PifagorTree(Point startPoint, double iteration, double angle) : base(1024, 768)
        {
            StartPoint = startPoint;
            Iteration = iteration;
            Angle = angle;
        }

        public const double Angle90 = Math.PI / 2;
        public const double Angle45 = Math.PI / 4;
        public const double Angle30 = Math.PI / 6;

        public Point StartPoint { get; set; }

        public double Iteration { get; set; }

        public double Angle { get; set; }

        public override void Create()
        {
            CreateTree(StartPoint, Angle90);
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
                CreateTree(pOld, angle + Angle45);
                CreateTree(pOld, angle - Angle30);
            }
        }

        private void DrawLine(Point p1, Point p2)
        {
            // graphics.DrawLine(pen, (float)pOld.X, (float)pOld.Y, (float)xnew, (float)ynew);
            // Строка выше, только для Bitmap

            // Вектор от p1 к p2
            // Окрасить пиксели в направлении вектора между точками в выбранный цвет
            this.FractalBitmap.SetPixel(p1.X, p2.Y, Color.Red);
        }
    }
}