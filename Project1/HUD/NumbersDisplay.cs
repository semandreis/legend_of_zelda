using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Zelda.GameState;
using Zelda.General;

namespace Zelda.HUD
{
    public class NumbersDisplay
    {
        private readonly GameManager _gameManager;

        public NumbersDisplay()
        {
            _gameManager = GameManager.GetInstance();
        }

        public void DrawHealth(SpriteBatch sb, SpriteFont sf)
        {
            int currentHealth = _gameManager.Player.PlayerStats.FullHeartCount() * 2;
            sb.DrawString(sf, "X " + currentHealth, new Vector2(HUDConstants.healthpos1, HUDConstants.healthpos2), Color.Red);
        }

        public void DrawBombNum(SpriteBatch sb, SpriteFont sf)
        {
            sb.DrawString(sf, "X " + _gameManager.Player.PlayerInventory.ItemCount(Item.Bomb), new Vector2(HUDConstants.bomb1, HUDConstants.bomb2), Color.White);
        }


        public void DrawKeyNum(SpriteBatch sb, SpriteFont sf)
        {
            sb.DrawString(sf, "X " + _gameManager.Player.PlayerInventory.ItemCount(Item.Key), new Vector2(HUDConstants.bomb1, HUDConstants.key1), Color.White);
        }


        public void DrawGemNum(SpriteBatch sb, SpriteFont sf)
        {
            sb.DrawString(sf, "X " + _gameManager.Player.PlayerInventory.ItemCount(Item.Rupee), new Vector2(HUDConstants.bomb1, HUDConstants.dem1), Color.White);
        }
    }
}
