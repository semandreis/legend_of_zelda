using Microsoft.Xna.Framework;

namespace Zelda.NPCs
{
    public static class NPCConstants
    {
        public static int BossHealth { get; } =  10;
        public static int SmallEnemyHealth { get; } = 1;
        public static int NormalEnemyHealth { get; } = 3;
        public static int HardModeEnemyHealthSmall { get; } = 2;
        public static int HardModeEnemyHealthNormal { get; } = 5;
        public static int HardModeEnemyHealthBoss { get; } = 15;
        public static int InvincibleEnemyHealth { get; } = int.MaxValue;
        public static float EnemyLayer { get; } = .4f;
        public static float EnemyResize { get; } = 2.9f;

        public static int KeeseMovementTime { get; } = 600;
        public static int KeeseFrameTime { get; } = 80;
        public static Vector2 KeeseVelocity { get; } = new Vector2(2, 2);

        public static Vector2 DodongoVelocity { get; } = new Vector2(5, 0);
        public static int DodongoMovementTime { get; } = 1;

        public static int GoriyaMovementTime { get; } = 500;
        public static int GoriyaFrameTime { get; } = 100;
        public static Vector2 GoriyaVelocity { get; } = new Vector2(2, 2);
        public static int DarknutMovementTime { get; } = 600;
        public static int DarknutFrameTime { get; } = 200;
        public static Vector2 DarknutVelocity { get; } = new Vector2(3, 3);

        public static Vector2 RopeVelocity1 { get; } = new Vector2(2, 2);
        public static Vector2 RopeVelocity2 { get; } = new Vector2(3, 3);
        public static int RopeMovementTime { get; } = 600;

        public static Vector2 StalfosVelocity { get; } = new Vector2(2, 2);
        public static Vector2 TrapVelocity { get; } = new Vector2(2, 2);
      
        public static int FireFrameTime { get; } = 80;
    }
}
