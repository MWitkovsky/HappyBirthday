using UnityEngine;
using System.Collections;

public class Firework : MonoBehaviour
{
    public GameObject fireworkParticleHolder, fireworkParticle;
    public float explosionDelay;

    private Rigidbody2D rb;
    private float explosionTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        explosionTimer = explosionDelay;
    }

    void FixedUpdate()
    {
        if (rb.velocity.y < 0.0f)
        {
            if (explosionTimer <= 0.0f)
            {
                Explode();
            }
            explosionTimer -= Time.fixedDeltaTime;
        }
    }

    private void Explode()
    {
        ColorChanger2 holder = ((GameObject)Instantiate(fireworkParticleHolder, transform.position, transform.rotation)).GetComponent<ColorChanger2>();
        holder.transform.parent = GameObject.Find("FireworkContainer").transform;
        while (!holder.AtMaxParticles())
        {
            GameObject particle = (GameObject)Instantiate(fireworkParticle, transform.position, transform.rotation);
            Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            particle.GetComponent<Rigidbody2D>().AddForce(direction * Random.Range(5.0f, 30.0f), ForceMode2D.Impulse);
            particle.transform.parent = holder.transform;
            holder.AddParticle(particle);
        }
        Destroy(gameObject);
    }
}
