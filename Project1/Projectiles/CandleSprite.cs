using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;

namespace Zelda.Projectiles
{
    class CandleSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly Texture2D _texture;
        private static SpriteEffects _effects;
        private float _timer;
        private const float _candleFrameTime = 0.07f;


        public CandleSprite(Texture2D texture)
        {
            _texture = texture;
            SourceRectangle = ProjectileConstants.Candle;
        }

        private static void FlipSprite()
        {
            if (_effects == SpriteEffects.None)
            {
                _effects = SpriteEffects.FlipHorizontally;
            }
            else
            {
                _effects = SpriteEffects.None;
            }
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer >= _candleFrameTime)
            {
                FlipSprite();
                _timer = 0;
            }

            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, _effects, ProjectileConstants.ProjectileLayer);
        }
    }
}
