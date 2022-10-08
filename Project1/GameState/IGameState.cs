using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Link;

namespace Zelda.GameState
{
    public interface IGameState
    {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime, SpriteBatch sb);
        void InitializeState();
    }
}
