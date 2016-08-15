using UnityEngine;
using System.Collections.Generic;

public class SineText : MonoBehaviour {

    public GameObject characterContainer;
    public string text;
    public float sineOffset = 5.0f;
    public float maxUpAndDown = 1.0f;
    public float speed = 200.0f;

    private List<TextMesh> textMeshes;
    private float spacing = 0.0f;
    private float angle = 0.0f;
    private float center = 0.0f;
    private const float toDegrees = Mathf.PI/180.0f; 

	void Start () {
        textMeshes = new List<TextMesh>();
        center = transform.position.y;

        float offset = 0.0f;
	    while (text != "")
        {
            Vector3 position = transform.position;
            position.x += offset;
            GameObject o = (GameObject)Instantiate(characterContainer, position, transform.rotation);
            TextMesh t = o.GetComponent<TextMesh>();
            t.text = text.Substring(0, 1);
            offset += (o.GetComponent<Renderer>().bounds.extents.x * 2.0f) + spacing;
            text = text.Substring(1);
            o.transform.parent = transform;
            textMeshes.Add(t);
        }

        FindObjectOfType<ColorChangerSineText>().SetTextMeshes(textMeshes);
	}

	void Update () {
        angle += speed * Time.deltaTime;
        if (angle > 360.0f)
        {
            angle -= 360.0f;
        }

        float offsetAngle = angle;
        foreach(TextMesh t in textMeshes)
        {
            offsetAngle += sineOffset;
            if (offsetAngle > 360.0f)
            {
                offsetAngle -= 360.0f;
            }

            Vector3 position = t.transform.position;
            position.y = center + maxUpAndDown * Mathf.Sin(offsetAngle * toDegrees);
            t.transform.position = position;
        }
    }

    public List<TextMesh> GetTextMeshes()
    {
        return textMeshes;
    }
}
