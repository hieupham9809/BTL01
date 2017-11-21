using UnityEngine;
using System.Collections;

public class EnemyCloner : MonoBehaviour {

    public GameObject zoombie;  //the zoombie
    public float cloneRate;     //the minimum time betwween 2 clone
    float nextClone;            
	// Use this for initialization
	void Start () {
        nextClone = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextClone)
        {
            Instantiate(zoombie, transform.position, transform.rotation);   //clone the zoombie
            nextClone = Time.time + cloneRate;                              //update next clone

        }
	}
}
