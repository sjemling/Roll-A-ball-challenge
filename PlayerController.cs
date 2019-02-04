using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";

        if (Input.GetKey("escape"))
        { Application.Quit(); }
    }
    void FixedUpdate()
    {
      float moveHorizontal = Input.GetAxis("Horizontal");
     float moveVertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    rb.AddForce(movement * speed);
        if (count >= 12)
        {
         
            transform.position = new Vector3(300, 100, 0);
            speed = 10;
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 24)
        {
            winText.text = "You Win!";
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up")) ;
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            
        }
        }
    }