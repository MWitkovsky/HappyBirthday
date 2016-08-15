using UnityEngine;
using System.Collections.Generic;

public class ColorChangerSineText : MonoBehaviour {

    public float changeDelay;

    private Color color;
    private List<TextMesh> textMeshes;
    private float changeTimer;

    void Start()
    {
        changeTimer = changeDelay;
    }
	
	void Update () {
        if(changeTimer <= 0.0f)
        {
            color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            foreach(TextMesh text in textMeshes)
            {
                text.color = color;
            }
            changeTimer = changeDelay;
        }
        changeTimer -= Time.deltaTime;
	}

    public void SetTextMeshes(List<TextMesh> textMeshes)
    {
        this.textMeshes = textMeshes;
    }
}
