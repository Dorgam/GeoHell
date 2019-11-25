using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using GeoHell.PlayerActions;

namespace GeoHell.EnemyActions
{
    /// <summary>
    /// An enemy task for the behavior tree that allows the enemy to start shooting bullets
    /// </summary>
    public class ShootWeapon : Action
    {
        public SharedString WeaponName;
        private Shoot _shoot;
    
        public override void OnStart()
        {
            _shoot = GetComponent<Shoot>();
        }

        public override TaskStatus OnUpdate()
        {
            _shoot.StartShooting(WeaponName.Value);
            return TaskStatus.Success;
        }
    }
}
