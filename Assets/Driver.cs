
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] float SteerSpeed = 1f; 
    [SerializeField] float MoveSpeed = 1f;
    [SerializeField] float slowSpeed = 0.8f;
    [SerializeField] float boostSpeed = 1.6f;

    
    public void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Hit something!");
        MoveSpeed = slowSpeed; 
    }
    public void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.tag == "boost")
        {
            MoveSpeed = boostSpeed;
            Debug.Log("I can feel the wind on my bald noggin");
        }
    }
    void Update()
    {
        float SteerAmount = Input.GetAxis("Horizontal") * SteerSpeed * Time.deltaTime;
        float MoveAmount = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -SteerAmount);
        transform.Translate(0, MoveAmount, 0);
    }
}
