using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalsLibrary
{
    public class JuliaSet : FractalBase
    {
        public JuliaSet(int width, int height) : base(1024, 768)
        {
            Width = width;
            Height = height;
        }
        public int Width { get; set; }
        public int Height { get; set; }
        public override void Create()
        {
            CreateSet();
        }
        private void CreateSet()
        {
            // при каждой итерации, вычисляется znew = zold² + С
            // вещественная  и мнимая части постоянной C
            double cRe, cIm;
            // вещественная и мнимая части старой и новой
            double newRe, newIm, oldRe, oldIm;
            // Можно увеличивать и изменять положение
            double zoom = 1, moveX = 0, moveY = 0;
            //Определяем после какого числа итераций функция должна прекратить свою работу
            int maxIterations = 300;

            //выбираем несколько значений константы С, это определяет форму фрактала         Жюлиа
            cRe = -0.70176;
            cIm = -0.3842;
            //"перебираем" каждый пиксель
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    //вычисляется реальная и мнимая части числа z
                    //на основе расположения пикселей,масштабирования и значения позиции
                    newRe = 1.5 * (x - Width / 2) / (0.5 * zoom * Width) + moveX;
                    newIm = (y - Height / 2) / (0.5 * zoom * Height) + moveY;

                    //i представляет собой число итераций 
                    int i;
                    //начинается процесс итерации
                    for (i = 0; i < maxIterations; i++)
                    {
                        //Запоминаем значение предыдущей итерации
                        oldRe = newRe;
                        oldIm = newIm;

                        // в текущей итерации вычисляются действительная и мнимая части 
                        newRe = oldRe * oldRe - oldIm * oldIm + cRe;
                        newIm = 2 * oldRe * oldIm + cIm;

                        // если точка находится вне круга с радиусом 2 - прерываемся
                        if ((newRe * newRe + newIm * newIm) > 4) break;
                    }
                    DrawAndPaintPixel(i,x,y);
                }
        }
        private void DrawAndPaintPixel(int i, int x, int y)
        {
            //определяем цвета
            //pen.Color = Color.FromArgb(255, (i * 9) % 255, 0, (i * 9) % 255);
            //рисуем пиксель
            //this.FractalBitmap.SetPixel(x, y, pen);

        }
    }
}
