using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    //5.493517 -3.630581 celler start room
    // Start is called before the first frame update
    public Vector2 initialValue;

    [HideInInspector]
    public Vector2 runTimeValue;

    public void OnAfterDeserialize()
    {
        runTimeValue = initialValue;
    }

    public void OnBeforeSerialize()
    {
    }
}
