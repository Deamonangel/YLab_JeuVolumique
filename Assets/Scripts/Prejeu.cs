/*
PROJET JEU VOLUMIQUE
ADRIEN MONTCHER
17/03/2020
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prejeu: MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        Vector3 p = -Vector3.one;
        p = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 9.9f));
        if (p.x >= -6 && p.x <= 0 && p.z >= -6 && p.z <= 4)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetFloat("x", p.x);
                PlayerPrefs.SetFloat("z", p.z);
                SceneManager.LoadScene("Jeu", LoadSceneMode.Single);
            }
        }
    }
}