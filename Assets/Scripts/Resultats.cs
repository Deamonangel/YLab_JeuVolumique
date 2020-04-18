/*
PROJET JEU VOLUMIQUE
ADRIEN MONTCHER
17/03/2020
*/
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Resultats : MonoBehaviour
{
    public Text C1;
    public Text P1;
    public Text C2;
    public Text P2;
    public Text C3;
    public Text P3;
    public Text C4;
    public Text P4;
    public Text C5;
    public Text P5;
    public Text C6;
    public Text P6;
    public Text C7;
    public Text P7;
    public Text C8;
    public Text P8;
    public Text C9;
    public Text P9;
    public Text C10;
    public Text P10;
    public SortedDictionary<float, string> DicResultats = new SortedDictionary<float, string>();

    // Start is called before the first frame update
    void Start()
    {
        C1 = GameObject.Find("Chrono1").GetComponent<Text>();
        P1 = GameObject.Find("Pseudo1").GetComponent<Text>();
        C2 = GameObject.Find("Chrono2").GetComponent<Text>();
        P2 = GameObject.Find("Pseudo2").GetComponent<Text>();
        C3 = GameObject.Find("Chrono3").GetComponent<Text>();
        P3 = GameObject.Find("Pseudo3").GetComponent<Text>();
        C4 = GameObject.Find("Chrono4").GetComponent<Text>();
        P4 = GameObject.Find("Pseudo4").GetComponent<Text>();
        C5 = GameObject.Find("Chrono5").GetComponent<Text>();
        P5 = GameObject.Find("Pseudo5").GetComponent<Text>();
        C6 = GameObject.Find("Chrono6").GetComponent<Text>();
        P6 = GameObject.Find("Pseudo6").GetComponent<Text>();
        C7 = GameObject.Find("Chrono7").GetComponent<Text>();
        P7 = GameObject.Find("Pseudo7").GetComponent<Text>();
        C8 = GameObject.Find("Chrono8").GetComponent<Text>();
        P8 = GameObject.Find("Pseudo8").GetComponent<Text>();
        C9 = GameObject.Find("Chrono9").GetComponent<Text>();
        P9 = GameObject.Find("Pseudo9").GetComponent<Text>();
        C10 = GameObject.Find("Chrono10").GetComponent<Text>();
        P10 = GameObject.Find("Pseudo10").GetComponent<Text>();

        // je recup tout les resultats enregistrer de 0 à infini puiss je split la valeur pour recup chrono et pseudo
        int i = 0;
        while (PlayerPrefs.HasKey(i.ToString()))
        {
            string s = PlayerPrefs.GetString(i.ToString());
            string[] w = s.Split('/');
            DicResultats.Add(float.Parse(w[1]), w[0]);
            i++;
        }
        int j = 0;

        foreach (var key in DicResultats.Keys)
        {
            switch (j)
            {
                case 0:
                    C1.GetComponent<Text>().text = key.ToString(); 
                    P1.GetComponent<Text>().text = DicResultats[key];
                    break;
                case 1:
                    C2.GetComponent<Text>().text = key.ToString(); 
                    P2.GetComponent<Text>().text = DicResultats[key];
                    break;
                case 2:
                    C3.GetComponent<Text>().text = key.ToString(); 
                    P3.GetComponent<Text>().text = DicResultats[key];
                    break;
                case 3:
                    C4.GetComponent<Text>().text = key.ToString(); 
                    P4.GetComponent<Text>().text = DicResultats[key];
                    break;
                case 4:
                    C5.GetComponent<Text>().text = key.ToString(); 
                    P5.GetComponent<Text>().text = DicResultats[key];
                    break;
                case 5:
                    C6.GetComponent<Text>().text = key.ToString();
                    P6.GetComponent<Text>().text = DicResultats[key];
                    break;
                case 6:
                    C7.GetComponent<Text>().text = key.ToString();
                    P7.GetComponent<Text>().text = DicResultats[key];
                    break;
                case 7:
                    C8.GetComponent<Text>().text = key.ToString();
                    P8.GetComponent<Text>().text = DicResultats[key];
                    break;
                case 8:
                    C9.GetComponent<Text>().text = key.ToString();
                    P9.GetComponent<Text>().text = DicResultats[key];
                    break;
                case 9:
                    C10.GetComponent<Text>().text = key.ToString();
                    P10.GetComponent<Text>().text = DicResultats[key];
                    break;
            }
            j++;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void ResultstoMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
