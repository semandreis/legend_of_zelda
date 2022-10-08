using Microsoft.Xna.Framework;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Projectiles
{
    class CandlePoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private readonly Direction _direction;
        private Vector2 _velocity;

        public CandlePoint(Vector2 position, Direction direction)
        {
            ObjectPoint = position;
            _direction = direction;
            _velocity = new Vector2(0, 0);
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

        public void Move(Vector2 velocity, GameTime gameTime)
        {
            SetDirection(velocity);
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
