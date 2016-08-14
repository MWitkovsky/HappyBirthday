using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float lifetime = 1.5f;
	
	void Update () {
	    if(lifetime <= 0.0f)
        {
            Destroy(gameObject);
        }

        lifetime -= Time.deltaTime;
	}
}
