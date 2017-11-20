using UnityEngine;
using System.Collections;

public class destroyMe : MonoBehaviour {

    public float alivetime;                 //the time alve

	// Use this for initialization
	void Start () {
        Destroy(gameObject, alivetime);     //destroy game object
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
