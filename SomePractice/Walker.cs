using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePractice
{
    class Walker 
    {
        public float ChanceWalkerChangeDir { get; set; } = 0.5f;
        public float ChanceWalkerSpawn { get; set; } = 0.05f;
        public float ChanceWalkerDestoy { get; set; } = 0.1f;
        public Vector2d Direction { get; set; }
        public Vector2d Position { get; set; }
        public void SetRandomDirection(Random rnd)
        {
            int choice = rnd.Next(0, 4);
            switch (choice)
            {
                case 0:
                    Direction = Vector2d.Down;
                    break;
                case 1:
                    Direction = Vector2d.Up;
                    break;
                case 2:
                    Direction = Vector2d.Left;
                    break;
                default:
                    Direction = Vector2d.Right;
                    break;
            }
        }
        public void Move(Random rnd)
        {
            SetRandomDirection(rnd);
            
        }
        public bool Destroy(Random rnd)
        {
            if (rnd.NextDouble() < ChanceWalkerDestoy)
                return true;
            else
                return false;
        }
        public void ChangeDirection(Random rnd)
        {
            if (rnd.NextDouble() < ChanceWalkerChangeDir)
                SetRandomDirection(rnd);
        }

    }
}
