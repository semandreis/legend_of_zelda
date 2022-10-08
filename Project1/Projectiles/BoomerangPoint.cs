using Microsoft.Xna.Framework;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Projectiles
{
    class BoomerangPoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private readonly Direction _direction;
        private Vector2 _velocity;
        private bool _velocitySet;
        private readonly float _acceleration;
        public BoomerangPoint(Vector2 position, Direction direction, float acceleration)
        {
            ObjectPoint = position;
            _direction = direction;
            _velocity = new Vector2(0, 0);
            _velocitySet = false;
            _acceleration = acceleration;
        }

        private void SetDirection(Vector2 velocity)
        {
            switch (_direction)
            {
                case Direction.Down:
                    _velocity.X = 0;
                    _velocity.Y = velocity.Y;
                    break;
                case Direction.Left:
                    _velocity.X = -velocity.X;
                    _velocity.Y = 0;
                    break;
                case Direction.Right:
                    _velocity.X = velocity.X;
                    _velocity.Y = 0;
                    break;
                case Direction.Up:
                    _velocity.X = 0;
                    _velocity.Y = -velocity.Y;
                    break;
                default:
                    break;
            }
        }

        private void UpdateVelocity()
        {
            switch (_direction)
            {
                case Direction.Down:
                    _velocity.Y -= _acceleration;
                    break;
                case Direction.Left:
                    _velocity.X += _acceleration;
                    break;
                case Direction.Right:
                    _velocity.X -= _acceleration;
                    break;
                case Direction.Up:
                    _velocity.Y += _acceleration;
                    break;
                default:
                    break;
            }
        }

        public void Move(Vector2 velocity, GameTime gameTime)
        {
            if (!_velocitySet)
            {
                SetDirection(velocity);
                _velocitySet = true;
            }
            else
            {
                UpdateVelocity();
            }

            Vector2 positionUpdate = _velocity * gameTime.ElapsedGameTime.Milliseconds;
            ObjectPoint = Vector2.Add(ObjectPoint, positionUpdate);
        }

        public void UndoMove()
        {

        }
        public void TakeDamage()
        {

        }
    }
}
