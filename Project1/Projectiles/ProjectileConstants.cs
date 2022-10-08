using Microsoft.Xna.Framework;

namespace Zelda.Projectiles
{
    public static class ProjectileConstants
    {
        public static float ProjectileResize { get; } = 3.6f;
        public static float ProjectileLayer { get; } = .9f;

        public static int ArrowMovementTime { get; } = 600;
        public static int ArrowFrameTime { get; } = 80;
        public static float ArrowLifespan { get; } = 1f;
        public static float ArrowDelay { get; } = 0.2f;
        public static float SilverArrowLifespan { get; } = 1f;
        public static Vector2 ArrowVelocity { get; } = new Vector2(0.5f, 0.5f);
        public static Vector2 SilverArrowVelocity { get; } = new Vector2(1f, 1f);

        public static int BombFrameTime { get; } = 80;
        public static float BombLifespan { get; } = 1f;
        public static float BombDelay { get; } = 0.3f;

        public static int BoomerangFrameTime { get; } = 80;
        public static float BoomerangLifespan { get; } = .75f;
        public static Vector2 BoomerangVelocity { get; } = new Vector2(2f, 2f);
        public static float BoomerangAcceleration { get; } = 0.09f;
        public static float BoomerangRotation { get; } = 0.17f;

        public static float MagicalBoomerangLifespan { get; } = 1.1f;
        public static float MagicalBoomerangAcceleration { get; } = 0.06f;

        public static Vector2 CandleVelocity { get; } = new Vector2(0.5f, 0.5f);
        public static float CandleLifespan { get; } = 0.6f;
        public static float CandleDelay { get; } = 0.4f;

        public static Vector2 SwordVelocity { get; } = new Vector2(1.5f, 1.5f);
        public static Vector2 SwordBeamVelocity { get; } = new Vector2(2f, 2f); 
        public static float SwordAcceleration { get; } = 0.5f; 
        public static float SwordLifespan { get; } = .1f;
        public static int SwordFrameTime { get; } = 80;

        public static readonly Rectangle Candle = new Rectangle(191, 185, 15, 15);

        public static readonly Rectangle Bomb1 = new Rectangle(129, 185, 8, 15);
        public static readonly Rectangle Bomb2 = new Rectangle(138, 185, 15, 15);
        public static readonly Rectangle Bomb3 = new Rectangle(155, 185, 15, 15);
        public static readonly Rectangle Bomb4 = new Rectangle(172, 185, 15, 15);

        public static readonly Rectangle Boomerang1 = new Rectangle(64, 185, 7, 15);
        public static readonly Rectangle Boomerang2 = new Rectangle(73, 185, 7, 15);
        public static readonly Rectangle Boomerang3 = new Rectangle(82, 185, 7, 15);

        public static readonly Rectangle MagicalBoomerang1 = new Rectangle(91, 185, 7, 15);
        public static readonly Rectangle MagicalBoomerang2 = new Rectangle(100, 185, 7, 15);
        public static readonly Rectangle MagicalBoomerang3 = new Rectangle(109, 185, 7, 15);

        public static readonly Rectangle BoomerangBoom = new Rectangle(118, 185, 7, 15);

        public static readonly Rectangle ArrowFront = new Rectangle(1, 185, 7, 15);
        public static readonly Rectangle ArrowSide = new Rectangle(10, 185, 15, 15);

        public static readonly Rectangle SilverArrowFront = new Rectangle(27, 185, 7, 15);
        public static readonly Rectangle SilverArrowSide = new Rectangle(36, 185, 15, 15);

        public static readonly Rectangle ArrowBoom = new Rectangle(53, 185, 7, 15);

        public static readonly Rectangle WoodSwordBeamFront = new Rectangle(1, 154, 7, 16);
        public static readonly Rectangle WoodSwordBeamSide = new Rectangle(10, 154, 16, 16);
        public static readonly Rectangle WoodSwordBeamHit = new Rectangle(27, 154, 7, 16);

        public static readonly Rectangle WhiteSwordBeamFront = new Rectangle(36, 154, 7, 16);
        public static readonly Rectangle WhiteSwordBeamSide = new Rectangle(45, 154, 16, 16);
        public static readonly Rectangle WhiteSwordBeamHit = new Rectangle(62, 154, 7, 16);

        public static readonly Rectangle MagicalSwordBeamFront = new Rectangle(71, 154, 7, 16);
        public static readonly Rectangle MagicalSwordBeamSide = new Rectangle(80, 154, 16, 16);
        public static readonly Rectangle MagicalSwordBeamHit = new Rectangle(97, 154, 7, 16);

        public static readonly Rectangle MagicalRodBeamFront = new Rectangle(145, 154, 7, 16);
        public static readonly Rectangle MagicalRodBeamSide = new Rectangle(154, 154, 16, 16);
    }
}
