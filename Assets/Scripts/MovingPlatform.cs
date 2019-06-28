using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float speed = 5f;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        //rig.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (transform.position.x > maxX && speed>0.1f || transform.position.x < minX && speed < -0.1f) speed=-speed;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            collision.transform.parent= gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
