using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnAnimation : MonoBehaviour {

    // OBJECT SPAWN ANIMATION

    [SerializeField] float time;
    [SerializeField] float sizeX = 1;
    [SerializeField] float sizeY = 1;
    [SerializeField] float sizeZ = 1;

    float moveTime;
    bool moving;

    private void OnEnable()
    {
        moving = true;
        moveTime = time;
        transform.localScale = Vector3.zero;
    }
    
    void FixedUpdate()
    {

        if (moving)
        {
            moveTime -= Time.deltaTime;
            transform.localScale = Vector3.Lerp(new Vector3(sizeX, sizeY, sizeZ), Vector3.zero, moveTime / time);
            
            if (moveTime <= 0)
            {
                moving = false;
            }
        }
    }
}
