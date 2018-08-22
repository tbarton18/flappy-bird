using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other){

        if (other.GetComponent<Bird>() != null)
        {
            
            //GameObject pickUp = GameObject.FindGameObjectWithTag("PickUp");
            //pickUp.SetActive(false);
            //GameController.instance.PickUpCoin();
        }
    }
}
