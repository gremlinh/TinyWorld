using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    public GameObject playerMesh;
    Animator anim;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        anim = playerMesh.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("speed", rb.velocity.magnitude);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("jump", true);
        }
        else anim.SetBool("jump", false);
	}
}
