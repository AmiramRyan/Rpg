using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    public FloatValue maxHp;
    public float currHp;

    void Start()
    {
        Debug.Log("hmm");
        currHp = maxHp.runTimeValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Heal(float amount)
    {
        currHp += amount;
        if(currHp > maxHp.runTimeValue)
        {
            currHp = maxHp.runTimeValue;
        }
    }

    public virtual void FullHeal()
    {
        currHp = maxHp.runTimeValue;
    }

    public virtual void TakeDmg(float amount)
    {
        currHp -= amount;
        if(currHp < 0)
        {
            currHp = 0;
        }
    }

    public virtual void Die()
    {
        currHp = 0;
    }
    
}
