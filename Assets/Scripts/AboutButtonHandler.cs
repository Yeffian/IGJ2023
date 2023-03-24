using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutButtonHandler : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
}
