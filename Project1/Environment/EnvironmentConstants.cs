using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Environment
{
    public static class EnvironmentConstants
    {
        public static float TileDepth { get; } = 0f;
        public static int TileWidth { get; } = 64;
        public static int TileHeight { get; } = 64;
        public const float TileResize = .28f;
        public const int DoorWidthAndHeight = 32;
        public const float DoorResize = 3.5f;
        public static Vector2 DoorNorthPos { get; } = new Vector2(455, 120);
        public static Vector2 DoorSouthPos { get; } = new Vector2(455, 624);
        public static Vector2 DoorEastPos { get; } = new Vector2(848, 372);
        public static Vector2 DoorWestPos { get; } = new Vector2(64, 372);
    }
}
