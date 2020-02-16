using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    public BoxController boxInst;
    private BoxController currentlyHeldBox;

    [Header("Boolean")]
    [SerializeField] private bool onLadder;
    [SerializeField] private bool grabLadder;
    public bool inGrabRange;
    public bool holding;

    private float range = 0.5f;

    [Header("2DVec")]
    protected Vector2 move;

    [Header("Values")]
    [SerializeField]
    protected float jumpTakeOffSpeed;
    [SerializeField]
    protected int playerNumber = 1;
    [SerializeField]
    protected float maxSpeed = 1.6f;
    [SerializeField]
    private float ladderSpeed = 3;
    [SerializeField]
    private float heavyBoxModifier = 0.5f;

    private float speedModifier = 1f;



    public bool facingRight = true;


    protected override void Start()
    {
        base.Start();
        onLadder = false;
        grabLadder = false;
        facingRight = true;
    }

    protected override void FixedUpdate(){

        base.FixedUpdate();
        if (InputManager.GetHorizontal(playerNumber) < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            facingRight = false;
        }
        else if (InputManager.GetHorizontal(playerNumber) > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            facingRight = true;
        }

        checkBoxInRange(); //uses pythagoreaon to check for closest box in range. (Using this since original collider idea didnt seem to work)
        if (InputManager.IsShipping(playerNumber)) //if player presses button
        {
            pickUpBox();

        }
    }

    protected override void ComputeVelocity()
    {
        move = Vector2.zero;
        move.x = InputManager.GetHorizontal(playerNumber);

        if (onLadder && InputManager.GetVertical(playerNumber) != 0) 
        {
            grabLadder = true;
        }
        else if (!onLadder){
            grabLadder = false;
            gravityModifier = initialGravityModifier;
        }

        if (grabLadder)
        {
            velocity.y = InputManager.GetVertical(playerNumber) * ladderSpeed * speedModifier;
            gravityModifier = 0;
        }

        if (Mathf.Abs(velocity.x) > 0)
        {
            gameObject.GetComponent<Animator>().SetBool("moving", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }

        targetVelocity = move * maxSpeed * speedModifier;
    }

    protected private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == Tags.LADDER)
        {
            onLadder = true;
        } 
        /*
        else if (collision.tag == Tags.BOX)
        {
            Debug.Log("colliding trigger");
            boxInst = collision.gameObject;
            Debug.Log(boxInst);
            // grabBox = true;
        }
        */
    }
    /*
    protected private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == Tags.BOX)
        {
            Debug.Log("colliding");
            boxInst = collision.collider.gameObject;
            Debug.Log(boxInst);
            inGrabRange = true;
        }
    }
    */

    private void checkBoxInRange() {
        BoxController[] boxes = FindObjectsOfType<BoxController>();
        if (boxes.Length > 0) {
            boxInst = boxes[0];
        }
        for (int i = 1; i < boxes.Length; i++) {
            //pythagorean to check which boxes are closest
            float x1 = Mathf.Pow(boxes[i].transform.position.x - gameObject.transform.position.x, 2);
            float y1 = Mathf.Pow(boxes[i].transform.position.y - gameObject.transform.position.y, 2);
            float x2 = Mathf.Pow(boxInst.transform.position.x - gameObject.transform.position.x, 2);
            float y2 = Mathf.Pow(boxInst.transform.position.y - gameObject.transform.position.y, 2);

            if (x1 + y1 < x2 + y2) {
                boxInst = boxes[i];
            }
        }
        float x = Mathf.Pow(boxInst.transform.position.x - gameObject.transform.position.x, 2);
        float y = Mathf.Pow(boxInst.transform.position.y - gameObject.transform.position.y, 2);

        if (x + y <= Mathf.Pow(range, 2))
        {
            inGrabRange = true;
        }
        else {
            inGrabRange = false;
        }
    }

    // protected private void OnCollisionExit2D(Collision2D collision) {
    //     if(collision.collider.tag == Tags.BOX && inGrabRange)
    //     {
    //         Debug.Log("Leaving collision");
    //         inGrabRange = false;
    //         boxInst = null;
    //     }
    // }

    protected private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Tags.LADDER)
        {
            onLadder = false;
        }

    }

    private void pickUpBox() {


		if (holding)
		{
			boxInst.GetComponent<BoxCollider2D>().isTrigger = false;
			boxInst.transform.parent = null;
			holding = false;
			boxInst.GetComponent<Rigidbody2D>().simulated = true;
			gameObject.GetComponent<Animator>().SetBool("holding", false);
			speedModifier = 1f;
        }
        else if(inGrabRange && !holding)
        {

            if (boxInst.transform.parent != null) {
                boxInst.transform.parent.gameObject.GetComponent<PlayerController>().holding = false;
                boxInst.transform.parent.gameObject.GetComponent<PlayerController>().boxInst = null;
                boxInst.transform.parent.gameObject.GetComponent<Animator>().SetBool("holding", false);
            }


			gameObject.GetComponent<Animator>().SetBool("holding", true);
			boxInst.GetComponent<BoxCollider2D>().isTrigger = true;
			holding = true;

            //Mathf.Sign(gameObject.transform.position.x - boxInst.transform.position.x)
            //boxInst.transform.position = gameObject.transform.position + new Vector3(-0.25f, 0.22f, -1.0f);
			if (facingRight)
			{
				boxInst.transform.position = gameObject.transform.position + new Vector3(0.25f, 0.22f , -1.0f);
			}
			else
			{
				boxInst.transform.position = gameObject.transform.position + new Vector3(-0.25f, 0.22f, -1.0f);
			}
            boxInst.transform.parent = gameObject.transform;
            boxInst.GetComponent<Rigidbody2D>().simulated = false;
			if (boxInst.isBoxHeavy())
            {
                speedModifier = heavyBoxModifier;
            }
        }
        
    }
    
}