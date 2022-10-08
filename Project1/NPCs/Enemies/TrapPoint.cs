using Microsoft.Xna.Framework;
using Zelda.Interfaces;

namespace Zelda.NPCs.Enemies
{
    class TrapPoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private Vector2 _velocity;
        private int _timeSinceMovement = 0;
        private Vector2 _lastMove;
        private bool _goRight;
        private readonly int _positionInitialX;
        private readonly int _positionTotalX;


        public TrapPoint(Vector2 point)
        {
            ObjectPoint = new Vector2(point.X, point.Y);
            _velocity = new Vector2(0, 0);
            _goRight = true; 
            _positionInitialX = (int)point.X;
            _positionTotalX = _positionInitialX + 200;
        }

        private void PickDirection(Vector2 velocity)
        {
            if (_goRight)
            {
                _velocity.X = velocity.X;
            }
            else
            {
                _velocity.X = -velocity.X;
            }

            if (ObjectPoint.X > _positionTotalX)
            {
                _goRight = false;
            }
            else if (ObjectPoint.X < _positionInitialX)
            {
                _goRight = true;
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
