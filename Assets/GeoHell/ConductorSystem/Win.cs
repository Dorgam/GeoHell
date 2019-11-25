using BehaviorDesigner.Runtime.Tasks;
using GeoHell.LevelSystem;

namespace GeoHell.ConductorSystem
{
    /// <summary>
    /// A conductor task that marks the end of the game
    /// </summary>
    public class Win : Action
    {
        public override TaskStatus OnUpdate()
        {
            LevelManager.Instance.LoadLevel(Level.Win);
            return TaskStatus.Success;
        }
    }
}
