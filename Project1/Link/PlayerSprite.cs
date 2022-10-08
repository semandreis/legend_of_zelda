using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Link
{
    class PlayerSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly IPlayer _player;
        private readonly Texture2D _texture;

        public PlayerSprite (IPlayer player, Texture2D texture)
        {
            _player = player;
            _texture = texture;
            SourceRectangle = _player.LinkFrame;
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            sb.Draw(_texture, position, _player.LinkFrame, _player.LinkColor * Globals.Opacity, 0f, Vector2.Zero, scale, _player.Effects, PlayerConstants.LinkDepth);
            SourceRectangle = _player.LinkFrame;
        }
    }
}
