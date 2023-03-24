using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseManager : MonoBehaviour
{
    public static LoseManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void FailPlayer(GameObject player, int cause)
    {
        FindObjectOfType<SoundManager>().PlaySound("PlayerHit");
        int sceneIndex = cause == 1 ? 4 : 3;

        Destroy(player);
        // SceneManager.MoveGameObjectToScene(player, SceneManager.GetActiveScene());
        SceneManager.LoadScene(sceneIndex);
    }
}