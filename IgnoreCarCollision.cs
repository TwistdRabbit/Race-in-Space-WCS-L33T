using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCarCollision : MonoBehaviour
{
    void Start()
    {
        //Fetch the Rigidbody component from the GameObject
        GetComponent<Rigidbody2D>();
        //Ignore the collisions between layer 0 and layer 0, code will only acept 2 layers in each line
        Physics2D.IgnoreLayerCollision(0, 0);
        //Physics2D.IgnoreLayerCollision(0, 0);//Extra lines can be added for more collisions if needed just add the layer number
    }
     void Update()
    {

    }

}
