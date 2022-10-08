using Zelda.Interfaces;
using Zelda.General;
using Zelda.Commands.CollisionCommands;
using Zelda.Commands.PlayerCommands;
using Zelda.Link;
using System;


namespace Zelda.Collisions
{
    class PlayerBlockCollisionHandler : ICollisionSingle
    {

        public void Handle(IGameObject player, IGameObject block, Direction direction)
        {
            PlayerObject p2p = (PlayerObject)player;
            ICommand stop = new StopCommand(p2p.Player);
            player.UndoMovement();

            //ICommand stop = new PleaseCommand(player);
            stop.Execute();
        }

    }
}
