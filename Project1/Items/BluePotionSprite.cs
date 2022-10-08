﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Items
{
    class BluePotionSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly Texture2D _texture;

        public BluePotionSprite(Texture2D texture)
        {
            _texture = texture;
            SourceRectangle = ItemConstants.BluePotionRectangle;
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

    }
}
