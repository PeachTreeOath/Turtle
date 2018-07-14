﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehavior : Singleton<MoveBehavior>
{
    public GameObject cropGrowerPrefab;

    public float speed;

    public List<CropLocation> cropLocations = new List<CropLocation>();

    // Update is called once per frame
    void Update()
    {

        float hSpd = speed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        float vSpd = speed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        if (hSpd < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (hSpd > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        transform.position = new Vector2(transform.position.x + hSpd, transform.position.y + vSpd);
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
        }
    }
}