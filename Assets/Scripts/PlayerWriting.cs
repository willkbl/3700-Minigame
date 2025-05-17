using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWriting : MonoBehaviour
{

    GameObject levelManager;
    GameManagerScript gmScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("GameManager");
        gmScript = levelManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!gmScript.waitForSpaceRelease)
            {
                gmScript.isWriting = true;
            }       
        }
        else
        {
            gmScript.isWriting = false;
            gmScript.waitForSpaceRelease = false;
        }
    }

    
}
