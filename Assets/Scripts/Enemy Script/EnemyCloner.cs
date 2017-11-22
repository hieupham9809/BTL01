using UnityEngine;
using System.Collections;

public class EnemyCloner : MonoBehaviour {

    public GameObject zoombie;  //the zoombie
    public float cloneRate;     //the minimum time betwween 2 clone
    float nextClone;
    Vector3 zoompos;         
	// Use this for initialization
    void Awake()
    {
        zoompos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
    }

	void Start () {
        nextClone = 0.0f;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextClone)
        {
            Instantiate(zoombie, zoompos, transform.rotation);              //clone the zoombie
            nextClone = Time.time + cloneRate;                              //update next clone

        }
	}
}
