using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [Header("External")]
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject pauseMenuObject;
    [SerializeField] private GameObject pauseStartMenuObject;
    [SerializeField] private GameObject menuList;

    [Header("Internal")]
    [SerializeField] private bool isPaused = false;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void OnPauseGame()
    {

    }
    void PauseGame()
    {
        //Pauses the game
        isPaused = true;
        Time.timeScale = 0f;

        //Disables the players input
        playerObject.GetComponent<PlayerInput>().enabled = false;

        //Enables mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Enables pauseMenu
        pauseMenuObject.gameObject.SetActive(true);

    }
    void UnPauseGame()
    {

    }
    void ResetPauseUI()
    {
    }
}
