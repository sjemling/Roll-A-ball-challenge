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
    private int score;
    public Text looseText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        winText.text = "";

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (score >= 12)
        {
            speed = 50;
            rb.AddForce(movement * speed);
            rb.MovePosition(new Vector3(-100, 0, -100));

        }



    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText();
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Bad Pick ups"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetScoreText();
            SetCountText();
        }

        }

     void SetCountText()
        {
            countText.text = "Count: " + count.ToString();
            if (score >= 21)
            {
                winText.text = "You Win!";
            }
        }
        
        void SetScoreText()
        {
            scoreText.text = "Score: " + score;
        if (score<=0 )
        {
            looseText.text = "you loose :("; 

        }
    }
     }