using UnityEngine;
using System.Collections;

public class ScrollText : MonoBehaviour {

    public float speed;
    public float initalDelay;

	void Update () {
        if(initalDelay <= 0.0f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < -27.0f)
            {
                transform.Translate(Vector3.right * 36.5f);
            }
        }
        else
        {
            initalDelay -= Time.deltaTime;
        }
	}
}
