using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public float amount=0.8f;
    public float fallSpeed=8f;
    public float ymin=-5f;
    private Rigidbody2D rig;
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > gameObject.transform.position.x - amount)
        {
            if (rig.bodyType==RigidbodyType2D.Kinematic)
            {
                rig.velocity = Vector2.down * fallSpeed;
            }
            else
            {
                rig.gravityScale = 2;
            }
        }
        if (gameObject.transform.position.y < ymin)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Background" && collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
            if (GetComponent<ParticleSystem>())
            {
                GetComponent<ParticleSystem>().Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Background" && collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
            if (GetComponent<ParticleSystem>())
            {
                GetComponent<ParticleSystem>().Play();
            }
        }
    }
    
}
