using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flee : MonoBehaviour {

    private NavMeshAgent agent;

    public Transform[] destinations;
    private int i;

    private Animator anim;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
	}

    void Update()
    {
        anim.SetFloat("speed", agent.velocity.magnitude);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!(i+1 < destinations.Length)) i = 0;
            else ++i;
            agent.SetDestination(destinations[i].position);
        }
    }
}
