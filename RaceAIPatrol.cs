using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class RaceAIPatrol : MonoBehaviour
{
    public float speed; //speed of the NPC
    public float distance; //Distance of NPC travelled not sure its used in this script though.

    // private bool movingRight = true;

    public Transform groundDetection; //if we create a ground detection empty object put it 
    //on the ground and than just in front of AI the player will continue to move forward at the speed
    //set up. We could add to this script powers and other things.

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //player moving right AI

    }
}
