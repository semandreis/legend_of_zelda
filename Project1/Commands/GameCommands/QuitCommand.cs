using Zelda.GameState;
using Zelda.Interfaces;
using Zelda.Records;

namespace Zelda.Commands.GameCommands
{
    class QuitCommand : ICommand
    {
        private readonly Game1 _game;

        public QuitCommand(Game1 game)
        {
            _game = game;
        }

        private void Record()
        {
            GameManager gm = GameManager.GetInstance();
            gm.Recorder.RecordCommand(RecordConstants.QuitCommandString);
        }

        public void Execute()
        {
            if (Globals.IsRecording)
            {
                Record();
            }

            _game.Exit();
        }
    }
}
