using UnityEngine;
using System.Collections;

public class DirectionCheck : MonoBehaviour {

    public Direction facing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            if (other.gameObject.tag == "pushable")
            {
                //Debug.Log(this.GetComponentInParent<Movement>().obstruction[]);
            }
        }
        
    }
}
