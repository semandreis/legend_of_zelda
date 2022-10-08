using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Zelda.HUD;
using Zelda.Interfaces;
using Zelda.Items;
using Zelda.Projectiles;

namespace Zelda.General
{
    class StringButton
    {
        private string _name;
        private SpriteFont _font;
        private Vector2 _buttonLoc;
        private Vector2 _size;

        public StringButton(string name, SpriteFont font, Vector2 buttonLoc)
        {
            _name = name;
            _font = font;
            _size = font.MeasureString(name);
            _buttonLoc.X = buttonLoc.X - (_size.X / 2);
            _buttonLoc.Y = buttonLoc.Y - (_size.Y / 2);


        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.DrawString(_font, _name, _buttonLoc, Color.White);
        }

        public string ButtonPressed()
        {

            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (mouseState.X >= _buttonLoc.X &&
                    mouseState.X <= _buttonLoc.X + _size.X &&
                    mouseState.Y >= _buttonLoc.Y &&
                    mouseState.Y <= _buttonLoc.Y + _size.Y)
                {
                    return _name;
                }
            }

            return null;
        }
    }

    class ItemButton
    { 
        private IGameObject _go;
        private Rectangle _buttonLoc;
        private Projectile _p;
        private ItemDisplay _id;

        public ItemButton(Projectile p, Rectangle buttonLoc)
        {
            _id = new ItemDisplay();
            _id.SetItemType(p);
            _buttonLoc = buttonLoc;
            _p = p;

        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _id.Draw(sb, _buttonLoc);
        }

        public Projectile ButtonPressed()
        {

            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (mouseState.X >= _buttonLoc.X &&
                    mouseState.X <= _buttonLoc.X + Constants.ImageButtonWidth &&
                    mouseState.Y >= _buttonLoc.Y &&
                    mouseState.Y <= _buttonLoc.Y + Constants.ImageButtonHeight)
                {
                    return _p;
                }
            }

            return Projectile.Null;
        }
    }
}
