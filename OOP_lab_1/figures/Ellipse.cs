﻿using System.Drawing;

namespace OOP_lab_1
{
    public class Ellipse : DisplayObject
    {
        override public void Draw(Graphics g)
        {
            Color fillColor = Color.FromArgb(_fillColor[0], _fillColor[1], _fillColor[2]);
            Color borderColor = Color.FromArgb(_borderColor[0], _borderColor[1], _borderColor[2]);
            using (var pen = new Pen(borderColor, _borderSize))
            {
                using (var brush = new SolidBrush(fillColor))
                {
                    g.FillEllipse(brush, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                    g.DrawEllipse(pen, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                }
            }
        }
        
        public Ellipse(int X, int Y,int x1, int y1, int[] fillColor, int[] borderColor, int borderSize, int rx, int ry) : base(X, Y,x1, y1, fillColor, borderColor, borderSize)
        {
            _X2 = x1 + 2 * rx;
            _Y2 = y1 + 2 * ry;
            _outRectX1 = _X1 - borderSize / 2;
            _outRectY1 = _Y1 - borderSize / 2;
            _outRectX2 = _X1 + 2 * rx + borderSize / 2;
            _outRectY2 = _Y1 + 2 * ry + borderSize / 2;
            _inRectX1 =  _outRectX1 + borderSize;
            _inRectY1 = _outRectY1 + borderSize;
            _inRectX2 = _outRectX2 - borderSize;
            _inRectY2 = _outRectY2 - borderSize;
        }
    }
}