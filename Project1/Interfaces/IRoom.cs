using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Zelda.Interfaces
{
    public interface IRoom
    {
        public int ID { get; }
        public bool Accessed { get; set; }
        public Rectangle Frame { get; }
        public List<IGameObject> ActiveObjects { get; }
        public int EnemyNumber { get; set; }
        public Dictionary<IGameObject, int> PortalBoundaryObjects { get; set; }
        void InitializeRoom();
        void ResetRoom();
    }
}
