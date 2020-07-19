using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D rigidBod;

    public static PlayerMovements sharedInstance;
    Vector3 startPosition;


    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        rigidBod = GetComponent<Rigidbody2D>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(Mathf.Clamp(mousePosition.x,-4.5f,4.5f), transform.position.y, transform.position.z);
    }

    public void startGame()
    {
        Invoke("RestartPosition", 0.1f);
        rigidBod.constraints = RigidbodyConstraints2D.None;
    }

    void RestartPosition()
    {
        this.transform.position = startPosition;

    }

    public void dead()
    {
        //float previousMaxDistance = PlayerPrefs.GetFloat("maxscore", 0f);    
        //Detiene la caida
        rigidBod.constraints = RigidbodyConstraints2D.FreezeAll;
        float fallDistance = GetYposition();
        float previousMaxDistance = PlayerPrefs.GetFloat("maxscore", 0f);
        if(fallDistance > previousMaxDistance)
        {
            PlayerPrefs.SetFloat("maxscore", fallDistance);
        }
       
        GameManager.sharedIntance.GameOver();
       
      
    }

    public float GetYposition()
    {
        return (this.transform.position.y) * -1 - startPosition.y;
    }
}
