/*
PROJET JEU VOLUMIQUE
ADRIEN MONTCHER
17/03/2020
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{

    public GameObject Slider;
    public void Slider_change(int c)
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void JeuversOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void OptionsversRegles()
    {
        Handheld.Vibrate();
        SceneManager.LoadScene("Regles");
    }
    public void OptionsversMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
