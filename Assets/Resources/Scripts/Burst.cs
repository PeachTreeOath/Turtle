using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour {

    float time;
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > 1)
            Destroy(gameObject);
	}
}
