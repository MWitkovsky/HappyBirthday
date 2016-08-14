using UnityEngine;
using System.Collections;

public class ColorChanger2 : MonoBehaviour
{
    public float changeDelay;

    private GameObject[] particles = new GameObject[20];
    private Material mat;
    private MeshRenderer rend;
    private float changeTimer;
    private int index = 0;

    void Start()
    {
        mat = new Material(Shader.Find("Unlit/Color"));
        changeTimer = changeDelay;
    }

    void Update()
    {
        if (changeTimer <= 0.0f)
        {
            mat.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            foreach (GameObject o in particles)
            {
                rend = o.GetComponent<MeshRenderer>();
                rend.material = mat;
            }
            changeTimer = changeDelay;
        }
        changeTimer -= Time.deltaTime;
    }

    public void AddParticle(GameObject particle)
    {
        particles[index] = particle;
        index++;
    }

    public bool AtMaxParticles()
    {
        return index == particles.Length;
    }
}
