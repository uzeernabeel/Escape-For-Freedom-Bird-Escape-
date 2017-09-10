using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bird : MonoBehaviour {
    public static float upForce = 23f;                   //Upward force of the "flap".
    private bool isDead = false;                  //Has the player collided with a wall?

    private Animator anim;                  //Reference to the Animator component.
    private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.
    private PolygonCollider2D box2d;

    public float timeRemaining = 2f;        //for speeding power
    public float timeRemaining2 = 5f;       //for Big Power
    public float timeRemaining3 = 5f;       //for small Power
    public float timeRemaining4 = 10f;      //for bullet Power

    private float minY = -5.5f;
    private float maxY = 5.5f;

    private Vector3 pos = new Vector3(0, 0, 0);

    public AudioSource source;
    public AudioClip coinCollect;
    public AudioClip powerCollcet;
    public AudioClip bigPowerCollect;
    public AudioClip blast;
    public AudioClip littlePowerCollect;
    public AudioClip RocketPowerCollect;
    public AudioClip BubblePowerCollect;
    public AudioClip die;
    public AudioClip start;

    public Text timerText;
    public int text;

    public string reference;
    public float refNumber;

    //public GameObject rocketObject;         //This is a reference to the rocket in front of bird;
    //public Rigidbody2D rocketRigidBody2d;   //reference to rb2d of rocket.

    private void Awake() {
        source.PlayOneShot(start);
        timerText = GameObject.Find("Canvas/BigPowerTimer").GetComponent<UnityEngine.UI.Text>();
    }

    void Start() {
        source = GetComponent<AudioSource>();
        //Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator>();
        
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
        box2d = GetComponent<PolygonCollider2D>();

       
        timerText.gameObject.SetActive(false);
    }

    /*private void FixedUpdate() {
        if (isDead == false) {
            if (Input.GetMouseButton(0)) {
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
    }*/

    void Update() {
        //Don't allow control if the bird has died.
        if (isDead == false) {

           
            //Look for input to trigger a "flap".
            if (Input.GetMouseButton(0)) {
                //...tell the animator about it and then...
                //anim.SetTrigger("Flap");
                //...zero out the birds current y velocity before...
                //rb2d.velocity = Vector2.zero;
                //  new Vector2(rb2d.velocity.x, 0);
                //..giving the bird some upward force.
                rb2d.AddForce(new Vector2(0, upForce));
            }

            OutOfBound();
            //Debug.Log(string.Format("{0:N3}", transform.position.y));

            if (PowerCollect.done) {
                timeRemaining -= Time.deltaTime;
            }

            if (BigPower.bigPowerHappen) {
                timeRemaining2 -= Time.deltaTime;

                text = (int)timeRemaining2 + 1;

                if (timerText.gameObject.activeSelf == false)
                    timerText.gameObject.SetActive(true);

                timerText.text = text.ToString();

                //OutOfBound();
            }

            if (BigPowerOpposite.smallPowerHappen) {
                timeRemaining3 -= Time.deltaTime;

                text = (int)timeRemaining3 + 1;

                if (timerText.gameObject.activeSelf == false)
                    timerText.gameObject.SetActive(true);

                timerText.text = text.ToString();

            }

            /* if (RocketCollect.RocketTime) {
                 timeRemaining4 -= Time.deltaTime;

                 if (rocketObject.activeSelf == false) {
                     rocketObject.SetActive(true);
                     rocketObject.GetComponent<Rigidbody2D>().position = new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y);
                 }
             }*/

            if (timeRemaining < 0) {
                box2d.isTrigger = false;
                rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                ScrollingObject.scrollSpeed = PowerCollect.ScrollingSpeedNow;
                PowerCollect.done = false;
                timeRemaining = 2f;
            }

            if (timeRemaining2 < 0) {
                box2d.isTrigger = false;
                BigPower.bigPowerHappen = false;
                timeRemaining2 = 5f;
                //upForce = 27f;
                timerText.gameObject.SetActive(false);
                transform.localScale -= new Vector3(2.5f, 2.5f, 0);
            }

            if (timeRemaining3 < 0) {
                BigPowerOpposite.smallPowerHappen = false;
                timeRemaining3 = 5f;
                //upForce = 27f;
                timerText.gameObject.SetActive(false);
                transform.localScale += new Vector3(.3f, .3f, 0);
            }

            if (GameControl.instance.gameOver) {
                anim.SetTrigger("Die");
                rb2d.velocity = Vector2.zero;
                rb2d.bodyType = RigidbodyType2D.Kinematic;
                isDead = true;

                timeRemaining = 0;
                timeRemaining2 = 0;
                timeRemaining3 = 0;

            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Power1")
            source.PlayOneShot(powerCollcet);

       
        if (BigPower.bigPowerHappen) {
            //if (collision.gameObject.tag == "Backgrounds") {
            //  return;
            if (collision.gameObject.tag == "Enemy"){
                source.PlayOneShot(blast);
                
                collision.gameObject.SetActive(false);
            }
        }

        if(collision.gameObject.tag == "Enemy") {
            source.PlayOneShot(die);
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Coin")
            source.PlayOneShot(coinCollect);

        if (collision.gameObject.tag == "Power2")
            source.PlayOneShot(bigPowerCollect);

        if (collision.gameObject.tag == "Power3")
            source.PlayOneShot(littlePowerCollect);

        if (collision.gameObject.tag == "Power5")
            source.PlayOneShot(BubblePowerCollect);

        if (collision.gameObject.tag == "Power4")
            source.PlayOneShot(RocketPowerCollect);

        //if(PlayGamesScript.playerSignedIn)
        //PlayGamesScript.UnlockAchievement(GPGSIds.achievement_fresh_start);
    }

    /*private void OnTriggerEnter2D(Collider2D collision) {
        if (BigPower.bigPowerHappen) {
            if (collision.gameObject.tag == "Scenery") {
                return;
            } else {
                collision.gameObject.SetActive(false);
            }
        }
    }*/


    void OutOfBound() {
        if (transform.position.y > maxY)
            transform.position = new Vector2(transform.position.x, maxY);
        else if (transform.position.y < minY)
            transform.position = new Vector2(transform.position.x, minY);
    }

        //pos = transform.position;
        //pos.y = Mathf.Clamp(pos.y, minY, maxY);
        //transform.position = pos;
}