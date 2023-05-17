using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 30f;
    [SerializeField] float jumpAmount = 20f;
    Transform playerTransform; 
    int leftBool = 0;
    // Start is called before the first frame update
    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
       playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb2d.AddTorque(torqueAmount);
        } else if(Input.GetKey(KeyCode.RightArrow)){
            rb2d.AddTorque(-torqueAmount);
        }
        if(Input.GetKey("a") && leftBool == 0){
            Vector3 currentScale = playerTransform.localScale;
            currentScale.x *= -1;
            playerTransform.localScale = currentScale;
            leftBool = 1;
            //Debug.Log("player location: " + playerTransform.localScale);
        }
        if(Input.GetKey("d") && leftBool == 1){
            Vector3 currentScale = playerTransform.localScale;
            currentScale.x *= -1;
            playerTransform.localScale = currentScale;
            leftBool = 0;
        }
        
    }

    void OnCollisionStay2D(Collision2D other) {
        if (Input.GetKey(KeyCode.UpArrow)){
                rb2d.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
            
        }
    }
}
