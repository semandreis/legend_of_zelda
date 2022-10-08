using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Zelda.Environment
{
    class ClosedDoorEastSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly Texture2D _texture;
        private readonly int _sourceX = 99;
        private readonly int _sourceY = 66;
        public ClosedDoorEastSprite(Texture2D texture)
        {
            _texture = texture;
            SourceRectangle = new Rectangle(_sourceX, _sourceY, EnvironmentConstants.DoorWidthAndHeight, EnvironmentConstants.DoorWidthAndHeight);
        }
        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            position = EnvironmentConstants.DoorEastPos;
            sb.Draw(_texture, position, SourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, EnvironmentConstants.TileDepth);
        }
    }
}
