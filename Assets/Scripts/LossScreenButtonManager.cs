using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossScreenButtonManager : MonoBehaviour
{
    public void BackToHome()
    {
        SceneManager.LoadScene(0);
    }
}
