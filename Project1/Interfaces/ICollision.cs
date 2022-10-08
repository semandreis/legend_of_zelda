using System;
using System.Collections.Generic;
using System.Text;

namespace Zelda.Collisions
{
    public interface ICollision
    {
        void LeftCollision();
        void RightCollision();
        void TopCollision();
        void BottomCollision();
        void NoCollision();



    }
}
