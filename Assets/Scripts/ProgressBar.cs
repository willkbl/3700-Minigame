using UnityEngine;

public class ProgressBar : MonoBehaviour
{

    public float secondsPerLine = 5f;

    private GameObject gameManager;
    private GameManagerScript gameManagerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.localScale = new Vector3(0, 1, 1);
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isWriting && this.transform.localScale.x < 1)
        {
            this.transform.localScale += new Vector3(Time.deltaTime / secondsPerLine, 0, 0);

            if (this.transform.localScale.x >= 1)
            {
                //note is done, finish writing and go back to main view
                this.transform.localScale = new Vector3(0, 1, 1);
                gameManagerScript.score++; //for now just add one, deal with scaling later
                gameManagerScript.isWriting = false; //does this really work lmao least safe code ever
                gameManagerScript.waitForSpaceRelease = true;
            }
        }
    }
}
