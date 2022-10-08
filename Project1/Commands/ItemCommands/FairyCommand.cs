using System;
using System.Collections.Generic;
using System.Text;
using Zelda.Link;
using Zelda.Interfaces;

namespace Zelda.Commands.ItemCommands
{
    class FairyCommand : ICommand
    {
        private readonly IPlayer _player;

        public FairyCommand(IPlayer player)
        {
            _player = player;
        }

        public void Execute()
        {
            _player.PlayerStats.ChangeHealth(1000);

        }
    }
}
