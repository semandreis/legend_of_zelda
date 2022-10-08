using Microsoft.Xna.Framework;

namespace Zelda.HUD
{
    public static class HUDConstants
    {
        public static readonly Rectangle MapTileRectangle = new Rectangle(663, 108, 6, 2);
        public static readonly Rectangle HealthRectangle = new Rectangle(645, 117, 8, 8);

        public static float MapTileDepth {get; } =  0.2f;
        public static float PositionTileDepth { get; } = 0.2f;

        public static int Frame1 { get; } = 110;
        public static int Frame2 { get; } = 5;
        public static int Frame3 { get; } = 700;
        public static int Frame4 { get; } = 120;
        public static int Frame5 { get; } = 258;
        public static int Frame6 { get; } = 11;
        public static int Frame7 { get; } = 256;
        public static int Frame8 { get; } = 56;

        public static int item1 { get; } = 465;
        public static int item2 { get; } = 55;
        public static int item3 { get; } = 18;
        public static int item4 { get; } = 33;
        public static int item5 { get; } = 530;
        public static int item6 { get; } = 20;
        public static int item7 { get; } = 32;

        public static int map1 { get; } = 154;
        public static int map2 { get; } = 22;
        public static int map3 { get; } = 174;
        public static int map4 { get; } = 85;

        public static int health1 { get; } = 660;
        public static int health2 { get; } = 73;
        public static int health3 { get; } = 25;

        public static int healthpos1 { get; } = 700;
        public static int healthpos2 { get; } = 70;

        public static int bomb1 { get; } = 390;
        public static int bomb2 { get; } = 88;

        public static int key1 { get; } = 69;
        public static int dem1 { get; } = 35;
        public static int caveat1 { get; } = 10;
    }
}
