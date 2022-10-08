using Zelda.GameState;
using Zelda.Interfaces;
using Zelda.Link;
using Zelda.Records;

namespace Zelda.Commands.PlayerCommands
{
    class PlayerDownCommand : ICommand
    {
        private readonly IPlayer _player;
        public PlayerDownCommand(IPlayer player)
        {
            _player = player;
        }

        private void Record()
        {
            GameManager gm = GameManager.GetInstance();
            gm.Recorder.RecordCommand(RecordConstants.DownCommandString);
        }

        public void Execute()
        {
            _player.ChangeDirection(General.Direction.Down);
            _player.Step();

            if (Globals.IsRecording)
            {
                Record();
            }
        }
    }
}
