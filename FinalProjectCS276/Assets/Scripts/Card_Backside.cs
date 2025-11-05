using UnityEngine;
using System.Collections.Generic;

public class Card_Backside : MonoBehaviour
{
    public GameObject FrontSide_SquarePrefab;
    public GameObject Card1_Prefab;
    public GameObject Card2_Prefab;
    public GameObject Card3_Prefab;
    public GameObject Card4_Prefab;
    public GameObject Card5_Prefab;
    public GameObject Card6_Prefab;
    public GameObject Card7_Prefab;
    public GameObject Card8_Prefab;
    public GameObject Card9_Prefab;
    public GameObject Card10_Prefab;
    public List<string> cardFrontList;
    public List<GameObject> cardList;
    public int clicks = 0;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardList = new List<GameObject> {Card1_Prefab, Card2_Prefab, Card3_Prefab, Card4_Prefab,
        Card5_Prefab, Card6_Prefab, Card7_Prefab, Card8_Prefab, Card9_Prefab, Card10_Prefab};

        cardFrontList = new List<string> { "CardSquare", "CardSquare", "CardCircle", "CardTriangle",
    "CardOval", "CardCircle", "CardPolygon", "CardOval", "CardTriangle", "CardPolygon"};
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Randomize()
    {
        //List<string> cardFrontList = new List<string> { "CardSquare", "CardSquare", "Cherry" };
        //List<GameObject> cardList = new List<GameObject> {Card1_Prefab, Card2_Prefab, Card3_Prefab, Card4_Prefab,
        //Card5_Prefab, Card6_Prefab, Card7_Prefab, Card8_Prefab, Card9_Prefab, Card10_Prefab};
    }


    void OnMouseDown()
    {
        clicks++;
        string cardTag = gameObject.tag;

        if (cardTag == "Card1") // checks if card 1 clicked first
        {
            gameObject.SetActive(false);    // hides card 1 backside
            if (clicks % 2 == 0)
            {
                string frontCardTag = cardFrontList[0];

                GameObject[] frontCardMatches = GameObject.FindGameObjectsWithTag(frontCardTag);

                foreach (GameObject card in frontCardMatches)
                {
                    if (card.activeSelf)
                    {
                        Destroy(card);
                        Destroy(gameObject);
                    }
                }
            }

        }

        if (cardTag == "Card2")
        {   
            gameObject.SetActive(false);

        }
        if (cardTag == "Card3")
        {

        }
        if (cardTag == "Card4")
        {

        }
        if (cardTag == "Card5")
        {

        }
        if (cardTag == "Card6")
        {
            
        }
        
    }
}
