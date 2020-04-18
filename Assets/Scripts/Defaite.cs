using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Defaite : MonoBehaviour
{
    public Text Mort;
    // Start is called before the first frame update
    void Start()
    {
        Mort = GameObject.Find("Mort").GetComponent<Text>();
        if (PlayerPrefs.GetString("mort")=="pic")
        {
            Mort.GetComponent<Text>().text = "Oups! Vous étiez affaiblis et un pic vous a achevé, ne vous laissez pas abattre!";
        }
        if (PlayerPrefs.GetString("mort") == "trou")
        {
            Mort.GetComponent<Text>().text = "Le sol était instable, se mefier tu aurais du!\n +1 squelette";
        }
        PlayerPrefs.DeleteKey("mort");
    }
    public void FinversMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
