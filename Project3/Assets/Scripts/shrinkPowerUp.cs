using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrinkPowerUp : MonoBehaviour
{
    //effect of powerup pickup
    public float time;
    //variable for the effect on pickup
    public GameObject effect;
    //Executes on powerup collision
    public void OnTriggerEnter(Collider other)
    {
        //When collider is triggered, checks if powerup collided with the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Powerup picked up");
            //Time management for effect time and powerup period using the player object
            Debug.Log("Pre Coroutine");
            StartCoroutine (pickup(other));
            Debug.Log("post coroutine");
        }
    }
    //Player powerup pickup effects
    IEnumerator pickup(Collider player)
    {
        Debug.Log("Start of pickup function");
        //Effect on pickup of powerup at the player's current position and rotation
        Instantiate(effect, player.transform.position, player.transform.rotation);
        //shrinks ship to half size
        player.transform.localScale /= 2;
        PlayerController playerVar = player.GetComponent<PlayerController>();
        //doubles the player's speed
        playerVar.speed *= 2;
        //removes power up visuals after pickup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Debug.Log("pre wait");
        //waits for the given power up duration
        yield return new WaitForSeconds(time);
        Debug.Log("after wait");
        //ship grows to original size
        player.transform.localScale *= 2;
        //player's speed returns to original value
        playerVar.speed /= 2;
        //destroys power up object when effects wear off
        Destroy(gameObject);
    }
}
