using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Environment
{
    class DoorCreator
    {
        private static Texture2D _texture;

        public static void SetTexture(Texture2D texture)
        {
            _texture = texture;
        }

        public static IGameObject CreateDoor(int type, IGameObject portal)
        {
            if (type > 0 && type < 5)
            {
                return new DoorWithKeyObject(_texture, portal);
            }
            else if (type > 4 && type < 7)
            {
                return new ClosedDoorObject(_texture, portal);
            }
            else if (type > 6 && type < 9)
            {
                return new BombDoorObject1(_texture, portal);
            }
            else if (type > 8 && type < 11)
            {
                return new BombDoorObject2(_texture, portal);
            }

            return null;
        }
    }
}
