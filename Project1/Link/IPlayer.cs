using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Link
{
    public interface IPlayer
    {
        public IPlayerState State { get; set; }
        public Color LinkColor { get; set; }
        public Rectangle LinkFrame { get; set; }
        public IMoveable Point { get; set; }
        public bool UsingItem { get; set; }
        public SpriteEffects Effects { get; set; }
        public IPlayerStats PlayerStats { get; set; }
        public IAchievements AchievementsStats { get; set; }
        public IPlayerInventory PlayerInventory { get; set; }

        void Animate(bool animate);
        void ChangeDirection(Direction direction);
        void Step();
        void UseShield();
        void UseItem(Projectile projectile);
        void TakeDamage();
        void GoBerserk();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime, SpriteBatch sb);
    }
}
