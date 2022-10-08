using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.GameState;


namespace Zelda.HUD
{
    public class HUDCaveat
    {
        private readonly GameManager _gameManager;
        

        public HUDCaveat()
        {
            _gameManager = GameManager.GetInstance();

        }

        public void DrawHeartCaveat(SpriteBatch sb, SpriteFont font)
        {
            
            sb.DrawString(font, "You health is low!! Be careful!!!", new Vector2(HUDConstants.caveat1, HUDConstants.Frame4), Color.Red);
        }

        

    }
}
