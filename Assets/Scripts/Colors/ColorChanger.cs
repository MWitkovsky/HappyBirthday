using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

    public float changeDelay;

    private Material mat;
    private MeshRenderer rend;
    private float changeTimer;

    void Start()
    {
        mat = new Material(Shader.Find("Unlit/Color"));
        rend = GetComponent<MeshRenderer>();
        changeTimer = changeDelay;
    }
	
	void Update () {
        if(changeTimer <= 0.0f)
        {
            mat.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            rend.material = mat;
            changeTimer = changeDelay;
        }
        changeTimer -= Time.deltaTime;
	}
}
