using Microsoft.Xna.Framework;
using Zelda.General;

namespace Zelda.Link
{
    public interface IPlayerState
    {
        void ChangeDirection(Direction direction);
        void Step();
        void Recoil();
        void UseShield();
        void PickItem(Item item);
        void UseItem(Projectile projectile);
        void UpdateFrame(GameTime gameTime);
    }
}
