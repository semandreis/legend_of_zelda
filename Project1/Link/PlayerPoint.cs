using Microsoft.Xna.Framework;

namespace Zelda.Link
{
    class PlayerPoint : Interfaces.IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private Vector2 _lastPoint;

        public PlayerPoint (Vector2 point)
        {
            ObjectPoint = new Vector2(point.X, point.Y);
            _lastPoint = ObjectPoint;
        }

        public void Move(Vector2 velocity, GameTime gameTime)
        {
            _lastPoint = ObjectPoint;
            ObjectPoint = Vector2.Add(ObjectPoint, velocity);
        }

        public void UndoMove()
        {
            ObjectPoint = _lastPoint;
        }

        public void TakeDamage()
        {

        }
    }
}
