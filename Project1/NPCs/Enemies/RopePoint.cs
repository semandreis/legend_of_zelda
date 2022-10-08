using System;
using Microsoft.Xna.Framework;
using Zelda.Interfaces;

namespace Zelda.NPCs.Enemies
{
    class RopePoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private readonly Random _random;
        private Vector2 _lastMove;
        private Vector2 _velocity;
        private int _timeSinceMovement = 0;
        private bool _start;

        public RopePoint(Vector2 point)
        {
            ObjectPoint = new Vector2(point.X, point.Y);
            _random = new Random();
            _velocity = new Vector2(0, 0);
        }

        private void PickDirection()
        {
            int Pick = _random.Next(4);
            switch (Pick)
            {
                case 0:
                    _velocity.X = NPCConstants.RopeVelocity2.X;
                    _velocity.Y = -NPCConstants.RopeVelocity2.Y;
                    break;
                case 1:
                    _velocity.X = -NPCConstants.RopeVelocity1.X;
                    _velocity.Y = -NPCConstants.RopeVelocity1.Y;
                    break;
                case 2:
                    _velocity.X = NPCConstants.RopeVelocity1.X;
                    _velocity.Y = NPCConstants.RopeVelocity1.Y;
                    break;
                case 3:
                    _velocity.X = -NPCConstants.RopeVelocity2.X;
                    _velocity.Y = NPCConstants.RopeVelocity2.Y;
                    break;
            }
        }

        public void Move(Vector2 velocity, GameTime gameTime)
        {
            _timeSinceMovement += gameTime.ElapsedGameTime.Milliseconds;

            if (_start)
            {
                PickDirection();
                _start = false;
            }

            if (_timeSinceMovement > NPCConstants.KeeseMovementTime)
            {
                _timeSinceMovement -= NPCConstants.KeeseMovementTime;
                PickDirection();
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
