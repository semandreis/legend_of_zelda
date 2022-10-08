using Microsoft.Xna.Framework;
using Zelda.Interfaces;

namespace Zelda.Environment
{
    class MovingTilePoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private Vector2 _lastMove;

        public MovingTilePoint(Vector2 position)
        {
            ObjectPoint = position;
        }

        public void Move(Vector2 velocity, GameTime gameTime)
        {
            ObjectPoint = Vector2.Add(ObjectPoint, velocity);
            _lastMove = velocity;
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
