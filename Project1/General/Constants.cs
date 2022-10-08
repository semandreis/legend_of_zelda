using Microsoft.Xna.Framework.Graphics;

namespace Zelda.General
{
    public enum Direction
    {
        Down,
        Left,
        Right,
        Up,
        None
    }

    public enum Item
    {
        Arrow,
        BlueCandle,
        BluePotion,
        Bomb,
        Bow,
        Clock,
        Compass,
        Fairy,
        Heart,
        HeartContainer,
        Key,
        Map,
        Rupee,
        TriforcePieces,
        WoodenBoomerang,
        Null,
        SilverArrow,
        MagicalBoomerang,
        WoodenSword,
        WhiteSword,
        MagicalSword,
        MagicalRod
    }

    public enum Projectile
    {
        None,
        Arrow,
        SilverArrow,
        Boomerang,
        MagicalBoomerang,
        Bomb,
        Candle,
        WoodenSword,
        WhiteSword,
        MagicalSword,
        MagicalRod, 
        WoodenSwordBeam,
        WhiteSwordBeam,
        MagicalSwordBeam,
        MagicalRodBeam,
        Null
    }

    public enum Tiles
    {
        MovingTile,
        NonmovingTile,
        Wall,
        Stair
    }

    public enum Enemy
    {
        Goriya,
        JellyBig,
        JellySmall,
        Keese,
        Rope,
        Stalfos,
        Trap,
        Trap1,
        Trap2,
        Trap3,
        Trap4,
        WallMaster,
        Gibdo,
        Darknut
    }

    public enum Boss
    {
        Aquamentus,
        Dodongo
    }

    public enum Neutral
    {
        OldMan,
        StaticFire
    }

    public enum ObjectType
    {
        Unmoveable, //NPC and Blocks
        Moveable,   //2 Moveable Blocks
        Wall,
        Portal,
        Enemy,
        Item,
        Player,
        EnemyProjectile,
        FriendlyProjectile
     }

    public enum SubType
    {
        DoorLocked,
        BombDoor1,
        BombDoor2,
        ClosedDoorEnemy,
        ClosedDoorBlock,
        Bomb,
        None
    }
    public enum SoundType
    {
        Triforce,
        Rupee,
        Heart,
        Item
    }
     
    public enum Background
    {
        Unmoveable, //NPC and Blocks
        Moveable,   //2 Moveable Blocks
        Enemy,
        Item,
        Player
    }

    public enum GameStateType
    {
        Running,
        Paused,
        GameOver,
        Completed,
        Transitioning,
        Start,
        Selection,
        ClockPause
    }

    public static class Constants
    {
        public const int RoomWidth = 256;
        public const int RoomHeight = 176;
        public const int ScreenWidth = RoomWidth * 4;
        public const int ScreenHeight = (int) (RoomHeight * 4.5);
        public const int ImageButtonWidth = 20;
        public const int ImageButtonHeight = 50;
    }
}