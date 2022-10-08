using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Projectiles
{
    static class ProjectileCreator
    {
        private static Texture2D _texture;

        public static void SetTexture(Texture2D texture)
        {
            _texture = texture;
        }

        public static IGameObject CreateProjectile(Projectile projectile, Vector2 position, Direction direction)
        {
            return projectile switch
            {
                Projectile.Arrow => new ArrowObject(_texture, position, direction),
                Projectile.SilverArrow => new SilverArrowObject(_texture, position, direction),
                Projectile.Boomerang => new BoomerangObject(_texture, position, direction),
                Projectile.MagicalBoomerang => new MagicalBoomerangObject(_texture, position, direction),
                Projectile.Bomb => new BombObject(_texture, position, direction),
                Projectile.Candle => new CandleObject(_texture, position, direction),
                Projectile.WoodenSword => new WoodenSwordObject(_texture, position, direction),
                Projectile.WhiteSword => new WhiteSwordObject(_texture, position, direction),
                Projectile.MagicalSword => new MagicalSwordObject(_texture, position, direction),
                Projectile.MagicalRod => new MagicalRodObject(_texture, position, direction),
                Projectile.WoodenSwordBeam => new WoodenSwordBeamObject(_texture, position, direction),
                Projectile.WhiteSwordBeam => new WhiteSwordBeamObject(_texture, position, direction),
                Projectile.MagicalSwordBeam => new MagicalSwordBeamObject(_texture, position, direction),
                Projectile.MagicalRodBeam => new MagicalRodBeamObject(_texture, position, direction),
                _ => throw new InvalidOperationException("Can't create projectile"),
            };
        }
    }
}
