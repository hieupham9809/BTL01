using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
    public AudioSource AS_1;
    public AudioSource AS_2;
    public AudioClip Clip_1;
    public AudioClip Clip_2;
    // Use this for initialization

    void Awake()
    {
        AS_1 = gameObject.AddComponent<AudioSource>();
        //AS_1.playOnAwake = true;
        AS_1.volume = 1;
        AS_1.Play();
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
