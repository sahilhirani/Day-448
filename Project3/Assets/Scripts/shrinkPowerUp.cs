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
            //Time management for effect time and powerup period using the player object
            StartCoroutine (pickup(other));
        }
    }
    //Player powerup pickup effects
    IEnumerator pickup(Collider player)
    {
        //Effect on pickup of powerup at the player's current position and rotation
        Instantiate(effect, player.transform.position, player.transform.rotation);
        //shrinks ship to half size
        player.transform.localScale = new Vector3(0.2f, 0.4f, 0.5f);
        PlayerController playerVar = player.GetComponent<PlayerController>();
        //doubles the player's speed
        playerVar.speed *= 2;
        //removes power up visuals after pickup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        //waits for the given power up duration
        yield return new WaitForSeconds(time);
        //ship grows to original size
        player.transform.localScale = new Vector3(0.4f, 0.8f, 0.10f);
        //player's speed returns to original value
        playerVar.speed /= 2;
        //destroys power up object when effects wear off
        Destroy(gameObject);
    }
}
