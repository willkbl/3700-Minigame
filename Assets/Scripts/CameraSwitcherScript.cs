using UnityEngine;

public class CameraSwitcherScript : MonoBehaviour
{
    GameObject levelManager;
    GameManagerScript gmScript;

    public Camera mainCamera;
    public Camera writingCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("GameManager");
        gmScript = levelManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gmScript.isWriting)
        {
            writingCamera.GetComponent<Camera>().depth = 5;
        } else
        {
            writingCamera.GetComponent<Camera>().depth = 0;
        }
    }
}
