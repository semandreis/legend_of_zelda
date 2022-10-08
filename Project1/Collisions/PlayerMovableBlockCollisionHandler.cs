using Zelda.Interfaces;
using Zelda.General;
using Zelda.Commands.CollisionCommands;
using Zelda.Commands.PlayerCommands;
using Zelda.Link;
using System;


namespace Zelda.Collisions
{
    class PlayerMovableBlockCollisionHandler : ICollisionSingle
    {

        public void Handle(IGameObject player, IGameObject tile, Direction direction)
        {   
            ICommand move = new MoveTileCommand(tile, direction);
            move.Execute();
            Globals.BlockIsMoved = true;
        }
    }
}
