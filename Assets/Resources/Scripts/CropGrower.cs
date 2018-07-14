using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropGrower : MonoBehaviour {

    public float growSpeed = .1f;

    public Sprite a;
    public Sprite b;
    public Sprite c;

    public int type;

    public CropLocation loc;

    // Use this for initialization
    void Start () {
        SetType(type);
        transform.localScale = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update () {
        float growDelta = Time.deltaTime * growSpeed;
        transform.localScale += new Vector3(growDelta, growDelta, 0);
        transform.position = loc.transform.position;

        if(transform.localScale.x > 1)
        {
            MoveBehavior.instance.Grow();
            loc.isOccupied = false;
            Destroy(gameObject);
        }
        
    }

    public void SetType(int newType)
    {
        type = newType;
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
