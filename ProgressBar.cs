using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;

    public float FillSpeed = 0.5f;
    private float targetProgress = 0;

    ///////////////////////////////////
    private Vector3 endPoint;
    private GameObject player; 
    private float startingDistance;
    private Vector3 startingDifference;
    ///////////////////////////////////

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ///////////////////////////////////
        endPoint = GameObject.Find("END").transform.position;
        player = GameObject.Find("Player");
        startingDifference = endPoint - player.transform.position;
        startingDistance = startingDifference.magnitude;
        ///////////////////////////////////
    }

    // Update is called once per frame
    void Update()
    {


        /////////////////////////////////////
        //// you can do it this way... but currently  the slider will not go
        //// back down if the player walks the wrong way
        //if (slider.value < targetProgress)
        //    slider.value += FillSpeed * Time.deltaTime;
        //Vector3 currentDifference = endPoint - player.transform.position;
        //float currentDistance = currentDifference.magnitude;
        //targetProgress = (1 - currentDistance / startingDistance) * 100;
        /////////////////////////////////////

        ///////////////////////////////////
        // this way uses only X distance, and fillspeed in both directions.
        float currentDifferenceX = endPoint.x - player.transform.position.x;
        targetProgress = (1 - currentDifferenceX / startingDifference.x) * 100;
        slider.value = Mathf.Lerp(slider.value, targetProgress, FillSpeed);
        ///////////////////////////////////

    }

    //Add progress to the bar
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value += newProgress;
    }
}
