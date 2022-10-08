using Zelda.GameState;
using Zelda.Interfaces;
using Zelda.Records;

namespace Zelda.Commands.GameCommands
{
    class MuteCommand : ICommand
    {
        public MuteCommand()
        {
        }

        private void Record()
        {
            GameManager gm = GameManager.GetInstance();
            gm.Recorder.RecordCommand(RecordConstants.ToggleMuteCommandString);
        }

        public void Execute()
        {
            Globals.SoundManager.MuteAllSounds();

            if (Globals.IsRecording)
            {
                Record();
            }
        }

    }
}
