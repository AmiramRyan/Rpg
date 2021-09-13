using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : GenericHealth
{
    [SerializeField] private Signal hpSignal;

    public override void TakeDmg(float amount)
    {
        base.TakeDmg(amount);
        maxHp.runTimeValue = currHp;
        hpSignal.Rise();
    }
}
