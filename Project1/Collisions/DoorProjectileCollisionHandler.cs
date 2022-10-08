using Zelda.General;
using Zelda.Interfaces;
using Zelda.Commands.CollisionCommands;
using Zelda.Link;
using System;
using Zelda.GameState;
using Zelda.Environment;

namespace Zelda.Collisions
{
    class DoorProjectileCollisionHandler : ICollisionSingle
    {
        public void Handle(IGameObject bomb, IGameObject portal, Direction direction)
        {
            bomb.Exists = false;
            if (portal.SubProperty == SubType.BombDoor1)
            {
                Globals.BombDoor1 = true;
            }
            if (portal.SubProperty == SubType.BombDoor2)
            {
                Globals.BombDoor2 = true;
            }

        }
    }
}
