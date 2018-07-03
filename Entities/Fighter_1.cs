using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {
	public enum PlayerType
	{
		HUMAN, AI	
	};

	public static float MAX_HEALTH = 100f;

	public float healt = MAX_HEALTH;
	public string fighterName;
	public Fighter oponent;

	public PlayerType player;
	public FighterStates currentState = FighterStates.IDLE;

	protected Animator animator;
	private Rigidbody myBody;
	private AudioSource audioPlayer;
	
	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
		audioPlayer = GetComponent<AudioSource> ();
	}

	public void UpdateHumanInput (){
		if (Input.GetAxis ("Horizontal") > 0.1) {
			animator.SetBool ("WALK", true);
		} else {
			animator.SetBool ("WALK", false);
		}

		if (Input.GetAxis ("Horizontal") < -0.1) {
			animator.SetBool ("WALK_BACK", true);
		} else {
			animator.SetBool ("WALK_BACK", false);
		}

		if (Input.GetAxis ("Vertical") < -0.1) {
			animator.SetBool ("DUCK", true);
		} else {
			animator.SetBool ("DUCK", false);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			animator.SetTrigger("JUMP");
		} 

		if (Input.GetKeyDown (KeyCode.Space)) {
			animator.SetTrigger("PUNCH");
		}

		if (Input.GetKeyDown (KeyCode.K)) {
			animator.SetTrigger("KICK");
		}

		if (Input.GetKeyDown (KeyCode.H)) {
			animator.SetTrigger("HADOKEN");
		}
	}

	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("health", healtPercent);

		if (oponent != null) {
			animator.SetFloat ("oponent_health", oponent.healtPercent);
		} else {
			animator.SetFloat ("oponent_health", 1);
		}

		if (player == PlayerType.HUMAN){
			UpdateHumanInput();
		}
	}
	public void playSound(AudioClip sound){
		GameUtils.playSound (sound, audioPlayer);
	}


	public float healtPercent {
		get {
			return healt / MAX_HEALTH;
		}	
	}

	public Rigidbody body {
		get {
			return this.myBody;
		}
	}
}
