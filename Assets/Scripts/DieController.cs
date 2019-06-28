using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieController : MonoBehaviour
{
    private string currentScene;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5) SceneManager.LoadScene(currentScene);
    }

    public void Die()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        //Invoke("load", 2);
        //SceneManager.LoadScene("SampleScene");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer==LayerMask.NameToLayer("DeadlyObject"))
        {
            Die();
        }

    }
    private void load()
    {
        SceneManager.LoadScene(currentScene);
    }
}
