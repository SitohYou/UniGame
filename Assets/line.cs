using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class line : MonoBehaviour
{
    public static line instance { get; private set; }
    private float stayTime;
    public bool isFinished { get; set; } = false;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private Button restartButton;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        restartButton.onClick.AddListener(() => RestartButtonOnClick());
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
                isFinished = true;
                resultPanel.SetActive(true);
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

    private void RestartButtonOnClick()
    {
        resultPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
