using Zelda.GameState;
using Zelda.Interfaces;
using Zelda.Link;
using Zelda.Records;

namespace Zelda.Commands.PlayerCommands
{
    class PlayerRightCommand : ICommand
    {
        private readonly IPlayer _player;
        public PlayerRightCommand(IPlayer player)
        {
            _player = player;
        }

        private void Record()
        {
            GameManager gm = GameManager.GetInstance();
            gm.Recorder.RecordCommand(RecordConstants.RightCommandString);
        }

        public void Execute()
        {
            _player.ChangeDirection(General.Direction.Right);
            _player.Step();

            if (Globals.IsRecording)
            {
                Record();
            }
        }
    }
}
