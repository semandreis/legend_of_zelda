using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;
using Zelda.Records;

namespace Zelda.Commands.StateCommander
{
    class GameOverCommand : ICommand
    {
        private readonly GameManager _gm;

        public GameOverCommand(GameManager gm)
        {
            _gm = gm;
        }

        private void Record()
        {
            GameManager gm = GameManager.GetInstance();
            gm.Recorder.RecordCommand(RecordConstants.QuitCommandString);
            Globals.IsRecording = false;
        }

        public void Execute()
        {
            if (Globals.IsRecording)
            {
                Record();
            }
            _gm.StateCommander.ChangeState(GameStateType.GameOver);
            Globals.SoundManager.PauseMusic();
        }
    }
}
