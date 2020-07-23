using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartujIgru : MonoBehaviour
{
    public void PromeniScenu()
    {
        SceneManager.LoadScene("Glavna");
    }
}
