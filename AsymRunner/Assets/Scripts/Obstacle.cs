using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 10.0f;
    public float delX;
    // Update is called once per frame
    private void Start()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (transform.position.x < delX)
        {
           Destroy(this.gameObject);
        }
        else
        {
            MoveObstacle();
        }
       
       

    }
    void MoveObstacle()
    {
        transform.Translate(new Vector2(-1,0) * speed * Time.deltaTime);
    }
}