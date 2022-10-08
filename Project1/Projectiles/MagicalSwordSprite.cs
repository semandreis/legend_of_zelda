using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;

namespace Zelda.Projectiles
{
    class MagicalSwordSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly Texture2D _texture;
        private readonly Rectangle[] _sourceRectangles =
            { ProjectileConstants.MagicalSwordBeamFront, ProjectileConstants.MagicalSwordBeamSide };
        private static SpriteEffects _effects;

        public MagicalSwordSprite(Texture2D texture, Direction direction, float lifespan)
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
                    SourceRectangle = _sourceRectangles[1];
                    _effects = SpriteEffects.FlipHorizontally;
                    break;
                case Direction.Right:
                    SourceRectangle = _sourceRectangles[1];
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
            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, _effects, ProjectileConstants.ProjectileLayer);
        }
    }
}
