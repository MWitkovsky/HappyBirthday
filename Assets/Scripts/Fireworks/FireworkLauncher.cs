using UnityEngine;
using System.Collections;

public class FireworkLauncher : MonoBehaviour {

    public GameObject firework;
    public float initalDelay;
    public float maxLaunchDelay;

    private Transform left, right;
    private float launchTimer;


	void Start () {
        left = GameObject.Find("Left").transform;
        right = GameObject.Find("Right").transform;
	}

	void Update () {
        if(initalDelay <= 0.0f)
        {
            launchTimer -= Time.deltaTime;

            if (launchTimer <= 0.0f)
            {
                LaunchFirework();
                launchTimer = Random.Range(0.0f, maxLaunchDelay);
            }
        }
        else
        {
            initalDelay -= Time.deltaTime;
        }
	}

    void LaunchFirework()
    {
        Vector3 position = new Vector3(Random.Range(left.position.x, right.position.x), transform.position.y, transform.position.z);
        GameObject o = (GameObject)Instantiate(firework, position, transform.rotation);
        o.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Random.Range(4.0f, 14.0f), ForceMode2D.Impulse);
        o.transform.parent = GameObject.Find("FireworkContainer").transform;
    }
}
