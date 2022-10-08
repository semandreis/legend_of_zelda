using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;

namespace Zelda.Projectiles
{
    public interface IProjectileController
    {
        void AddProjectile(Projectile projectile, Direction direction, Vector2 position);

        void Update(GameTime gameTime);

        void Draw(GameTime gameTime, SpriteBatch sb);
    }
}
