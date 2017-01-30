using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cuicui : MonoBehaviour
{

    private Rigidbody rb;

    public Transform[] destinations;
    private int i;

    public float flyHeightMax = 1f;
    public float speed = 0f;
    private float distance = 1f;
    float remainingDist = 0f;

    private Transform destination;
    private Vector3 startPosition;
    private Vector3 midPosition;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        destination = transform;

        startPosition = transform.position;
    }

    void Update()
    {
        anim.SetFloat("speed", rb.velocity.magnitude);
        if(transform.position != destination.position)
        {
            remainingDist -= (speed * Time.deltaTime);
            remainingDist = (remainingDist < 0) ? 0 : remainingDist;
            transform.position = Vector3.Lerp(startPosition, destination.position, (distance - (remainingDist)) / distance)
                + new Vector3(0,flyHeightMax * 1/Mathf.Abs((distance/2 - (remainingDist)) / (distance/2)) - flyHeightMax, 0);
        }
        else
        {
            rb.velocity = new Vector3(0f,0f,0f);
            anim.SetFloat("speed", 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!(i + 1 < destinations.Length)) i = 0;
            else ++i;
            destination = destinations[i];
            remainingDist = distance = Vector3.Distance(transform.position, destination.position);
            startPosition = transform.position;
            transform.LookAt(destination);
            transform.rotation *= Quaternion.Euler(new Vector3(0, transform.rotation.y, 0));
        }
    }
}
