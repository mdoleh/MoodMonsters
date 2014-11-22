using UnityEngine;
using System.Collections;

public class ApproachPlayer : MonoBehaviour {

    bool moveTowardPlayer = false;
    GameObject player;
    CharacterMotor playerMotor;
    MouseLook playerLook;
    Animator anim;
    NavMeshAgent nav;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player"); // find where player is
        playerMotor = player.GetComponent<CharacterMotor>();
        playerLook = player.GetComponent<MouseLook>();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (moveTowardPlayer)
        {
            playerMotor.enabled = false;
            playerLook.enabled = false;
            nav.SetDestination(player.transform.position);
            anim.SetBool("IsWalking", true);
        }
	}

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag.ToLower() == "player")
        {
            StopApproach();
        }
    }

    public void StopApproach()
    {
        moveTowardPlayer = false;
        anim.SetBool("IsWalking", false);
        nav.enabled = false;
        anim.SetTrigger("IsTakingItem");
    }

    public void StartApproach() {
        moveTowardPlayer = true;
    }
}
