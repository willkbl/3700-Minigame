using UnityEngine;

public class UISwitcher : MonoBehaviour
{

    public bool isWritingUI;
    private GameObject gameManager;
    private GameManagerScript gameManagerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isWriting)
        {
            if (isWritingUI)
            {
                enabled = true;
            } else
            {
                enabled = false;
            }
        } else
        {
            if (isWritingUI)
            {
                enabled = false;
                Debug.Log("SHOULD NOT BE VISIBLE OOPS");
            } else
            {
                enabled = true;
            }
        }
    }
}
