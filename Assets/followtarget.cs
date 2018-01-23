using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followtarget : MonoBehaviour {

    public Transform target;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    // Use this for initialization
    void Start() {

    }
        
	
	// Update is called once per frame
	void Update () {
        Refresh();
	}

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.TransformPoint(offsetPosition), ref velocity, smoothTime);
        }
        else
        {
            transform.position = transform.TransformPoint(target.forward);
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
}
