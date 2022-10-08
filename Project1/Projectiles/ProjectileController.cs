using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Projectiles
{
    class ProjectileController : IProjectileController
    {
        private readonly List<IGameObject> _projectiles;
        public ProjectileController (List<IGameObject> projectiles, Texture2D texture)
        {
            _projectiles = projectiles;
            ProjectileCreator.SetTexture(texture);
        }

        public void AddProjectile(Projectile projectile, Direction direction, Vector2 position)
        {
            GameManager gm = GameManager.GetInstance();
            _projectiles.Add(ProjectileCreator.CreateProjectile(projectile, position, direction));
            if(projectile == Projectile.WoodenSword || projectile == Projectile.WoodenSwordBeam || projectile == Projectile.MagicalSword || projectile == Projectile.MagicalSwordBeam)
            {
                gm.Player.AchievementsStats.SwordUsed++;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            foreach (IGameObject element in _projectiles)
            {
                element.Draw(gameTime, sb);
            }
        }

        private bool ObjectGone(IGameObject element)
        {
            return !element.Exists;
        }

        public void Update(GameTime gameTime)
        {
            _projectiles.RemoveAll(ObjectGone);
            foreach (IGameObject element in _projectiles)
            {
                element.Update(gameTime);
            }
        }
    }
}
