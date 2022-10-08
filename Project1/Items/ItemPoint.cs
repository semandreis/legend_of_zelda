using System;
using Microsoft.Xna.Framework;
using Zelda.Interfaces;

namespace Zelda.Items
{
    class ItemPoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }

        public ItemPoint(Vector2 position)
        {
            ObjectPoint = position;
        }

        public void Move(Vector2 velocity, GameTime gameTime)
        {

        }

        public void UndoMove()
        {

        }
        public void TakeDamage()
        {

        }
    }
}
