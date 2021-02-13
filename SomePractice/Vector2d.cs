using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePractice
{
    class Vector2d
    {
        public int X { get;  set; }
        public int Y { get;  set; }

        public static Vector2d Up 
        { 
            get { return new Vector2d(0, 1); }
            private set { } 
        }
        public static Vector2d Down
        {
            get { return new Vector2d(0, -1); }
            private set { }
        }
        public static Vector2d Left
        {
            get { return new Vector2d(-1, 0); }
            private set { }
        }
        public static Vector2d Right
        {
            get { return new Vector2d(1, 0); }
            private set { }
        }
        public Vector2d(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static Vector2d operator +(Vector2d op1, Vector2d op2)
        {
            return new Vector2d(op1.X + op2.X, op1.Y + op2.Y);
        }
        public static Vector2d operator -(Vector2d op1, Vector2d op2)
        {
            return new Vector2d(op1.X - op2.X, op1.Y - op2.Y);
        }
    }
}
