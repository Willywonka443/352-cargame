using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.099f;
    [SerializeField] float currentSpeed = 0.01f;
    
    [SerializeField] float boostSpeed = 0.03f;

    [SerializeField] float bumpSpeed  = 0.01f;
    [SerializeField] float normalSpeed = 0.01f;
    float startSpeed;
    bool hasBoost = false;
    bool hasSlow = false;
    
    // Start is called before the first frame update
    void Start()
    {
        startSpeed = currentSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other) {
      
       if(other.tag == "Boost" && !hasSlow){
            Debug.Log("I have my zoomies");
            currentSpeed = boostSpeed;
            hasBoost = true;
       }else if(other.gameObject.tag == "Boost" && hasSlow){
            currentSpeed = normalSpeed;
            hasSlow = false;
           
       }

       if(other.gameObject.tag == "Bumps" && !hasBoost){
            Debug.Log("You shall Slow Down");
            currentSpeed = bumpSpeed;
            hasSlow = true;
       }else if(other.gameObject.tag == "Bumps" && hasBoost){
            Debug.Log("This is normal");
            currentSpeed = normalSpeed;
            hasBoost = false;
            
       } 
        

    }
    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount * steerSpeed);
        transform.Translate(0,speedAmount * currentSpeed,0);
    }
}
 