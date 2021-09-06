using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public string relatedText;
    public Sprite itemSprite;
    public bool isKey;
}