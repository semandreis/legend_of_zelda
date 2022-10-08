using Zelda.Interfaces;
using Zelda.General;
using Zelda.Commands.CollisionCommands;
using Zelda.Items;
using System;

namespace Zelda.Collisions
{
    class PlayerItemCollisionHandler : ICollisionSingle
    {
        public void Handle(IGameObject player, IGameObject item, Direction direction)
        {

            ICommand pickUp = new ItemPickupCommand(item);
            pickUp.Execute();

        }
    }
}
