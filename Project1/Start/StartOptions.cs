using Zelda.GameState;
using Zelda.General;
using Zelda.Records;
using Zelda.Rooms;

namespace Zelda.Start
{
    public static class StartOptions
    {
        public static void SelectHardMode()
        {
            Globals.HardMode = true;
            Globals.DungeonDataFilename = RoomConstants.Hard;
        }

        public static void SelectNormalMode()
        {
            Globals.HardMode = false;
            Globals.DungeonDataFilename = RoomConstants.Normal;
        }

        public static void SelectRunWithNoRecord()
        {
            Globals.IsRecording = false;
            Globals.IsUserControl = true;
        }

        public static void SelectRunWithRecord()
        {
            Globals.IsRecording = true;
            Globals.IsUserControl = true;
        }

        public static void SelectRunRecord()
        {
            Globals.IsRecording = false;
            Globals.IsUserControl = false;
        }

        public static void SetFile(string file)
        {
            Globals.RecordFilename = file;
        }        

        public static void Run()
        {
            GameManager gm = GameManager.GetInstance();

            if (Globals.IsRecording)
                gm.Recorder = new CommandRecorder(Globals.RecordFilename);

            if (!Globals.IsUserControl)
                gm.InputCommands.AddCommandParsing();

            gm.LoadDungeonData();
            gm.StateCommander.ChangeState(GameStateType.Running);

            Globals.IsStarting = false;
        }
    }
}
