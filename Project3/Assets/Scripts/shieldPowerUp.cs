using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldPowerUp : MonoBehaviour
{
    //effect of powerup pickup
    public float time;
    //variable for the effect on pickup
    public GameObject effect;
    //the shield that appears
    public GameObject shieldFX;

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
	** @post The player ship is wrapped with a shield to prevent damage for some amount of time.
	** @return A time to wait*/
    IEnumerator pickup(Collider player)
    {
        //Effect on pickup of powerup at the player's current position and rotation
        GameObject toFollow = GameObject.FindGameObjectWithTag("ToFollow");
        GameObject myShield = Instantiate(shieldFX, player.transform.position, Quaternion.identity);
        myShield.transform.parent = toFollow.transform;
        GameObject myEffect = Instantiate(effect, player.transform.position, player.transform.rotation);
        myEffect.transform.parent = player.transform;
        //removes power up visuals after pickup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        //waits for the given power up duration
        yield return new WaitForSeconds(time);
        //destroys power up object when effects wear off
        GameObject powerUp = GameObject.FindGameObjectWithTag("PowerUp");
        Destroy(powerUp);
        Destroy(gameObject);
    }
}
