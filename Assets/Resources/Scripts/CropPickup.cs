using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropPickup : MonoBehaviour
{

    public Sprite a;
    public Sprite b;
    public Sprite c;

    public int type;

    private void Start()
    {
        SetType(type);
    }


    public void SetType(int type)
    {
        switch (type)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = a;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = b;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = c;
                break;
        }
    }

}
