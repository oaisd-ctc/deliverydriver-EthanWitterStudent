using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{   
    [SerializeField] Color32 hasPackageColor = new Color32 (63, 174, 24, 255);
    [SerializeField] Color32 noPackageColor = new Color32 (255,255,255,255);
   bool HasPackage; 
   [SerializeField] float Destorytime = 0f;
    

    SpriteRenderer spriteRenderer;
    public void Start() 
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    

    public void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Hit something!");
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !HasPackage)
        {
            Debug.Log("Package Obtained!");
            HasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, Destorytime);
        }

        if(other.tag == "Customer" && HasPackage)
        {
            Debug.Log("Delivery!");
            HasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
