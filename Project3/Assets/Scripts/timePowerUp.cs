//timePowerUp.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timePowerUp : MonoBehaviour
{
    // Duration of the power up
    public float duration;
    // The effect that plays when the power up is hit
    public GameObject effect;

    //Executes on powerup collision
    public void OnTriggerEnter(Collider other)
    {
        //When collider is triggered, checks if powerup collided with the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("PwrUp Picked\n");
            Debug.Log("Pre -StartCoroutine-\n");
            StartCoroutine(pickup(other));
            Debug.Log("Post -StartCoroutine-\n");
        }
    }
    
    /* @brief Creates the action for the power up and give the player some ability.
	** @pre The player has hit a power up.
	** @post The game slows down so that the player can make more swift decisions.
	** @return A time to wait*/
    IEnumerator pickup(Collider player)
    {
        Debug.Log("In coroutine\n");
        //Effect on pickup of powerup at the current position and rotation
        Instantiate(effect, transform.position, transform.rotation);
        PlayerController playerCont = player.GetComponent<PlayerController>();
        //
        Time.timeScale = 0.5f;
        playerCont.speed *= 2;
        playerCont.tilt = 2;
        //
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        //
        Debug.Log("Pre wait\n");

        yield return new WaitForSeconds(duration / 2);
        Debug.Log("Post wait\n");
        //back to normal
        Time.timeScale = 1.0f;
        playerCont.speed = 8;
        playerCont.tilt = 4;
        //
        Destroy(gameObject);
    }

}
