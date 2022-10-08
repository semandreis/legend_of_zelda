using Zelda.GameState;
using Zelda.Interfaces;
using Zelda.Link;
using Zelda.Records;

namespace Zelda.Commands.PlayerCommands
{
    class PlayerLeftCommand : ICommand
    {
        private readonly IPlayer _player;
        public PlayerLeftCommand(IPlayer player)
        {
            _player = player;
        }

        private void Record()
        {
            GameManager gm = GameManager.GetInstance();
            gm.Recorder.RecordCommand(RecordConstants.LeftCommandString);
        }

        public void Execute()
        {
            _player.ChangeDirection(General.Direction.Left);
            _player.Step();

            if (Globals.IsRecording)
            {
                Record();
            }
        }
    }
}
