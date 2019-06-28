using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlatformerControllerChan : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private Animator animator;
    private bool faceRight;

    // Use this for initialization
    void Awake () 
    {
        animator = GetComponent<Animator> ();
        faceRight = true;
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        if (Input.GetButtonDown ("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
        } else if (Input.GetButtonUp ("Jump")) 
        {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if(move.x > 0.01f)
        {
            if(!faceRight)
            {
                gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            faceRight = true;
        } 
        else if (move.x < -0.01f)
        {
            if(faceRight)
            {
                gameObject.transform.localEulerAngles = new Vector3(0, 180, 0);
            }
            faceRight = false;
        }

        animator.SetBool ("grounded", grounded);
        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
    //public void Die()
    //{
    //    SceneManager.LoadScene("SampleScene");
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("DeadlyObject"))
    //    {
    //        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * 3;
    //        Invoke("Die", 3);
    //    }
    //}
}