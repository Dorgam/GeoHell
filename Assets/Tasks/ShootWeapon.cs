using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

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
