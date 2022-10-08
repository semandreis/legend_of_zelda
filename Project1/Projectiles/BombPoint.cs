using Microsoft.Xna.Framework;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Projectiles
{
    class BombPoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private readonly Direction _direction;
        private Vector2 _velocity;
        private Vector2 _space;

        public BombPoint(Vector2 position, Direction direction)
        {
            ObjectPoint = position;
            _direction = direction;
            _velocity = new Vector2(0, 0);
            SetDirection();
        }

        private void SetDirection()
        {
            switch (_direction)
            {
                case Direction.Down:
                    _space = new Vector2(0, 100);

                    break;
                case Direction.Left:
                    _space = new Vector2(-100, 0);

                    break;
                case Direction.Right:
                    _space = new Vector2(100, 0);

                    break;
                case Direction.Up:
                    _space = new Vector2(0, -100);
                    break;
                default:
                    break;
            }
            ObjectPoint = Vector2.Add(ObjectPoint, _space);
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
