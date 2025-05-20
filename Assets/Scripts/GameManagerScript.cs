using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{

    public bool isWriting = false;
    public bool waitForSpaceRelease = false;
    public TMP_Text scoreText;
    public float score = 0; //public just so I can see it in the inspector
    public bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Notes written: " + score;
    }
}
