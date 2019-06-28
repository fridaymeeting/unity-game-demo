using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeControl : MonoBehaviour
{
    public Sprite spikeSprite;
    // Start is called before the first frame update
    private SpriteRenderer r;
    void Start()
    {
        r = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            r.sprite = spikeSprite;
            collision.gameObject.GetComponent<DieController>().Die();
        }
    }
}
