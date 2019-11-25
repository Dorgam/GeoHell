using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace GeoHell.ConductorSystem
{
    /// <summary>
    /// A conductor task to spawn an enemy
    /// </summary>
    public class SpawnEnemy : Action
    {
        public SharedGameObject Enemy;
        public SharedVector2 SpawnTarget;
        public SharedVector2 StartTarget;
        private EnemyInstantiator _instantiator;

        public override void OnStart()
        {
            GlobalVariables.Instance.SetVariableValue("EnemiesAlive", (int) GlobalVariables.Instance.GetVariable("EnemiesAlive").GetValue() + 1);
            _instantiator = GetComponent<EnemyInstantiator>();
        }
    
        public override TaskStatus OnUpdate()
        {
            _instantiator.InstantiateEnemy(Enemy.Value, SpawnTarget.Value, StartTarget.Value);
            return TaskStatus.Success;
        }
    }
}
