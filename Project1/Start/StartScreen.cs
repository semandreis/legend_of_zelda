using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zelda.GameState;
using Zelda.Records;
using Zelda.Rooms;

namespace Zelda.Start
{
    class StartScreen
    {
        private static StartScreen _instance;
        private static StartDisplay _display;

        private StartScreen() { }

        public static StartScreen GetInstance()
        {
            if (_instance == null)
            {
                _instance = new StartScreen();
                _display = new StartDisplay();
            }
            return _instance;
        }
        public void InitializeScreen()
        {
            Globals.IsRecording = false;
            Globals.IsUserControl = true;
            Globals.IsStarting = true;
            Globals.HardMode = true;
            Globals.DungeonDataFilename = RoomConstants.Hard;
            Globals.RecordFilename = RecordConstants.Filename1;

        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _display.Draw(sb);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.H))
            {
                StartOptions.SelectHardMode();                
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.N))
            {
                StartOptions.SelectNormalMode();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                StartOptions.SelectRunWithNoRecord();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                StartOptions.SelectRunWithRecord();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                StartOptions.SelectRunRecord();
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.D1) || Keyboard.GetState().IsKeyDown(Keys.NumPad1))
            {
                StartOptions.SetFile(RecordConstants.Filename1);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D2) || Keyboard.GetState().IsKeyDown(Keys.NumPad2))
            {
                StartOptions.SetFile(RecordConstants.Filename2);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D3) || Keyboard.GetState().IsKeyDown(Keys.NumPad3))
            {
                StartOptions.SetFile(RecordConstants.Filename3);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D4) || Keyboard.GetState().IsKeyDown(Keys.NumPad4))
            {
                StartOptions.SetFile(RecordConstants.Filename4);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.V))
            {
                StartOptions.Run();
            }
        }
    }
}
