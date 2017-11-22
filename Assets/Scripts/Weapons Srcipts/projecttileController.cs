using UnityEngine;
using System.Collections;

public class projecttileController : MonoBehaviour {
    public float bulletSpeed;       //speed of bullet
    Rigidbody2D myBody;             //rigibody2D of bullet

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();                                               //get rigibody2D component
        if (transform.localRotation.z > 0)
        {
            myBody.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);         //add force for bullet
        }
        else
        {
            myBody.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);          //add force for bullet
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
        myBody.velocity = new Vector2(0, 0);                                                //remove the force
    }
}
