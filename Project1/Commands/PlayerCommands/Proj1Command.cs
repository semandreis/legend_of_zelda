using System;
using System.Collections.Generic;
using System.Text;
using Zelda.GameState;
using Zelda.Interfaces;
using Zelda.Link;
using Zelda.Records;

namespace Zelda.Commands.PlayerCommands
{
    class Proj1Command : ICommand
    {
        private readonly IPlayer _player;

        public Proj1Command(IPlayer player)
        {
            _player = player;
        }

        private void Record()
        {
            GameManager gm = GameManager.GetInstance();
            gm.Recorder.RecordCommand(RecordConstants.UseItem1CommandString);
        }

        public void Execute()
        {
            _player.UseItem(_player.PlayerStats.Proj1);

            if (Globals.IsRecording)
            {
                Record();
            }
        }
    }
}
