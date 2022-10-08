using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zelda.General;
using Zelda.Rooms;
using Zelda.Start;

namespace Zelda.GameState
{
    class StartState : IGameState
    {

        private static StartState _instance;
        private static StartScreen _screen;
        private static SpriteFont _font;
        private GameManager _gameManager;

        private StartState() { }

        public static StartState GetInstance()
        {
            if (_instance == null)
            {
                _instance = new StartState();
            }
            return _instance;
        }

        public void InitializeState()
        {
            _gameManager = GameManager.GetInstance();
            _screen = StartScreen.GetInstance();
            _screen.InitializeScreen();
            _font = _gameManager.Content.Load<SpriteFont>("Ubuntu32");
            Globals.IsMouseDebugging = false;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _screen.Draw(gameTime, sb);
        }

        public void Update(GameTime gameTime)
        {
            _screen.Update(gameTime);
        }
    }
}
