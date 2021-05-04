using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackController : MonoBehaviour
{
    public Camera Camera = new Camera();
    public GameController GController;
    public GameObject blackPlayer;
    public GameObject Bullet;
    public GameObject whitePlayer;
    public BulletController Bcontrol;
    public GameObject Blast;
    public GameObject Cannon;
    public BulletController Ccontrol;

    public Animator animator;

    public BoxCollider2D boxCollider2D;
    [SerializeField] public LayerMask platforma;

    public bool canJump = true;
    public bool shotReady = true;
    public bool cannonShotReady = true;
    public bool betterjump = false;
    public bool bettercannon = false;

    public float movespeed = 0;

    public int magazine = 2;
    public int canJumpTimer = 0;
    public int singleShotCountdown = 50;
    public int shotCountdown = 0;
    public int shotTimer = 0;
    public int jumpCD = 300;
    public int direction = 1;


    public int weapon = 0;
    public int lives = 3;

    public int cannonTimer = 0;
    public int cannonCD = 500;


   
    public float waitTime = 0.2f;
    private bool jestNaPlatformie = false;

    void Start()
    {
        shotReady = true;
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (movespeed > -0.03f)
                movespeed -= 0.001f;
            blackPlayer.transform.position = new Vector3((blackPlayer.transform.position.x + movespeed), blackPlayer.transform.position.y, blackPlayer.transform.position.z);
            direction = -1;
            animator.SetFloat("isSpeed", movespeed * -100);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (movespeed < 0.03f)
                movespeed += 0.001f;
            blackPlayer.transform.position = new Vector3((blackPlayer.transform.position.x + movespeed), blackPlayer.transform.position.y, blackPlayer.transform.position.z);
            direction = 1;
            animator.SetFloat("isSpeed", movespeed*100);
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetFloat("isSpeed", 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isSliding", true);
            this.GetComponent<Rigidbody2D>().AddForce(blackPlayer.transform.up * -1);
            if (Input.GetKey(KeyCode.DownArrow) && jestNaPlatformie==true)
            {
                if (waitTime <= 0)
                {
                    boxCollider2D.isTrigger = true;
                    waitTime = 0.5f;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }

            //blackPlayer.transform.position = new Vector3((blackPlayer.transform.position.x + movespeed), blackPlayer.transform.position.y, blackPlayer.transform.position.z);
        }else{
            animator.SetBool("isSliding", false);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.5f;
        }
        if (Input.GetKey(KeyCode.UpArrow) && Grounded())
        {
            animator.SetBool("Jump", true);
            if (betterjump)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0f);
                this.GetComponent<Rigidbody2D>().angularVelocity = 0f;
                this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12, ForceMode2D.Impulse);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0f);
                this.GetComponent<Rigidbody2D>().angularVelocity = 0f;
                this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 9, ForceMode2D.Impulse);
                blackPlayer.transform.position = new Vector3((blackPlayer.transform.position.x + movespeed), blackPlayer.transform.position.y, blackPlayer.transform.position.z);
            }

        }
        else if (Grounded() == true)
        {
            animator.SetBool("Jump", false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (shotReady && magazine == 2 && weapon == 0)
            {
                Vector3 blackPos = Camera.WorldToScreenPoint(blackPlayer.transform.position);
                Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, blackPlayer.transform.position.z);
                Vector2 diff = new Vector2(blackPos.x - mousePos.x, blackPos.y - mousePos.y);
                diff = diff / Mathf.Sqrt(diff.x * diff.x + diff.y * diff.y);
                shotReady = false;
                this.GetComponent<Rigidbody2D>().AddForce(blackPlayer.transform.up * diff.y * 250);
                movespeed += diff.x * 0.05f;
                shotCountdown = 300;

                float angle = AngleBetweenTwoPoints(mousePos, blackPos);
                Blast.SetActive(true);

                Blast.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
                magazine = 0;
            }
            blackPlayer.transform.position = new Vector3((blackPlayer.transform.position.x + movespeed), blackPlayer.transform.position.y, blackPlayer.transform.position.z);

        }
        if (Input.GetMouseButtonDown(0))
        {
            if (shotReady && magazine > 0 && weapon == 0)
            {
                Vector3 blackPos = Camera.WorldToScreenPoint(blackPlayer.transform.position);
                Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, blackPlayer.transform.position.z);
                Vector2 diff = new Vector2(blackPos.x - mousePos.x, blackPos.y - mousePos.y);
                diff = diff / Mathf.Sqrt(diff.x * diff.x + diff.y * diff.y);
                shotReady = false;
                this.GetComponent<Rigidbody2D>().AddForce(blackPlayer.transform.up * diff.y * 100);
                movespeed += diff.x * 0.01f;
                Bcontrol.xDiff = -diff.x;
                Bcontrol.yDiff = -diff.y;
                GameObject BulletClone = Instantiate(Bullet, blackPlayer.transform.position, Quaternion.identity);
                BulletClone.SetActive(true);

                magazine--;
                singleShotCountdown = 50;
                shotCountdown = 200;
            }
            else if (cannonShotReady && weapon == 1)
            {
                if (bettercannon)
                {
                    Vector3 blackPos = Camera.WorldToScreenPoint(blackPlayer.transform.position);
                    Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, blackPlayer.transform.position.z);
                    Vector2 diff = new Vector2(blackPos.x - mousePos.x, blackPos.y - mousePos.y);
                    diff = diff / Mathf.Sqrt(diff.x * diff.x + diff.y * diff.y);
                    cannonShotReady = false;
                    this.GetComponent<Rigidbody2D>().AddForce(blackPlayer.transform.up * diff.y * 200);
                    movespeed += diff.x * 0.015f;
                    Ccontrol.xDiff = -diff.x;
                    Ccontrol.yDiff = -diff.y;
                    GameObject CannonClone = Instantiate(Cannon, blackPlayer.transform.position, Quaternion.identity);
                    CannonClone.SetActive(true);

                    cannonCD = 25;
                    cannonTimer = 0;
                }
                else
                {
                    Vector3 blackPos = Camera.WorldToScreenPoint(blackPlayer.transform.position);
                    Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, blackPlayer.transform.position.z);
                    Vector2 diff = new Vector2(blackPos.x - mousePos.x, blackPos.y - mousePos.y);
                    diff = diff / Mathf.Sqrt(diff.x * diff.x + diff.y * diff.y);
                    cannonShotReady = false;
                    this.GetComponent<Rigidbody2D>().AddForce(blackPlayer.transform.up * diff.y * 200);
                    movespeed += diff.x * 0.015f;
                    Ccontrol.xDiff = -diff.x;
                    Ccontrol.yDiff = -diff.y;
                    GameObject CannonClone = Instantiate(Cannon, blackPlayer.transform.position, Quaternion.identity);
                    CannonClone.SetActive(true);

                    cannonCD = 500;
                    cannonTimer = 0;
                }
            }
            blackPlayer.transform.position = new Vector3((blackPlayer.transform.position.x + movespeed), blackPlayer.transform.position.y, blackPlayer.transform.position.z);
        }

        if (Input.GetMouseButtonDown(2))
        {
            weapon++;
            if (weapon > 1)
                weapon = 0;
            blackPlayer.transform.position = new Vector3((blackPlayer.transform.position.x + movespeed), blackPlayer.transform.position.y, blackPlayer.transform.position.z);

        }



        if (movespeed > 0)
            movespeed -= 0.0001f;
        else if (movespeed < 0)
            movespeed += 0.0001f;

        if (movespeed < 0.0001f && movespeed > -0.0001f)
            movespeed = 0;

        if (magazine < 2)
        {
            shotTimer++;
            if (shotTimer == 20)
                Blast.SetActive(false);
            if (shotTimer == singleShotCountdown && magazine > 0)
                shotReady = true;
            if (shotTimer > shotCountdown)
            {
                shotReady = true;
                shotTimer = 0;
                magazine = 2;
            }
        }

        if (cannonShotReady == false)
        {
            cannonTimer++;
            if (cannonTimer == cannonCD)
            {
                cannonShotReady = true;
            }
        }
        Blast.transform.position = blackPlayer.transform.position;
        blackPlayer.transform.localScale = new Vector3(Mathf.Abs(blackPlayer.transform.localScale.x) * direction, blackPlayer.transform.localScale.y, blackPlayer.transform.localScale.z);

    }

    void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (collidingObject.tag == "MovingPlatform")
        {
            Debug.Log("Black step on");

            this.transform.parent = collidingObject.transform;
        }

        if (collidingObject.gameObject.layer == 13)
        {
            Debug.Log("Black got hit by a slash");
            //  GController.WController.lives--;
        }

        if (collidingObject.tag == "Platforma" || collidingObject.tag == "MovingPlatform")
        {
            jestNaPlatformie = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MovingPlatform")
        {
            Debug.Log("Black step off");

            this.transform.parent = null;
        }

        if (collision.tag == "Platforma" || collision.tag == "MovingPlatform")
        {
            boxCollider2D.isTrigger = false;
            jestNaPlatformie = false;
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public bool Grounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + 0.1f, platforma);
        return raycastHit.collider != null;
        //test
    }
}
