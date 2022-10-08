using System;
using Microsoft.Xna.Framework;
using Zelda.Interfaces;

namespace Zelda.NPCs.Bosses
{
    class DodongoPoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private Vector2 _lastMove;
        private Vector2 _velocity;
        private float _timer;

        public DodongoPoint(Vector2 point)
        {
            ObjectPoint = new Vector2(point.X, point.Y);
            _velocity = new Vector2(0, 0);
            _timer = 0;
        }

        private void FlipDirection()
        {
            _velocity.X = -_velocity.X;
        }

        public void Move(Vector2 velocity, GameTime gameTime)
        {
            if (_velocity == Vector2.Zero)
            {
                _velocity = -velocity;
            }

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer >= NPCConstants.DodongoMovementTime)
            {
                FlipDirection();
                _timer = 0;
            }

            ObjectPoint = Vector2.Add(ObjectPoint, _velocity);
            _lastMove = _velocity;
        }

        public void UndoMove()
        {
            ObjectPoint = Vector2.Subtract(ObjectPoint, _lastMove);
        }
        public void TakeDamage()
        {
            while (!_velocity.Equals(Vector2.Zero))
                _velocity /= 2;
        }
    }
}
