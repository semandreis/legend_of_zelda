using Microsoft.Xna.Framework;
using Zelda.Interfaces;

namespace Zelda.NPCs.Enemies
{
    class TrapPoint4 : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private Vector2 _velocity;
        private int _timeSinceMovement = 0;
        private Vector2 _lastMove;
        private int _direction;
        private readonly int _positionInitialX;
        private readonly int _positionInitialY;
        private readonly int _positionTotalX;
        private readonly int _positionTotalY;


        public TrapPoint4(Vector2 point) //bottom right
        {
            ObjectPoint = new Vector2(point.X, point.Y);
            _velocity = new Vector2(0, 0);
            _positionInitialX = (int)point.X;
            _positionInitialY = (int)point.Y;
            _direction = 0;
            _positionTotalX = _positionInitialX - 200;
            _positionTotalY = _positionInitialY - 150;
        }

        private void PickDirection(Vector2 velocity)
        {
            switch (_direction)
            {
                case 0: //go left
                    _velocity.X = -velocity.X;
                    _velocity.Y = 0;
                    if (ObjectPoint.X < _positionTotalX)
                    {
                        _direction = 1;
                    }
                    break;
                case 1: //go right
                    _velocity.X = velocity.X;
                    _velocity.Y = 0;
                    if (ObjectPoint.X > _positionInitialX)
                    {
                        _direction = 2;
                    }
                    break;
                case 2: //go up
                    _velocity.X = 0;
                    _velocity.Y = -velocity.Y;
                    if (ObjectPoint.Y < _positionTotalY)
                    {
                        _direction = 3;
                    }
                    break;
                case 3: //go down
                    _velocity.X = 0;
                    _velocity.Y = velocity.Y;
                    if (ObjectPoint.Y > _positionInitialY)
                    {
                        _direction = 0;
                    }
                    break;
            }
        }

        public void Move(Vector2 velocity, GameTime gameTime)
        {
            PickDirection(velocity);
            _timeSinceMovement += gameTime.ElapsedGameTime.Milliseconds;

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

        }
    }
}
