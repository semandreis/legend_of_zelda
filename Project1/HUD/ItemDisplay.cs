using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.HUD
{
    public class ItemDisplay
    {
        private readonly GameManager _gameManager;
        private Rectangle _sourceRectangle;
        private Projectile _item;
        private static Dictionary<Projectile, Rectangle> _projectileSourceRectangle;

        private void InitializeSourceRectangleDict()
        {
            _projectileSourceRectangle.Add(Projectile.Arrow, new Rectangle(616, 137, 9, 17));
            _projectileSourceRectangle.Add(Projectile.SilverArrow, new Rectangle(624, 137, 7, 15));
            _projectileSourceRectangle.Add(Projectile.Boomerang, new Rectangle(584, 137, 7, 15));
            _projectileSourceRectangle.Add(Projectile.MagicalBoomerang, new Rectangle(594, 137, 7, 15));
            _projectileSourceRectangle.Add(Projectile.Bomb, new Rectangle(605, 137, 7, 15));
            _projectileSourceRectangle.Add(Projectile.Candle, new Rectangle(653, 137, 7, 15));
            _projectileSourceRectangle.Add(Projectile.WoodenSword, new Rectangle(555, 137, 7, 15));
            _projectileSourceRectangle.Add(Projectile.WhiteSword, new Rectangle(564, 137, 7, 15));
            _projectileSourceRectangle.Add(Projectile.MagicalSword, new Rectangle(564, 137, 7, 15));
            _projectileSourceRectangle.Add(Projectile.MagicalRod, new Rectangle(716, 137, 7, 15));
            _projectileSourceRectangle.Add(Projectile.WoodenSwordBeam, new Rectangle(555, 137, 7, 15));
            _projectileSourceRectangle.Add(Projectile.WhiteSwordBeam, new Rectangle(564, 137, 7, 15));
            _projectileSourceRectangle.Add(Projectile.MagicalSwordBeam, new Rectangle(564, 137, 7, 15));
            _projectileSourceRectangle.Add(Projectile.MagicalRodBeam, new Rectangle(716, 137, 7, 15));
            _projectileSourceRectangle.Add(Projectile.None, new Rectangle());
            _projectileSourceRectangle.Add(Projectile.Null, new Rectangle());
        }

        public ItemDisplay ()
        {
            _gameManager = GameManager.GetInstance();
            _sourceRectangle = new Rectangle();

            if (_projectileSourceRectangle == null)
            {
                _projectileSourceRectangle = new Dictionary<Projectile, Rectangle>();
                InitializeSourceRectangleDict();
            }
        }

        public void SetItemType(Projectile item)
        {
            _item = item;
            _sourceRectangle = _projectileSourceRectangle[item];
        }

        public void Draw(SpriteBatch sb, Rectangle destinationRectangle)
        {
            sb.Draw(_gameManager.HUDTexture, destinationRectangle, _sourceRectangle, Color.White);

            
        }
    }
}
