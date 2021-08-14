using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string nomeDaCena;

    public void ChangeS()
    {
        Invoke("ChangeS1", 0.2f);
    }

    void ChangeS1()
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    public void Sair()
    {
        Application.Quit();
    }

}