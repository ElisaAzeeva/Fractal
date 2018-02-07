using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalsLibrary
{
    public class BarnsleyFern: FractalBase
    {
        // private fields and constants
        // constructors
        // public properties and methods
        // private methods

        private readonly Random _rand;

        public BarnsleyFern(int width, int height)
            : base(width, height)
        {
        }

        private double _widthCoefficient = 0;
        private double _heightCoefficient = 0;


        // Задаем диапазон значений для точек
        private const float MinX = -6;
        private const float MaxX = 6;
        private const float MinY = 0.1f;
        private const float MaxY = 10;
        // Количество точек для отрисовки
        private const int PointNumber = 200000;
        // Массив коэффциентов вероятностей
        private float[] _probability = new float[4]
        {
            0.01f,
            0.06f,
            0.08f,
            0.85f
        };
        // TODO:  Float vs double!
        // Матрица коэффициентов
        private float[,] _funcCoef = new float[4, 6]
        {
            //a      b       c      d      e  f
            {0,      0,      0,     0.16f, 0, 0   }, // 1 функция
            {-0.15f, 0.28f,  0.26f, 0.24f, 0, 0.44f},// 2 функция
            {0.2f,  -0.26f,  0.23f, 0.22f, 0, 1.6f}, // 3 функция
            {0.85f,  0.04f, -0.04f, 0.85f, 0, 1.6f}  // 4 функция
        };

        public override void Create()
        {
            CreateInner();
        }

        private void CreateInner()
        {
            // будем начинать рисовать с точки (0, 0)
            float xtemp = 0, ytemp = 0;
            // переменная хранения номера функции для вычисления следующей точки
            int numF = 0;

            for (var i = 1; i <= PointNumber; i++)
            {
                // рандомное число от 0 до 1
                var num = _rand.NextDouble();
                // проверяем какой функцией воспользуемся для вычисления следующей точки
                for (var j = 0; j <= 3; j++)
                {
                    // если рандомное число оказалось меньше или равно
                    // заданного коэффициента вероятности,
                    // задаем номер функции
                    num -= _probability[j];
                    if (num <= 0)
                    {
                        numF = j;
                        break;
                    }
                }

                // вычисляем координаты
                var x = _funcCoef[numF, 0] * xtemp + _funcCoef[numF, 1] * ytemp + _funcCoef[numF, 4];
                var y = _funcCoef[numF, 2] * xtemp + _funcCoef[numF, 3] * ytemp + _funcCoef[numF, 5];

                // сохраняем значения для следующей итерации
                xtemp = x;
                ytemp = y;
                // вычисляем значение пикселя
                x = (int)(xtemp * _widthCoefficient + Width / 2);
                y = (int)(ytemp * _heightCoefficient);
                // устанавливаем пиксель в Bitmap
                this.FractalBitmap.SetPixel((int)x, (int)y, Color.LawnGreen);
            }
        }
    }
}
