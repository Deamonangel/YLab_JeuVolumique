using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Victoire : MonoBehaviour
{
    public Text TextVictoire;
    // Start is called before the first frame update
    void Start()
    {
        TextVictoire = GameObject.Find("TextVictoire").GetComponent<Text>();
        TextVictoire.GetComponent<Text>().text = "En seulement :\n "+ PlayerPrefs.GetString("TempsVictoire")+ " Sec\n Premier arrivé, premier servis ;)";
        
    }
    public void FinversMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
