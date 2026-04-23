using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsPopup : MonoBehaviour
{
    [SerializeField] UIManager uiMan;
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void OnRestartGameButton()
    {
        Debug.Log("RestartGame");
        SceneManager.LoadScene(0);
        uiMan.SetGameActive(true);
    }
    public void OnExitGameButton()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
    public void OnReturnToGameButton()
    {
        Debug.Log("Return To Game");
        Close();
        uiMan.SetGameActive(true);
    }
}
