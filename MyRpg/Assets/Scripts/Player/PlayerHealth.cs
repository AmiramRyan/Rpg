using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : GenericHealth
{
    [SerializeField] private Signal hpSignal;

    public override void Update()
    {
        currHp = maxHp.runTimeValue;
    }

    public override void TakeDmg(float amount)
    {
        currHp -= amount;
        if (currHp < 0)
        {
            currHp = 0;
        }
        maxHp.runTimeValue = currHp;
        hpSignal.Rise();
    }

    public override void Heal(float amount)
    {
        currHp = maxHp.runTimeValue;
        currHp += amount;
        if (currHp > maxHp.initialValue)
        {
            currHp = maxHp.initialValue;
        }
        maxHp.runTimeValue = currHp;
        hpSignal.Rise();
    }

    public override void FullHeal()
    {
        currHp = maxHp.initialValue;
        Debug.Log(this.gameObject.GetComponent<PlayerHealth>().currHp + " Here");
        maxHp.runTimeValue = currHp;
        hpSignal.Rise();
    }
}
