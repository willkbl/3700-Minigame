using UnityEngine;
using UnityEngine.UI;

public class SubProgressBar : MonoBehaviour
{

    public float secondsPerLine = 1f; //manually set this to total note time / number of lines

    private GameObject gameManager;
    private GameManagerScript gameManagerScript;

    public Image mainProgressBar;
    public float targetStart; //scale from 0 to 1, what section of the main progress bar should this represent
    public float targetEnd;

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
        if (gameManagerScript.isWriting && mainProgressBar.transform.localScale.x >= targetStart && mainProgressBar.transform.localScale.x < targetEnd)
        {
            this.transform.localScale += new Vector3(Time.deltaTime / secondsPerLine, 0, 0);
        }
        if (mainProgressBar.transform.localScale.x == 0)
        {
            this.transform.localScale = new Vector3(0, 1, 1);
        }
    }
}
