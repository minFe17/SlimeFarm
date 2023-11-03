using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUI : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("IngameScene");
    }
}