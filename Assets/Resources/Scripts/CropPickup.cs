using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropPickup : MonoBehaviour
{

    public Sprite a;
    public Sprite b;
    public Sprite c;

    public int type;
    private float spinOffset;
    public float spinSpeed;

    private void Start()
    {
        SetType(type);
        spinOffset = Random.Range(0, 10000);
    }

    void Update()
    {
        float spin = spinSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, spin, 0));
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
