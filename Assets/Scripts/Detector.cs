using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Background" && collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
            if (GetComponentInParent<ParticleSystem>())
            {
                GetComponentInParent<ParticleSystem>().Play();
            }
        }
    }
}
