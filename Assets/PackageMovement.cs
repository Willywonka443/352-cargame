using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageMovement : MonoBehaviour
{

    int counter = 0;
    int direction = 1;
    int maxDistance = 100;

    float moveSpeed = 0.01f;

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(counter) > maxDistance) {
            direction = direction * -1;
        }

        transform.Translate(0,moveSpeed * direction,0);

        if(direction > 0){
            counter--;
        }else{
            counter++;
        }

    }
}
