using UnityEngine;
using System.Collections;

public class EnemyCloner : MonoBehaviour {
    public GameObject zoombie;
    public float cloneRate;
    float nextClone;
	// Use this for initialization
	void Start () {
        nextClone = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextClone)
        {
            Instantiate(zoombie, transform.position, transform.rotation);
            nextClone = Time.time + cloneRate;
        }
	}
}
