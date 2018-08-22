using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    
    public float upForce;

    private bool isDead = false;
    private Animator anim;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(!isDead){

            if(Input.GetMouseButtonDown(0) || Input.anyKeyDown){

                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
	}

    private void OnCollisionEnter2D(){

        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameController.instance.BirdDied();
    }

    private void OnTriggerEnter2D(Collider2D other){

        if (other.gameObject.CompareTag("PickUp")){

            other.gameObject.SetActive(false);
            GameController.instance.PickUpCoin();
        }
    }
}
