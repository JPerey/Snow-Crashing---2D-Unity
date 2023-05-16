using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 30f;
    [SerializeField] float jumpAmount = 5f;
    // Start is called before the first frame update
    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb2d.AddTorque(torqueAmount);
        } else if(Input.GetKey(KeyCode.RightArrow)){
            rb2d.AddTorque(-torqueAmount);
        }
        
    }

    void OnCollisionStay2D(Collision2D other) {
        if (Input.GetKey(KeyCode.UpArrow)){
            rb2d.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
        }
    }
}
