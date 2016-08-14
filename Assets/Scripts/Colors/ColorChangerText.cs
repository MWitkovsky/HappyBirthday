using UnityEngine;
using System.Collections;

public class ColorChangerText : MonoBehaviour {

    public float changeDelay;

    private Color color;
    private TextMesh text;
    private float changeTimer;

    void Start()
    {
        text = GetComponent<TextMesh>();
        changeTimer = changeDelay;
    }
	
	void Update () {
        if(changeTimer <= 0.0f)
        {
            color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            text.color = color;
            changeTimer = changeDelay;
        }
        changeTimer -= Time.deltaTime;
	}
}
