using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserPowerUp : MonoBehaviour
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
            StartCoroutine(pickup(other));
        }
    }
    
    /* @brief Creates the action for the power up and give the player some ability.
	** @pre The player has hit a power up.
	** @post The player ship fires a laser at a continuous rate for some amount of time.
	** @return A time to wait*/
    IEnumerator pickup(Collider player)
    {
        Debug.Log("Start of pickup function");
        //Effect on pickup of powerup at the player's current position and rotation
        Instantiate(effect, player.transform.position, player.transform.rotation);
        PlayerController playerVar = player.GetComponent<PlayerController>();
        playerVar.laserUpgrade = true;
        //removes power up visuals after pickup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        //waits for the given power up duration
        yield return new WaitForSeconds(time);
        playerVar.laserUpgrade = false;
        //destroys power up object when effects wear off
        Destroy(gameObject);
    }
}

