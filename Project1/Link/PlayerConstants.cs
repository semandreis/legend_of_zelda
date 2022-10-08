using Microsoft.Xna.Framework;

namespace Zelda.Link
{
    public static class PlayerConstants
    {
        public static int LinkHealth { get; } = 10;
        public static int LinkHeartSize { get; } = 2;
        public static float LinkResize { get; } = 2.8f;
        public static float LinkDepth { get; } = 1f;
        public static int LinkVelocity { get; } = 4;
        public static int LinkRecoilFactor { get; } = -3;
        public static int AnimationTime { get; } = 180;
        public static int ItemTime { get; } = 150;
        public static int DamageTime { get; } = 9;

        public static float BerserkTime { get; } = 3; //seconds

        public static readonly Color[] ColorDamage =
            { Color.White, Color.Red, Color.White, Color.Blue,
              Color.White, Color.Green, Color.White, Color.Purple,
              Color.White, Color.PaleGoldenrod };

        public static readonly Rectangle LinkFoward1Rectangle = new Rectangle(1, 11, 16, 16);
        public static readonly Rectangle LinkFoward2Rectangle = new Rectangle(18, 11, 16, 16);
        public static readonly Rectangle LinkSide1Rectangle = new Rectangle(35, 11, 16, 16);
        public static readonly Rectangle LinkSide2Rectangle = new Rectangle(52, 11, 16, 16);
        public static readonly Rectangle LinkBack1Rectangle = new Rectangle(69, 11, 16, 16);
        public static readonly Rectangle LinkBack2Rectangle = new Rectangle(86, 11, 16, 16);

        public static readonly Rectangle LinkUseItemForwardRectangle = new Rectangle(107, 11, 16, 16);
        public static readonly Rectangle LinkUseItemSideRectangle = new Rectangle(124, 11, 16, 16);
        public static readonly Rectangle LinkUseItemBackRectangle = new Rectangle(141, 11, 16, 16);

        public static readonly Rectangle LinkShieldForward1Rectangle = new Rectangle(289, 11, 16, 25);
        public static readonly Rectangle LinkShieldForward2Rectangle = new Rectangle(306, 11, 16, 25);
        public static readonly Rectangle LinkShieldSide1Rectangle = new Rectangle(323, 11, 16, 16);
        public static readonly Rectangle LinkShieldSide2Rectangle = new Rectangle(340, 11, 16, 16);

        public static readonly Rectangle LinkItem1Rectangle = new Rectangle(214, 11, 16, 16);
        public static readonly Rectangle LinkItem2Rectangle = new Rectangle(231, 11, 16, 16);

        public static readonly Rectangle[] PlayerNormalFramesBack = { LinkBack1Rectangle, LinkBack2Rectangle };

        public static readonly Rectangle[] PlayerNormalFramesFront = { LinkFoward1Rectangle, LinkFoward2Rectangle };
        public static readonly Rectangle[] PlayerShieldFramesFront = { LinkShieldForward1Rectangle, LinkShieldForward2Rectangle };

        public static readonly Rectangle[] PlayerNormalFramesSide = { LinkSide1Rectangle, LinkSide2Rectangle };
        public static readonly Rectangle[] PlayerShieldFramesSide = { LinkShieldSide1Rectangle, LinkShieldSide2Rectangle };

        public static readonly Rectangle[] PlayerSpinFrames = { LinkFoward1Rectangle, LinkSide1Rectangle, LinkBack1Rectangle, LinkSide1Rectangle };

        public static readonly Rectangle[] PlayerItemFrames = { LinkItem1Rectangle, LinkItem2Rectangle };
    }
}
