using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;

namespace Zelda.Projectiles
{
    class BombSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly Texture2D _texture;
        private readonly Rectangle[] _sourceRectangles =
            { ProjectileConstants.Bomb1, ProjectileConstants.Bomb2, ProjectileConstants.Bomb3,ProjectileConstants.Bomb4};
        private static SpriteEffects _effects;
        private readonly float _lifespan;
        private float _timer;

        public BombSprite(Texture2D texture, float lifespan)
        {
            _texture = texture;
            _lifespan = lifespan;
            SourceRectangle = _sourceRectangles[0];
            _effects = SpriteEffects.None;
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer >= (_lifespan - ProjectileConstants.BombDelay + 0.0f))
                SourceRectangle = _sourceRectangles[1];
            if (_timer >= (_lifespan - ProjectileConstants.BombDelay + 0.1f))
            {
                SourceRectangle = _sourceRectangles[2];
                Globals.SoundManager.PlaySound("bomb_blow");
            }
            if (_timer >= (_lifespan - ProjectileConstants.BombDelay + 0.2f))
                SourceRectangle = _sourceRectangles[3];

            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, _effects, ProjectileConstants.ProjectileLayer);
        }
    }
}
