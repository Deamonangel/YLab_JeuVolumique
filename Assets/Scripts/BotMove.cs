/*
PROJET JEU VOLUMIQUE
ADRIEN MONTCHER
17/03/2020
*/
using UnityEngine;
using UnityEngine.UI;
using System;

public class BotMove : TacticsMove 
{
    GameObject target;
    public Text Tour;
    public int Tp;

    // Initialisation
    void Start ()
	{
        Tour = GameObject.Find("Tour").GetComponent<Text>();
        Init();
        Tp = Int32.Parse(Tour.GetComponent<Text>().text)-1;
	}

    // Mise à jour
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);
        if (PlayerMove.joueur == "bot")
        {
            if (!deplacement)
            {
                if (Int32.Parse(Tour.GetComponent<Text>().text) == Tp + 10)
                {
                    target = GameObject.Find("Player");
                    Tp = Int32.Parse(Tour.GetComponent<Text>().text)-1;
                    CalculatePath();
                    FindSelectableTiles();
                    actualTargetTile.target = true;
                }
                else
                {
                    PlayerMove.joueur = "player";
                }
            }
            else
            {
                Mouvement();
            }
        }
        else { }

    }

    void CalculatePath()
    {
        Tile targetTile = GetTargetTile(target);
        FindPath(targetTile);
    }
}
