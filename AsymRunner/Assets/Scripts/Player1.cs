using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public static Player1 singleton;
    public SpriteRenderer sprite;
    public float jumpForce;
    public ForceMode2D forcemode;
    private Vector2 screenBounds;
    public Camera cam;
    public bool onGround;


    public SkinObject[] skins;
    public int currentSkin;

    private float hueValue;

    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            enabled = false;
        }
         sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = skins[currentSkin].Icon;
    }

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        cam.backgroundColor = Color.HSVToRGB(0, 0.6f, 0.8f);
        

        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = new Vector3(Time.time * speed, this.transform.position.y, 0);
        if(GameManager.singleton.isStart == false)
        {
            if (transform.position.x >= -screenBounds.x)
            {
                if (Input.GetKeyDown("z"))
                {
                    Jump(skins[currentSkin].JumpForce , forcemode);
                }
            }
            else
            {
                Destroy(this.gameObject);
                GameManager.singleton.GameOver();
            }
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.EndsWith("nd") || collision.gameObject.name.EndsWith(")"))
        {
            onGround = true; 
        }
    }
    void Jump(float jumpForce, ForceMode2D forceMode)
    {
        if (onGround)
        {

            rb.AddForce(new Vector2(0, jumpForce), forceMode);
            hueValue += 0.1f;
            if (hueValue >= 1)
            {
                hueValue = 0;
            }
            cam.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.8f);
            onGround = false;
        }
    }
    
    

}
