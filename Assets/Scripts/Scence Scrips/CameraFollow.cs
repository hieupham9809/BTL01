using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float smoothing;
    Vector3 offset;
    float lowY;
    float highY;
    // Use this for initialization
    void Awake() {
        transform.position = new Vector3(target.position.x+4, target.position.y+6, transform.position.z-5);
    }

	void Start () {
        offset = transform.position - target.position;
        lowY = transform.position.y;
        highY = transform.position.y;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        if (transform.position.y > highY) transform.position = new Vector3(transform.position.x, highY, transform.position.z);
	}
}
