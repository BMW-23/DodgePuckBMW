using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Test : MonoBehaviour
{
   // public int score = 7;
   // public int highscore = 10;
   // private int temp = 70;
    //public float location;
   // public float loc2 = 1.5f;
    public int speed = 10;
    public float xRange = 9.0f;
    public float yRange = 6.0f;
    public GameObject Pucky;
    public GameObject Blocky;
   // public int Score = 0;
    public GameObject scoreText;
    public GameObject gameOverText;
    


    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Hello world");
       // score = score + 2;
       // score += 2;
       // Debug.Log(score + highscore);
       // location = 0.0f;
        SpawnPucky();
        SpawnBlocky();
    }

    void SpawnPucky()
    {
        //Debug.Log(Random.Range(1.0f,10.0f));
        Instantiate(Pucky, new Vector2(Random.Range(-9.0f, 9.0f),Random.Range(-4.0f, 4.0f)), Quaternion.identity);
    }


    void SpawnBlocky()
    {
        Instantiate(Blocky, new Vector2(Random.Range(-9.0f, 9.0f), Random.Range(-4.0f, 4.0f)), Quaternion.identity);
    }








    // Update is called once per frame
    void Update()
    {
        

        float moveHorizontal = Input.GetAxis("Horizontal");
        //Debug.Log(moveHorizontal);

        float moveVertical = Input.GetAxis("Vertical");
        //Debug.Log(moveVertical);

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime);

        // if (Input.GetKeyDown(KeyCode.D))
        //   {
        // Debug.Log(Input.GetAxis("Horizontal"));
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        //  }
    }


   // void OnCollisionEnter(Collision collision)
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if it's tagged as blocky
        if (collision.gameObject.tag == "Blocky")
        {
            //add five score
            SpawnPucky();
            //Score += 5;
           // Debug.Log(Score);
            Destroy(collision.gameObject);
            scoreText.GetComponent<ScoreKeeper>().UpdateScore();
            SpawnBlocky();
        }
        //if it's tagged as pucky

        if (collision.gameObject.tag == "Pucky")
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
        }



    }




      private void LateUpdate()
      {
            if (transform.position.x > xRange)
            {
                transform.position = new Vector2(xRange, transform.position.y);
            }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }



        //if (Input.GetKeyDown(KeyCode.L))
        // {
        //   Debug.Log(location += 0.5f);



        //}

    }


    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

}
