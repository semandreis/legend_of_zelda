using Microsoft.Xna.Framework;

namespace Zelda.Interfaces
{
    public interface IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        void Move(Vector2 velocity, GameTime gameTime);
        void UndoMove();
        void TakeDamage();

        
    }
}
