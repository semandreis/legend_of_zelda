using Microsoft.Xna.Framework;

namespace Zelda.Items
{
    public static class ItemConstants
    {
        public static float ItemResize { get; } = 3.2f;

        public static readonly Rectangle ArrowRectangle = new Rectangle(154, 0, 5, 16);
        public static readonly Rectangle BlueCandleRectangle = new Rectangle(160, 16, 8, 16);
        public static readonly Rectangle BluePotionRectangle = new Rectangle(80, 16, 8, 16);
        public static readonly Rectangle BombRectangle = new Rectangle(136, 0, 8, 14);
        public static readonly Rectangle BowRectangle = new Rectangle(144, 0, 8, 16);
        public static readonly Rectangle ClockRectangle = new Rectangle(58, 0, 11, 16);
        public static readonly Rectangle CompassRectangle = new Rectangle(258, 1, 11, 12);
        public static readonly Rectangle FairyRectangle1 = new Rectangle(40, 0, 8, 16);
        public static readonly Rectangle FairyRectangle2 = new Rectangle(48, 0, 8, 16);
        public static readonly Rectangle HeartContainerRectangle = new Rectangle(25, 1, 13, 13);
        public static readonly Rectangle HeartRectangle1 = new Rectangle(0, 0, 7, 8);
        public static readonly Rectangle HeartRectangle2 = new Rectangle(0, 8, 7, 8);
        public static readonly Rectangle KeyRectangle = new Rectangle(240, 0, 8, 16);
        public static readonly Rectangle MapRectangle = new Rectangle(88, 0, 8, 16);
        public static readonly Rectangle RupeeRectangle1 = new Rectangle(72, 0, 8, 16);
        public static readonly Rectangle RupeeRectangle2 = new Rectangle(72, 16, 8, 16);
        public static readonly Rectangle TriforcePieceRectangle1 = new Rectangle(275, 3, 10, 10);
        public static readonly Rectangle TriforcePieceRectangle2 = new Rectangle(275, 19, 10, 10);
        public static readonly Rectangle WoodenBoomerangRectangle = new Rectangle(129, 3, 5, 8);

        public static readonly Rectangle[] FairyFrames = { FairyRectangle1, FairyRectangle2 };
        public static readonly Rectangle[] HeartFrames = { HeartRectangle1, HeartRectangle2 };
        public static readonly Rectangle[] RupeeFrames = { RupeeRectangle1, RupeeRectangle2 };
        public static readonly Rectangle[] TriforcePieceFrames = { TriforcePieceRectangle1, TriforcePieceRectangle2 };
    }
}
