using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehavior : Singleton<MoveBehavior>
{
    public GameObject cropGrowerPrefab;
    public ParticleSystem ps;

    public float speed;

    public List<CropLocation> cropLocations = new List<CropLocation>();
    public float size = 1;
    private bool isRight = false;

    // Update is called once per frame
    void Update()
    {

        float hSpd = speed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        float vSpd = speed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        if (hSpd < 0)
        {
            isRight = false;
            transform.localScale = new Vector2(size, size);
        }
        else if (hSpd > 0)
        {
            isRight = true;
            transform.localScale = new Vector2(-size, size);
        }
        transform.position = new Vector2(transform.position.x + hSpd, transform.position.y + vSpd);
    }
    public void Grow()
    {
        size *= 1.1f;
        if (isRight)
        {
            transform.localScale = new Vector2(-size, size);
        }
        else
        {
            transform.localScale = new Vector2(size, size);
        }
        ps.emissionRate *= 1.1f;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        CropPickup crop = collision.GetComponent<CropPickup>();

        if (crop)
        {
            foreach(CropLocation loc in cropLocations)
            {
                if(!loc.isOccupied)
                {
                    GameObject cropGrow = Instantiate(cropGrowerPrefab);
                    cropGrow.transform.position = loc.transform.position;
                    loc.isOccupied = true;
                    cropGrow.GetComponent<CropGrower>().SetType(crop.type);
                    cropGrow.GetComponent<CropGrower>().loc = loc;
                    
                    break;
                }
            }


            Destroy(crop.gameObject);
        }
    }
}
