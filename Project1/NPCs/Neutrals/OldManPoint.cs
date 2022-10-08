using System;
using Microsoft.Xna.Framework;
using Zelda.Interfaces;

namespace Zelda.NPCs.Neutrals
{
    class OldManPoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private Vector2 _velocity;
        private Vector2 _lastMove;

        public OldManPoint(Vector2 point)
        {
            ObjectPoint = new Vector2(point.X, point.Y);
            _velocity = new Vector2(0, 0);
        }

        public void Move(Vector2 velocity, GameTime gameTime)
        {
            ObjectPoint = Vector2.Add(ObjectPoint, _velocity);
            _lastMove = _velocity;
        }

        public void UndoMove()
        {
            ObjectPoint = Vector2.Subtract(ObjectPoint, _lastMove);
        }
        public void TakeDamage()
        {

        }
    }
}
