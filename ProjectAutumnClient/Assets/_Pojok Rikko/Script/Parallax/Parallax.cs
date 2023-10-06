using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startPosX, startPosY, height;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Parallax fot Horizontal
        float tempX = (cam.transform.position.x * (1- parallaxEffect));
        float distX = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPosX + distX, transform.position.y, transform.position. z);

        if(tempX > startPosX + length) startPosX += length;
        else if (tempX < startPosX - length) startPosX -= length;

        
    }


}
