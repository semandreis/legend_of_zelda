using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Zelda.GameState;
using Zelda.General;

namespace Zelda.HUD
{
    public class HeartDisplay
    {
        private readonly GameManager _gameManager;
        private readonly Rectangle _sourceRectangle;

        public HeartDisplay()
        {
            _gameManager = GameManager.GetInstance();
            _sourceRectangle = HUDConstants.HealthRectangle;
        }

        public void Draw(SpriteBatch sb, Rectangle destinationRectangle)
        {
            sb.Draw(_gameManager.HUDTexture, destinationRectangle, _sourceRectangle, Color.White);
        }
    }
}
