using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
    public GameObject player;
    public GameObject lookPosition;
    Transform t;
    public float height = 1;
    public float distance = 3;
    public float factor = 1;
	// Use this for initialization
	void Start () {
        t = player.transform;
	}
	
	// Update is called once per frame 
	void Update () {
        transform.position = t.position + new Vector3(t.position.normalized.x*factor, height, distance);
        transform.LookAt(lookPosition.transform);
        if (Input.GetKeyDown(KeyCode.C)) ChangeView();
	}
    void ChangeView()
    {
        distance = -distance;
    }
}
