using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Link
{
    class PlayerObject : IGameObject
    {
        public Rectangle ObjectRectangle { get; set; }
        public Enemy EnemyProperty { get; set; }
        public SubType SubProperty { get; set; }
        public SoundType SoundProperty { get; set; }
        public ObjectType ObjectProperty { get; set; }
        public bool Exists { get; set ; }

        public readonly IPlayer Player;

        private void SetRectangle()
        {
            ObjectRectangle = new Rectangle((int)Player.Point.ObjectPoint.X, (int)Player.Point.ObjectPoint.Y, 
                (int)(Player.LinkFrame.Width * PlayerConstants.LinkResize), (int)(Player.LinkFrame.Height * PlayerConstants.LinkResize));
        }

        public PlayerObject (IPlayer player)
        {
            Player = player;
            Exists = true;
            SetRectangle();
            ObjectProperty = ObjectType.Player;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            Player.Draw(gameTime, sb);
        }

        public void Update(GameTime gameTime)
        {
            Player.Update(gameTime);
            SetRectangle();
        }

        public void UndoMovement()
        {
            Player.Point.UndoMove();
        }

        public void ChangeStats(int change)
        {
            Player.PlayerStats.ChangeHealth(change);

            if (Player.PlayerStats.OneHP())
            {
                Player.PlayerStats.BerserkMode();          
            }

            if (!Player.PlayerStats.IsAlive())
            {
                GameManager gm = GameManager.GetInstance();
                gm.StateCommander.ChangeState(GameStateType.GameOver);
            }
        }

        public void Initial()
        {

        }
    }
}
