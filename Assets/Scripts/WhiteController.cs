using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteController : MonoBehaviour
{
    public GameObject Camera ;
    public GameObject whitePlayer ;
    public GameController GController;
    public GameObject blackPlayer;
    public GameObject slash;
    public Camera CCamera;

    public BoxCollider2D boxCollider2D;
    [SerializeField] public LayerMask platforma;

    public Vector3 slashOffset = new Vector3(0, 0, 0);

    public bool hittable = true;
    public bool canDash = true;
    public bool canSlash = true;

    private float standardCamera;
    public float movespeed = 0;

    public int direction = 1;
    public int dashTimer = 0;
    public int dashCD = 250;
    public int dashCDTimer = 0;
    public int dashTime = 50;
    public int dashDirection = 1;
    public int slashTimer = 0;
    public int slashCD = 150;
    public int lives = 3;

    void Start()
    {
        standardCamera = CCamera.orthographicSize;
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
       
        if (Input.GetKey("a"))
        {
            if (movespeed>-0.03f)
            movespeed -= 0.001f;
            direction = -1;
           

        }
        if (Input.GetKey("d"))
        {
            if (movespeed < 0.03f)
                movespeed += 0.001f;
            direction = 1;
          
        }
        if (Input.GetKey("s"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(whitePlayer.transform.up * -1);

        }
        if (Input.GetKey("w") && Grounded())
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0f);
            this.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        }
        if (Input.GetKey(KeyCode.LeftShift)&& canDash)
        {
           
                canDash = false;
                movespeed += direction * 0.1f;
                dashCDTimer = 0;
                dashTimer = 0;
                dashDirection = direction;
                hittable = false;
            
        }
        if (Input.GetKey(KeyCode.Space)&& canSlash )
        {
            if (Input.GetKey("s") )
            {
               
                slashCD = 180;
                slashOffset = new Vector3(0, -1, 0);
                this.GetComponent<Rigidbody2D>().AddForce(whitePlayer.transform.up * -50);
            }
            else if (Input.GetKey("w") )
            {
                slashCD = 350;
                slashOffset = new Vector3(0, 2, 0);
                this.GetComponent<Rigidbody2D>().AddForce(whitePlayer.transform.up * 50);
            }
            else
            {
                slashCD = 120;
                slashOffset = new Vector3(0, 0, 0);
              
            }
            canSlash = false;
            slash.SetActive(true);
            slash.transform.localScale = new Vector3(Mathf.Abs(slash.transform.localScale.x) * direction, slash.transform.localScale.y, slash.transform.localScale.z);


        }
        float scale;

        whitePlayer.transform.position = new Vector3((whitePlayer.transform.position.x + movespeed), whitePlayer.transform.position.y, whitePlayer.transform.position.z);
        float playerXdiff = (whitePlayer.transform.position.x + blackPlayer.transform.position.x) / 2;
        float playerYdiff = (whitePlayer.transform.position.y + blackPlayer.transform.position.y) / 2;
        Camera.transform.position = new Vector3(playerXdiff,playerYdiff , Camera.transform.position.z);
        if (Mathf.Abs(whitePlayer.transform.position.x - blackPlayer.transform.position.x) > 10 && Mathf.Abs(whitePlayer.transform.position.x - blackPlayer.transform.position.x) < 20)
        {
            scale =Mathf.Abs(  (whitePlayer.transform.position.x - blackPlayer.transform.position.x)/10f);
        }
        else if (Mathf.Abs(whitePlayer.transform.position.x - blackPlayer.transform.position.x) < 10 )
        {
            scale = 1f;
        }
        else
        {
            scale = 2f;
        }
        float scaleY = 1; 
        if (Mathf.Abs(whitePlayer.transform.position.y - blackPlayer.transform.position.y) > 5 && Mathf.Abs(whitePlayer.transform.position.y - blackPlayer.transform.position.y) < 10)
        {
            scaleY = Mathf.Abs((whitePlayer.transform.position.y - blackPlayer.transform.position.y) / 5f);
        }
        else if (Mathf.Abs(whitePlayer.transform.position.y - blackPlayer.transform.position.y) < 5)
        {
            scaleY = 1f;
        }
        else
        {
            scaleY = 2f;
        }
        scale = (scale + scaleY) / 2f;
        CCamera.orthographicSize = standardCamera*scale;
        

        if (movespeed > 0)
            movespeed -= 0.0001f;
       else if (movespeed < 0)
            movespeed += 0.0001f;

        if (movespeed < 0.0001f && movespeed > -0.0001f)
            movespeed = 0;

        if (canDash==false)
        {
            if (dashTimer < dashTime)
            {
                dashTimer++;
            }
            else if (dashTimer == dashTime)
            {
                dashTimer++;
                movespeed -= dashDirection * 0.08f;
            }
                else
                hittable = true;


            if (dashCDTimer < dashCD)
                dashCDTimer++;
            else

                canDash = true;
                
        }

        

        if (canSlash==false)
        {
            slash.transform.position = whitePlayer.transform.position+slashOffset;
            if (slashTimer < slashCD)
                slashTimer++;
            else
            {
                canSlash = true;
                slashTimer = 0;
            }
            if (slashTimer == 80)
            {
                slash.SetActive(false);
            }
        }
       

    }

    void OnTriggerEnter2D(Collider2D collidingObject)
    {

       
        if (collidingObject.gameObject.layer == 11 && hittable)
        {
            Debug.Log("White got hit by bullet");
            Destroy(collidingObject.gameObject);
            GController.BController.lives--;
        }
        if (collidingObject.gameObject.layer == 12 && hittable)
        {
            Debug.Log("White got hit by blast");
            float blastX = collidingObject.transform.position.x, blastY = collidingObject.transform.position.y;
            Vector2 diff = new Vector2(  whitePlayer.transform.position.x - blastX,  whitePlayer.transform.position.y - blastY);
            diff = diff / Mathf.Sqrt(diff.x * diff.x + diff.y * diff.y);
            this.GetComponent<Rigidbody2D>().AddForce(blackPlayer.transform.up * diff.y * 125);
            movespeed += diff.x * 0.05f;
            GController.BController.lives--;

        }
        if (collidingObject.gameObject.layer == 14 && hittable)
        {
            Debug.Log("White got hit by a cannon");
            float blastX = collidingObject.transform.position.x, blastY = collidingObject.transform.position.y;
            Vector2 diff = new Vector2(whitePlayer.transform.position.x - blastX, whitePlayer.transform.position.y - blastY);
            diff = diff / Mathf.Sqrt(diff.x * diff.x + diff.y * diff.y);
            this.GetComponent<Rigidbody2D>().AddForce(blackPlayer.transform.up * diff.y * 200);
            movespeed += diff.x * 0.05f;
            GController.BController.lives--;
            Destroy(collidingObject.gameObject);

        }

    }

    public bool Grounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + 0.1f, platforma);
        return raycastHit.collider != null;

    }


}
