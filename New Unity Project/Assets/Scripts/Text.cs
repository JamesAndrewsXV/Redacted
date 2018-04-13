using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour {

    BoxCollider2D textCol;
    Rigidbody2D rb;
    Camera mainCam;
    bool touched;
    GameObject plane;
    GameObject redaction;
    GameObject hero;
    LayerMask solidPlatform;
    Text platform;
    BombPickup collectible;
    Text finalPlat;

    public Vector2 minForce;
    public Vector2 maxForce;
    public Vector2 mousePos;
    void Awake() {
        textCol = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        redaction = GameObject.FindGameObjectWithTag("Redact");
        hero = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            float mousePosX = mainCam.ScreenToWorldPoint(Input.mousePosition).x;
            float mousePosY = mainCam.ScreenToWorldPoint(Input.mousePosition).y;
            mousePos = new Vector3(mousePosX, mousePosY, 0);// select distance = 10 units from the camera
            Debug.Log(mainCam.ScreenToWorldPoint(mousePos));
            if (textCol.bounds.Contains(mousePos) && rb.gameObject.layer == 12) {
                Debug.Log("here");
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.AddForce(new Vector3(Random.Range(minForce.x, maxForce.x), Random.Range(minForce.y, maxForce.y), 0));
                rb.gameObject.layer = 11;
                solidPlatform = hero.GetComponent<PlayerControl>().whatIsGround;

                //platform = rb.GetComponent<Text>();
                //platform.enabled = !platform.enabled;

                plane = Instantiate(redaction);

                plane.transform.position = new Vector3(rb.gameObject.transform.position.x, rb.gameObject.transform.position.y, rb.gameObject.transform.position.z);
                //plane.transform.rotation = new Quaternion(plane.gameObject.transform.rotation.w, rb.gameObject.transform.rotation.x, rb.gameObject.transform.rotation.y, rb.gameObject.transform.rotation.z);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the trigger zone...
        if (other.tag == "Player" && rb.gameObject.layer == 11) {
            Destroy(other);
            //finalPlat = Instantiate(this);
            //finalPlat.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}

