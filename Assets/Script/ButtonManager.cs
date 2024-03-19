using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }
}
