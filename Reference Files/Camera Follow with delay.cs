using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    float timeOffset;

    [SerializeField]
    Vector2 posOffset;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera Start Position
        Vector3 startPos = transform.position;

        //Player Start Position
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;


        //This is how you lerp
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        //This is how you use smooth dampening
        //transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);

    }
}
