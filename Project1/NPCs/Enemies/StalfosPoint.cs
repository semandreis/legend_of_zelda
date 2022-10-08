using System;
using Microsoft.Xna.Framework;
using Zelda.Interfaces;

namespace Zelda.NPCs.Enemies
{
    class StalfosPoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private readonly Random _random;
        private Vector2 _velocity;
        private int _timeSinceMovement = 0;
        private Vector2 _lastMove;
        private bool _start;

        public StalfosPoint(Vector2 point)
        {
            ObjectPoint = new Vector2(point.X, point.Y);
            _random = new Random();
            _velocity = new Vector2(0, 0);
            _start = true;
        }

        private void PickDirection(Vector2 velocity)
        {
            int Pick = _random.Next(4);
            switch (Pick)
            {
                case 0:
                    _velocity.X = velocity.X;
                    _velocity.Y = 0;
                    break;
                case 1:
                    _velocity.X = -velocity.X;
                    _velocity.Y = 0;
                    break;
                case 2:
                    _velocity.X = 0;
                    _velocity.Y = velocity.Y;
                    break;
                case 3:
                    _velocity.X = 0;
                    _velocity.Y = -velocity.Y;
                    break;
            }
        }

        public void Move(Vector2 velocity, GameTime gameTime)
        {
            _timeSinceMovement += gameTime.ElapsedGameTime.Milliseconds;

            if (_start)
            {
                PickDirection(velocity);
                _start = false;
            }

            if (_timeSinceMovement > NPCConstants.KeeseMovementTime)
            {
                _timeSinceMovement -= NPCConstants.KeeseMovementTime;
                PickDirection(velocity);
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
