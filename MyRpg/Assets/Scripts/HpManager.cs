using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    public Image[] heartsArr;
    public Sprite fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHeart;
    // Start is called before the first frame update
    void Start()
    {
        setUp();
    }

    public virtual void setUp()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            heartsArr[i].gameObject.SetActive(true);
            heartsArr[i].sprite = fullHeart;
        }
    }

    public virtual void UpdateHearts()
    {
        float tempHp = playerCurrentHeart.runTimeValue / 2; // half a heart is 1 hp
        for (int i = 0;i< heartContainers.initialValue; i++)
        {
            if (i <= tempHp - 1)
            {
                heartsArr[i].sprite = fullHeart;
            }
            else if(i >= tempHp)
            {
                heartsArr[i].sprite = emptyHeart;
            }
            else
            {
                heartsArr[i].sprite = halfFullHeart;
            }
        }
    }
}
