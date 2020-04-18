/*
PROJET JEU VOLUMIQUE
ADRIEN MONTCHER
17/03/2020
*/
using UnityEngine.SceneManagement;
using UnityEngine;

public class Regles : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void ReglesversPrejeu()
    {
        SceneManager.LoadScene("Prejeu");
    }
}

