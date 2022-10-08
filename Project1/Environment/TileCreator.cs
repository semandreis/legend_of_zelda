using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Environment
{
    static class TileCreator
    {
        private static Texture2D _texture;

        public static void SetTexture(Texture2D texture)
        {
            _texture = texture;
        }

        public static IGameObject CreateTile(Tiles tile, Vector2 position)
        {
            return tile switch
            {
                Tiles.MovingTile => new MovingTileObject(_texture, position),
                Tiles.NonmovingTile => new InvisibleTile(position),
                _ => throw new NotImplementedException("Can't create tile"),
            };
        }
    }
}
