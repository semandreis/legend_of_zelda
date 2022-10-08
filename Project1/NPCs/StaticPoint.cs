using Microsoft.Xna.Framework;
using Zelda.Interfaces;

namespace Zelda.NPCs
{
    class StaticPoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }

        public StaticPoint(Vector2 position)
        {
            ObjectPoint = position;
        }

        public void Move(Vector2 velocity, GameTime gameTime)
        {

        }

        public void UndoMove()
        {

        }
        public void TakeDamage()
        {

        }
    }
}
