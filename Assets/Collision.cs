using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Collision : MonoBehaviour
{
   
    [SerializeField] Color hasPackageColor = new Color(1,1,1,1);
    
    [SerializeField] Color noPackageColor = new Color(1,1,1,1);
    
    SpriteRenderer spriteRenderer;
    bool hasPackage = false;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void  OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("Car Crashed"); 
            SceneManager.LoadScene("SampleScene");
        } else{
            Debug.Log("OUCH!!!");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
       
       if(other.gameObject.tag == "Package" && !hasPackage){
            Debug.Log("Picked up package");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, 0.25f);
       } else if(other.gameObject.tag == "Customer" && hasPackage){
            Debug.Log("Package Delivered");
            hasPackage = false;
             spriteRenderer.color = noPackageColor;
            
       }
        
    }
   
        
    
}
