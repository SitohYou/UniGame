using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class line : MonoBehaviour
{
    private float stayTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("seed"))
        {
            stayTime += Time.deltaTime;
            if(stayTime > 4.0f)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("seed"))
        {
            stayTime = 0;
        }
    }
}
