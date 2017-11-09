using UnityEngine;
using System.Collections;

public class projecttileController : MonoBehaviour {
    public float bulletSpeed;

    Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            myBody.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            myBody.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Tao chuc nang lam vien dan dung lai
    public void removeForce()
    {
        myBody.velocity = new Vector2(0, 0);
    }
}
