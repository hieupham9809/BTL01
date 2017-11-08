using UnityEngine;
using System.Collections;

public class destroyMe : MonoBehaviour {

    public float alivetime;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, alivetime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
