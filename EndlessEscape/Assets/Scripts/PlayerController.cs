using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour
{
 

    [SerializeField] public bool isAlive = true;
    [SerializeField] public float runSpeed;
    [SerializeField] public float horizontalSpeed;

    public Rigidbody rb;
    float horizontalInput;


    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundMask;


    public static int score;
    public TMP_Text scoreText;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            Vector3 forwardMovement = transform.forward * runSpeed*Time.deltaTime;
            Vector3 horizontalMovement= transform.right*horizontalInput*horizontalSpeed*Time.deltaTime;
            rb.MovePosition(rb.position+forwardMovement+horizontalMovement);
        }
    }

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        float playerHeight = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position,Vector3.down, (playerHeight/2)+0.1f,groundMask);

        if (Input.GetKeyDown(KeyCode.Space)&& isAlive && isGrounded==true)
        {
            Jump();
        }

        scoreText.text = score.ToString();

        if (score> PlayerPrefs.GetInt("highScore"))
        {
            SoundManager.PlaySound("highScore");
            PlayerPrefs.SetInt("highScore",score);
        }
    }

    public void Jump()
    {
        
        rb.AddForce(Vector3.up * jumpForce);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="graphic")
        {
            Dead();
        }

        if (collision.gameObject.name == "CoinG(Clone)")
        {
            SoundManager.PlaySound("Coin");
            Destroy(collision.gameObject);
            score += 1;    
            Debug.Log("score: "+ score);
            if (score%5==0)
            {
                runSpeed += 5;
            }
        }
    }
    public void Dead()
    {
        isAlive = false;
        GameManager.myInstance.gameOverPanel.SetActive(true);
        GameManager.myInstance.scoreScreen.SetActive(false);
    }
}
