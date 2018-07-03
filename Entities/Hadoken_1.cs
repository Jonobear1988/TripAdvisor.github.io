using UnityEngine;
using System.Collections;

public class Hadoken : MonoBehaviour {
	public Fighter caster;

	private Rigidbody body;
	private float creationTime;

	// Use this for initialization
	void Start () {
		creationTime = Time.time;
		body = GetComponent<Rigidbody> ();
		body.AddRelativeForce (new Vector3 (200, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - creationTime > 3) {
			Destroy(gameObject);
		}
	}
}
