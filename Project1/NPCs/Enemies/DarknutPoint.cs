using System;
using Microsoft.Xna.Framework;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.NPCs.Enemies
{
    class DarknutPoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private Vector2 _lastMove;
        public Direction DarknutDirection;
        private Vector2 _velocity;

        public DarknutPoint(Vector2 point)
        {
            ObjectPoint = new Vector2(point.X, point.Y);
            _velocity = new Vector2(0, 0);
        }

        private void PickDirection(Vector2 velocity)
        {
            switch (DarknutDirection)
            {
                case Direction.Left:
                    _velocity.X = -velocity.X;
                    _velocity.Y = 0;
                    break;
                case Direction.Right:
                    _velocity.X = velocity.X;
                    _velocity.Y = 0;
                    break;
                default:
                    _velocity = Vector2.Zero;
                    break;
            }
        }

        public void Move(Vector2 velocity, GameTime gameTime)
        {
            PickDirection(velocity);
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
