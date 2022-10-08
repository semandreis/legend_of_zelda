using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Projectiles
{
    class MagicalBoomerangSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly Texture2D _texture;
        private readonly Rectangle[] _sourceRectangles =
            { ProjectileConstants.MagicalBoomerang1, ProjectileConstants.MagicalBoomerang2, ProjectileConstants.MagicalBoomerang3, ProjectileConstants.BoomerangBoom };
        private static SpriteEffects _effects;
        private float _angle = 0;

        public MagicalBoomerangSprite(Texture2D texture, Direction direction)
        {
            _texture = texture;
            SetDirection(direction);
        }

        private void SetDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    SourceRectangle = _sourceRectangles[0];
                    _effects = SpriteEffects.FlipVertically;
                    break;
                case Direction.Left:
                    SourceRectangle = _sourceRectangles[0];
                    _effects = SpriteEffects.FlipHorizontally;
                    break;
                case Direction.Right:
                    SourceRectangle = _sourceRectangles[0];
                    _effects = SpriteEffects.None;
                    break;
                case Direction.Up:
                    SourceRectangle = _sourceRectangles[0];
                    _effects = SpriteEffects.None;
                    break;
                default:
                    break;
            }
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            _angle += ProjectileConstants.BoomerangRotation;
            Vector2 SpriteOrigin = new Vector2(SourceRectangle.Width / 2, SourceRectangle.Height / 2);
            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, _angle, SpriteOrigin, scale, _effects, ProjectileConstants.ProjectileLayer);
        }
    }
}
