using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public float delX;
    public float speed = 10f;

    public void Update()
    {
        //Check if its outside screen to destroy (optimizer)
        if (transform.position.x < delX)
        {
            Destroy(this.gameObject);
        }
        else
        {
            MoveObstacle();
        }



    }

    
    public void MoveObstacle()
    {
        transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.singleton.AddCoin();
        //TODOplay coin sound
        //TODO particle effect
        Destroy(this.gameObject);
    }
}
