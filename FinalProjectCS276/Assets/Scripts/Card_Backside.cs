using UnityEngine;
using System.Collections.Generic;

public class Card_Backside : MonoBehaviour
{
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

    public GameObject Square_Prefab;
    public GameObject Circle_Prefab;
    public GameObject Triangle_Prefab;
    public GameObject Oval_Prefab;
    public GameObject Polygon_Prefab;

    public List<GameObject> cardFrontList;
    public List<GameObject> cardList;
    public List<string> cardFrontTagList;
    public static int clicks = 0;
    public bool match = false;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardList = new List<GameObject> {Card1_Prefab, Card2_Prefab, Card3_Prefab, Card4_Prefab, Card5_Prefab, Card6_Prefab, Card7_Prefab, Card8_Prefab, Card9_Prefab, Card10_Prefab};

        cardFrontList = new List<GameObject> {Square_Prefab, Square_Prefab, Circle_Prefab, Triangle_Prefab, Oval_Prefab, Circle_Prefab, Polygon_Prefab, Oval_Prefab, Triangle_Prefab, Polygon_Prefab};

        cardFrontTagList = new List<string> {"CardSquare", "CardSquare", "CardCircle", "CardTriangle", "CardOval", "CardCircle", "CardPolygon", "CardOval", "CardTriangle", "CardPolygon"};

        foreach (GameObject card in cardList)
        {
            card.SetActive(true);
        }

        foreach (GameObject card in cardFrontList)
        {
            card.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Randomize()
    {
        
    }


    void OnMouseDown()
    {
        string cardTag = gameObject.tag;

        if (cardTag == "Card1") // checks if card 1 clicked first
        {
            int cardNum = 0;
            MakeMatch(cardNum);
        }

        if (cardTag == "Card2")
        {
            int cardNum = 1;
            MakeMatch(cardNum);
        }

        if (cardTag == "Card3")
        {
            int cardNum = 2;
            MakeMatch(cardNum);
        }

        if (cardTag == "Card4")
        {
            int cardNum = 3;
            MakeMatch(cardNum);
        }
        if (cardTag == "Card5")
        {
            int cardNum = 4;
            MakeMatch(cardNum);
        }
        if (cardTag == "Card6")
        {
            int cardNum = 5;
            MakeMatch(cardNum);
        }
        if (cardTag == "Card7")
        {
            int cardNum = 6;
            MakeMatch(cardNum);
        }
        if (cardTag == "Card8")
        {
            int cardNum = 7;
            MakeMatch(cardNum);
        }
        if (cardTag == "Card9")
        {
            int cardNum = 8;
            MakeMatch(cardNum);
        }
        if (cardTag == "Card10")
        {
            int cardNum = 9;
            MakeMatch(cardNum);
        }

    }
    
    void MakeMatch(int cardNum)
    {
        clicks++;
        Debug.Log(clicks);
        gameObject.SetActive(false);    // hides card 1 backside
        if (clicks % 2 == 0)    // checks if 2 cards clicked
        {
            string frontCardTag = cardFrontTagList[cardNum]; // name of front card type

            GameObject[] frontCardMatches = GameObject.FindGameObjectsWithTag(frontCardTag);    // list of cards with clicked on type

            foreach (GameObject card in frontCardMatches)
            {
                if (card.activeSelf)    // if card is flipped
                {
                    match = true;
                    clicks = 0;
                    card.SetActive(false);

                    Destroy(card);  // delete front of card prefab
                    Destroy(gameObject);    // delete backside of card clicked on
                }
            }
        }
    }

}
