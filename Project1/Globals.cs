using Microsoft.Xna.Framework.Graphics;
using Zelda.Sound;

namespace Zelda
{
    public static class Globals
    {
        public static SoundManager SoundManager { get; set; }
        public static SpriteFont Font { get; set; }
        public static bool GameIsPaused { get; set; } = false;
        public static float Opacity { get; set; } = 1;

        public static bool BlockIsMoved { get; set; } = false;
        public static bool SpecialBlockMoved { get; set; } = false;
        public static bool BombDoor1 { get; set; } = false;
        public static bool BombDoor2 { get; set; } = false;
        public static bool HardMode { get; set; } = false;

        public static bool IsRecording { get; set; } = false;
        public static bool IsChangingRoom { get; set; } = false;
        public static bool IsMouseDebugging { get; set; } = false;
        public static bool IsUserControl { get; set; } = false;
        public static bool IsStarting { get; set; } = true;
        public static string RecordFilename { get; set; }
        public static string DungeonDataFilename { get; set; }
    }
}
