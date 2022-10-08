using System;
using Microsoft.Xna.Framework;
using Zelda.Interfaces;

namespace Zelda.NPCs.Neutrals
{
    class StaticFirePoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private Vector2 _velocity;

        public StaticFirePoint(Vector2 point)
        {
            ObjectPoint = new Vector2(point.X, point.Y);
            _velocity = new Vector2(0, 0);
        }

        public void Move(Vector2 velocity, GameTime gameTime)
        {
            ObjectPoint = Vector2.Add(ObjectPoint, _velocity);
        }

        public void UndoMove()
        {

        }
        public void TakeDamage()
        {

        }
    }
}
