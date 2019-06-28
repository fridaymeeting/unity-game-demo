using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragFloor : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallSpeed=10;
    public float fallTime=0.1f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Invoke("fall", fallTime);
        }
    }
    private void fall()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * fallSpeed;
    }
}
