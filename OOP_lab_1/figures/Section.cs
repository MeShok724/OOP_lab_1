﻿using System;
using System.Drawing;

namespace OOP_lab_1
{
    public class Section : DisplayObject
    {
        private int _diffX;
        private int _diffY;
        private readonly int _width;

        override public void Draw(Graphics g)
        {
            Color fillColor = Color.FromArgb(_fillColor[0], _fillColor[1], _fillColor[2]);
            Color borderColor = Color.FromArgb(_borderColor[0], _borderColor[1], _borderColor[2]);
            using (var pen = new Pen(borderColor, _borderSize + _width))
            {
                using (var penFill = new Pen(fillColor, _width - _borderSize))
                {
                    g.DrawLine(pen, _X1, _Y1, _X2, _Y2);
                    g.DrawLine(penFill,_X1 + _diffX, _Y1 + _diffY, _X2 - _diffX, _Y2 - _diffY);
                }
            }
        }

        private void FindDiff()
        {
            double dist = Math.Sqrt(Math.Pow(_X2 - _X1, 2) + Math.Pow(_Y2 - _Y1, 2));
            double k = Math.Round(dist / _borderSize);
            _diffX = (int)Math.Round((_X2 - _X1) / k);
            _diffY = (int)Math.Round((_Y2 - _Y1) / k);
            
            //?
            _diffX = Math.Abs(_diffX);
            _diffY = Math.Abs(_diffY);
            if (_X2 - _X1 < 0)
            {
                _diffX = -_diffX;
            } 
            if (_Y2 - _Y1 < 0)
            {
                _diffY = -_diffY;
            }
        }
        
        public Section(int X, int Y, int x1, int y1, int[] fillColor, int[] borderColor, int borderSize, int x2, int y2, int width) : base(X, Y, x1, y1, fillColor, borderColor, borderSize)
        {
            _X2 = x2;
            _Y2 = y2;
            _outRectX1 = Math.Min(_X1, _X2) - borderSize / 2;
            _outRectY1 = Math.Min(_Y1, _Y2) - borderSize / 2;
            _outRectX2 = Math.Max(_X1, _X2) + borderSize / 2;
            _outRectY2 = Math.Max(_Y1, _Y2) + borderSize / 2;
            _inRectX1 =  _outRectX1 + borderSize;
            _inRectY1 = _outRectY1 + borderSize;
            _inRectX2 = _outRectX2 - borderSize;
            _inRectY2 = _outRectY2 - borderSize;
            _width = width;
            FindDiff();
        }
    }
}