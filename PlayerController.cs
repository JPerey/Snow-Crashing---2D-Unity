using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 30f;
    [SerializeField] float jumpAmount = 20f;
    [SerializeField] float boostSpeed = 600f;
    [SerializeField] float baseSpeed = 150f;
    Transform playerTransform;
    int leftBool = 0;
    SurfaceEffector2D surfaceEffector2D;
    public FloorData floorScript;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        floorScript = GameObject.FindObjectOfType<FloorData>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
        TurnPlayer();
    }

    void RespondToBoost(){
        //if we push a key, then increase speed, otherwise stay normal speed
        //access the surfaceffector2D and change its speed
        if(Input.GetKey("z")){
            surfaceEffector2D.speed = boostSpeed;
        } else if(Input.GetKey("c")){
            surfaceEffector2D.speed = boostSpeed;
        }else {
            surfaceEffector2D.speed = baseSpeed;
        }
        
    }

    void TurnPlayer(){
        if (Input.GetKey("a") && leftBool == 0)
        {
            //float newSpeed = surfaceEffector2D.speed * -1;
            Vector3 currentScale = playerTransform.localScale;
            currentScale.x *= -1;
            playerTransform.localScale = currentScale;
            leftBool = 1;
            //surfaceEffector2D.speed = newSpeed;
            floorScript.ChangeDirection(0);
            //Debug.Log("player location: " + playerTransform.localScale);
        }
        if (Input.GetKey("d") && leftBool == 1)
        {
            //float newSpeed = surfaceEffector2D.speed * -1;
            Vector3 currentScale = playerTransform.localScale;
            currentScale.x *= -1;
            playerTransform.localScale = currentScale;
            leftBool = 0;
            floorScript.ChangeDirection(1);
            //surfaceEffector2D.speed = newSpeed;
        }
    }

    void RotatePlayer(){
        if (Input.GetKey(KeyCode.LeftArrow))
    {
        rb2d.AddTorque(torqueAmount);
    }
    else if (Input.GetKey(KeyCode.RightArrow))
    {
        rb2d.AddTorque(-torqueAmount);
    }  
    }
       
        // if (Input.GetKey("a") && leftBool == 0)
        // {
        //     Vector3 currentScale = playerTransform.localScale;
        //     currentScale.x *= -1;
        //     playerTransform.localScale = currentScale;
        //     leftBool = 1;
        //     floorScript.ChangeDirection(0);
        //     //Debug.Log("player location: " + playerTransform.localScale);
        // }
        // if (Input.GetKey("d") && leftBool == 1)
        // {
        //     Vector3 currentScale = playerTransform.localScale;
        //     currentScale.x *= -1;
        //     playerTransform.localScale = currentScale;
        //     leftBool = 0;
        //     floorScript.ChangeDirection(1);
        // }


    void OnCollisionStay2D(Collision2D other)
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2d.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);

        }
    }
}
