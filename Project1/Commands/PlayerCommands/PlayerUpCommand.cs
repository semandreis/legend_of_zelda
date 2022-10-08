using Zelda.GameState;
using Zelda.Interfaces;
using Zelda.Link;
using Zelda.Records;

namespace Zelda.Commands.PlayerCommands
{
    class PlayerUpCommand : ICommand
    {
        private readonly IPlayer _player;
        public PlayerUpCommand(IPlayer player)
        {
            _player = player;
        }

        private void Record()
        {
            GameManager gm = GameManager.GetInstance();
            gm.Recorder.RecordCommand(RecordConstants.UpCommandString);
        }

        public void Execute()
        {
            _player.ChangeDirection(General.Direction.Up);
            _player.Step();

            if (Globals.IsRecording)
            {
                Record();
            }
        }
    }
}
