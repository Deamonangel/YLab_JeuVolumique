/*
PROJET JEU VOLUMIQUE
ADRIEN MONTCHER
08/04/2020
*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class PlayerMove : TacticsMove
{
    public GameObject Player;
    public Light Lumière;
    public Camera Cam;
    public GameObject Clef;
    public GameObject FausseClef;
    public GameObject Tresor;
    public GameObject Trou;
    public GameObject Torche;
    public GameObject Pic1;
    public GameObject Pic2;
    public GameObject Pic3;
    public GameObject Soin;
    public GameObject Serpent;
    public GameObject Rouge;
    public Image Coeur1;
    public Image Coeur2;
    public Image Coeur3;
    public Text Chrono;
    public Text Tour;
    public Text Evenements;
    public Image ImageClef;
    public Image Fond;
    public float time = 0;
    public int Tpevent = 0;
    public int Ntour = 1;
    public bool clef = false;
    public bool poison = false;
    public int Tpoison = 0;
    public int vie = 3;
    public static string joueur = "player";
    public List<int> l0 = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public List<int> l1 = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public List<int> l2 = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public List<int> l3 = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public List<int> l4 = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public List<int> l5 = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    //############################################################# Initialisation lors du lancement de la scene
    void Start()
    {
        Init();

        //Placer le joueur avec les données recup dans scène avant
        float x = PlayerPrefs.GetFloat("x");
        float z = PlayerPrefs.GetFloat("z");
        Player.transform.position = new Vector3(x, 1.25f, z);
        Lumière.transform.position = new Vector3(x, 8f, z);
        Debug.Log("x=" + x + "| z=" + z);
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("z");

        //On ecarte les bonus/malus du player
        x = x + 5.99f;
        z = z + 5.99f;
        Debug.Log("x=" + (int)x + "| z=" + (int)z);
        switch ((int)x)
        {
            case 0:
                l0.Remove((int)z + 1);
                l0.Remove((int)z);
                l0.Remove((int)z - 1);
                l1.Remove((int)z + 1);
                l1.Remove((int)z);
                l1.Remove((int)z - 1);
                break;
            case 1:
                l0.Remove((int)z + 1);
                l0.Remove((int)z);
                l0.Remove((int)z - 1);
                l1.Remove((int)z + 1);
                l1.Remove((int)z);
                l1.Remove((int)z - 1);
                l2.Remove((int)z + 1);
                l2.Remove((int)z);
                l2.Remove((int)z - 1);
                break;
            case 2:
                l3.Remove((int)z + 1);
                l3.Remove((int)z);
                l3.Remove((int)z - 1);
                l1.Remove((int)z + 1);
                l1.Remove((int)z);
                l1.Remove((int)z - 1);
                l2.Remove((int)z + 1);
                l2.Remove((int)z);
                l2.Remove((int)z - 1);
                break;
            case 3:
                l3.Remove((int)z + 1);
                l3.Remove((int)z);
                l3.Remove((int)z - 1);
                l4.Remove((int)z + 1);
                l4.Remove((int)z);
                l4.Remove((int)z - 1);
                l2.Remove((int)z + 1);
                l2.Remove((int)z);
                l2.Remove((int)z - 1);
                break;
            case 4:
                l3.Remove((int)z + 1);
                l3.Remove((int)z);
                l3.Remove((int)z - 1);
                l4.Remove((int)z + 1);
                l4.Remove((int)z);
                l4.Remove((int)z - 1);
                l5.Remove((int)z + 1);
                l5.Remove((int)z);
                l5.Remove((int)z - 1);
                break;
            case 5:
                l4.Remove((int)z + 1);
                l4.Remove((int)z);
                l4.Remove((int)z - 1);
                l5.Remove((int)z + 1);
                l5.Remove((int)z);
                l5.Remove((int)z - 1);
                break;
        }

        //On appelle les cases speciale aléatoire
        Placealea(Tresor);
        Placealea(Clef);
        Placealea(FausseClef);
        Placealea(Trou);
        Placealea(Torche);
        Placealea(Pic1);
        Placealea(Pic2);
        Placealea(Pic3);
        Placealea(Soin);
        Placealea(Serpent);
    }

    //############################################################# Est appelé toutes les secondes après le début
    void Update()
    {
        float x = Player.transform.position.x;
        float z = Player.transform.position.z;
        //############################################################# Deplace la lumière et la caméra sur le joueur
        Lumière.transform.position = new Vector3(x, 8f, z);
        Cam.transform.position = new Vector3(x, 8f, z);

        //############################################################# Verifier si le joueur est proche du trou et le prevenir en seccouant la cam

        if (Trou.transform.position.x + 1.3 >= x && x >= Trou.transform.position.x - 1.3 && Trou.transform.position.z + 1.3 >= z && z >= Trou.transform.position.z - 1.3)
        {
            Cam.transform.localPosition = new Vector3(Random.Range(x - 0.05f, x + 0.05f), 8f, Random.Range(z - 0.05f, z + 0.05f));
            Evenements.color = new Color(255, 222, 0, 255);
            Evenements.GetComponent<Text>().text = "Attention! Le sol est instable";
            Tpevent = (int)time;
        }

        //############################################################# Revenir en arrière avec la touche android
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Options", LoadSceneMode.Single);
        }

        //############################################################# On vérifie si on doit retirer l'event au bout de 3sec pour le message et le fond et 1sec pour l'anim des pic
        if (Evenements.GetComponent<Text>().text != "")
        {
            if (Tpevent + 3 <= (int)time)
            { 
                Evenements.color = new Color(255, 222, 0, 255); 
                Evenements.GetComponent<Text>().text = ""; 
                Fond.color = new Color32(0, 0, 0, 0);
                Pic1.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                Pic2.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                Pic3.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
            }
        }

        Tour.GetComponent<Text>().text = Ntour.ToString("0");
        Debug.DrawRay(transform.position, transform.forward);

        if (joueur == "player")
        {
            //############################################################# Si il ne n'est pas en deplacement rechercher les cases accessible
            if (!deplacement)
            {
                FindSelectableTiles();
                VerifClic();
            }
            else
            {
                Mouvement();
            }
        }
        else
        { }

        //############################################################## Chronomètre
        time += 1 * Time.deltaTime;
        Chrono.GetComponent<Text>().text = time.ToString("0"); 

        //############################################################## On verifie si le poison est encore actif, et dois enlever de la vie
        if (poison == true)
        { if ((int)time == (int)Tpoison + 5 && vie > 1) { vie--; Debug.Log("Vie=" + vie); Tpoison = (int)time; } }

        //############################################################## On verifie si il reste de la vie
        if (vie == 3) { Coeur1.color = new Color(255, 255, 255, 255); Coeur2.color = new Color(255, 255, 255, 255); Coeur3.color = new Color(255, 255, 255, 255); }
        if (vie == 2) { Coeur1.color = new Color(0, 0, 0, 0); Coeur2.color = new Color(255, 255, 255, 255); Coeur3.color = new Color(255, 255, 255, 255); }
        else
        {
            if (vie == 1) { Coeur1.color = new Color(0, 0, 0, 0); Coeur2.color = new Color(0, 0, 0, 0); Coeur3.color = new Color(255, 255, 255, 255); }
            else
            {
                if (vie == 0)
                {
                    Handheld.Vibrate();
                    Coeur3.color = new Color(0, 0, 0, 0);
                    Debug.Log("Plus de vie, Défaite!");
                    PlayerPrefs.SetString("mort", "pic");
                    SceneManager.LoadScene("Defaite");
                }
            }
        }

    }

    void VerifClic()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.selectable)
                    {
                        //Recup données emplacement joueur pour le suivre
                        MoveToTile(t);
                        //Compteur de tour à chaque mouvement  
                        Ntour++;
                        Tour.GetComponent<Text>().text = Ntour.ToString("0");
                        float x = Player.transform.position.x;
                        float z = Player.transform.position.z;
                        Debug.Log("x=" + x + "| z=" + z);
                    }
                }
            }
        }
    }
    //############################################################# Si le joueur est sur une case specifique 
    void OnTriggerEnter(Collider contact)
    {
        Debug.Log(contact.name);
        if (contact.name == "Clef")
        {
            Evenements.color = new Color(255, 220, 0, 255);
            Evenements.GetComponent<Text>().text = "Une Clef! Où est le trésor?";
            Tpevent = (int)time;
            clef = true;
            ImageClef.color = new Color(0, 255, 0, 255);
            Destroy(Clef);
        }
        if (contact.name == "FausseClef")
        {
            Evenements.color = new Color(255, 220, 0, 255);
            Evenements.GetComponent<Text>().text = "Oups! Fausse Clef";
            Tpevent = (int)time;
            Destroy(FausseClef);
        }
        if (contact.name == "Tresor")
        {
            if (clef == true)
            {
                //A la victoire on charge le scene win, on recup le pseudo qu'on detruit et crée un résultat av une clef qui s'incremente
                Evenements.color = new Color(255, 220, 0, 255);
                Evenements.GetComponent<Text>().text = "Victoire";
                Tpevent = (int)time;
                Debug.Log("Victoire!!");
                string Pseudo = PlayerPrefs.GetString("Pseudo");
                int i = 0;
                while (PlayerPrefs.HasKey(i.ToString()))
                {
                    i++;
                }
                Handheld.Vibrate();
                PlayerPrefs.SetString(i.ToString(), Pseudo + "/" + time);
                PlayerPrefs.SetString("TempsVictoire", time.ToString());
                SceneManager.LoadScene("Victoire");
                Destroy(Tresor);
            }
        }
        if (contact.name == "Trou")
        {
            //Affichage fond rouge
            Fond.color = new Color32(255, 0, 0, 60);
            Handheld.Vibrate();
            Trou.GetComponent<Renderer>().enabled = true;
            Debug.Log("Tombé, Défaite!");
            PlayerPrefs.SetString("mort","trou");
            SceneManager.LoadScene("Defaite");
        }
        if (contact.name == "Torche")
        {
            Evenements.color = new Color(255, 220, 0, 255);
            Evenements.GetComponent<Text>().text = "Cool! Une torche";
            Tpevent = (int)time;
            Lumière.spotAngle = 35;
            Destroy(Torche);
        }
        if (contact.name == "Pic1")
        {
            Evenements.color = new Color(255, 220, 0, 255);
            Evenements.GetComponent<Text>().text = "Aie! des Pics";
            Tpevent = (int)time;
            vie--;
            Debug.Log("Vie=" + vie);
            Pic1.GetComponent<Renderer>().enabled = true;
            Pic1.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            //Affichage fond rouge
            Fond.color = new Color32(255, 0, 0, 60);
        }
        if (contact.name == "Pic2")
        {
            Evenements.color = new Color(255, 220, 0, 255);
            Evenements.GetComponent<Text>().text = "Aie! des Pics";
            Tpevent = (int)time;
            vie--;
            Debug.Log("Vie=" + vie);
            Pic2.GetComponent<Renderer>().enabled = true;
            Pic2.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            //Affichage fond rouge
            Fond.color = new Color32(255, 0, 0, 60);
        }
        if (contact.name == "Pic3")
        {
            //Affichage events texte
            Evenements.color = new Color(255, 220, 0, 255);
            Evenements.GetComponent<Text>().text = "Aie! des Pics";
            Tpevent = (int)time;
            vie--;
            Debug.Log("Vie=" + vie);
            //Affichage pic
            Pic3.GetComponent<Renderer>().enabled = true;
            Pic3.transform.localScale = new Vector3(0.5f, 0.5f,1f);
            //Affichage fond rouge
            Fond.color = new Color32(255, 0, 0, 60);
        }
        if (contact.name == "Serpent")
        {
            //Affichage event empoisonné
            Evenements.GetComponent<Text>().text = "Empoisonné! Vite des Soins";
            Evenements.color = Color.green;
            Tpoison = (int)time;
            Tpevent = (int)time;
            Player.GetComponent<Renderer>().material.color = Color.green;
            poison = true;
            //Ecran vert poison
            Fond.color = new Color32(0, 255, 0, 60);
        }
        if (contact.name == "Soin")
        {
            Evenements.color = new Color(255, 220, 0, 255);
            Evenements.GetComponent<Text>().text = "Super! Je me sens mieux";
            Tpevent = (int)time;
            Player.GetComponent<Renderer>().material.color = new Color(255, 150, 0, 255);
            if (vie < 3) { vie++; }
            poison = false;
            Debug.Log("Vie=" + vie);
            Destroy(Soin);
        }
    }

    //############################################################# Generation aléatoire
    void Placealea(GameObject obj)
    {
        //############################################################# On verifie la disponiblité de l'emplacement généré avec une liste des coordonnées
        int moinsx = Random.Range(0, 5); //############################################################# Génère un entier compris entre 0 et 5
        int moinsz = Random.Range(0, 9); //############################################################# Génère un entier compris entre 0 et 10
        float x = moinsx - 5.40f;
        float z = moinsz - 5.55f;

        switch (moinsx)
        {
            case 0:
                while (l0.Contains(moinsz) != true)
                {
                    moinsz = Random.Range(0, 9); // Génère un entier compris entre 0 et 10
                    z = -5.5f + moinsz;
                }
                l0.Remove(moinsz);
                obj.transform.position = new Vector3(x, 1f, z);
                Debug.Log(obj.name + " x=" + moinsx + "| z=" + moinsz);
                break;
            case 1:
                while (l1.Contains(moinsz) != true)
                {
                    moinsz = Random.Range(0, 9); // Génère un entier compris entre 0 et 10
                    z = -5.5f + moinsz;
                }
                l1.Remove(moinsz);
                obj.transform.position = new Vector3(x, 1f, z);
                Debug.Log(obj.name + " x=" + moinsx + "| z=" + moinsz);
                break;
            case 2:
                while (l2.Contains(moinsz) != true)
                {
                    moinsz = Random.Range(0, 9); // Génère un entier compris entre 0 et 10
                    z = -5.5f + moinsz;
                }
                l2.Remove(moinsz);
                obj.transform.position = new Vector3(x, 1f, z);
                Debug.Log(obj.name + " x=" + moinsx + "| z=" + moinsz);
                break;
            case 3:
                while (l3.Contains(moinsz) != true)
                {
                    moinsz = Random.Range(0, 9); // Génère un entier compris entre 0 et 10
                    z = -5.5f + moinsz;
                }
                l3.Remove(moinsz);
                obj.transform.position = new Vector3(x, 1f, z);
                Debug.Log(obj.name + " x=" + moinsx + "| z=" + moinsz);
                break;
            case 4:
                while (l4.Contains(moinsz) != true)
                {
                    moinsz = Random.Range(0, 9); // Génère un entier compris entre 0 et 10
                    z = -5.5f + moinsz;
                }
                l4.Remove(moinsz);
                obj.transform.position = new Vector3(x, 1f, z);
                Debug.Log(obj.name + " x=" + moinsx + "| z=" + moinsz);
                break;
            case 5:
                while (l5.Contains(moinsz) != true)
                {
                    moinsz = Random.Range(0, 9); // Génère un entier compris entre 0 et 10
                    z = -5.5f + moinsz;
                }
                l5.Remove(moinsz);
                obj.transform.position = new Vector3(x, 1f, z);
                Debug.Log(obj.name + " x=" + moinsx + "| z=" + moinsz);
                break;
        }

    }

}
