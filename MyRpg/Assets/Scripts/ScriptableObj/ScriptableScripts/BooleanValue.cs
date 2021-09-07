using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BooleanValue : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialValue;
    [HideInInspector]
    public bool runTimeValue;

    public void OnAfterDeserialize()
    {
        runTimeValue = initialValue;
    }

    public void OnBeforeSerialize()
    {
    }
}
