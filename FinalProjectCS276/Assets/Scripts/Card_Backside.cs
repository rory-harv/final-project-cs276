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
    public List<GameObject> awakeList;
    public List<GameObject> asleepList;
    public List<string> cardFrontTagList;

    public bool deactivate = false;
    public bool activate = false;
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

    void ChangeState(int cardNum, GameObject clickedCard)
    {
        if (deactivate == true)
        {
            clickedCard.SetActive(false);    // hides card 1 backside
            deactivate = false;
        }

        if (activate == true)
        {
            cardFrontList[cardNum].SetActive(true);
            activate = false;
        }
    }

    void OnMouseDown()
    {
        string cardTag = gameObject.tag;
        GameObject clickedCard = gameObject;

        if (cardTag == "Card1") // checks if card 1 clicked first
        {
            int cardNum = 0;
            MakeMatch(cardNum, clickedCard);
        }

        else if (cardTag == "Card2")
        {
            int cardNum = 1;
            MakeMatch(cardNum, clickedCard);
        }

        else if (cardTag == "Card3")
        {
            int cardNum = 2;
            MakeMatch(cardNum, clickedCard);
        }

        else if (cardTag == "Card4")
        {
            int cardNum = 3;
            MakeMatch(cardNum, clickedCard);
        }

        else if (cardTag == "Card5")
        {
            int cardNum = 4;
            MakeMatch(cardNum, clickedCard);
        }

        else if (cardTag == "Card6")
        {
            int cardNum = 5;
            MakeMatch(cardNum, clickedCard);
        }

        else if (cardTag == "Card7")
        {
            int cardNum = 6;
            MakeMatch(cardNum, clickedCard);
        }

        else if (cardTag == "Card8")
        {
            int cardNum = 7;
            MakeMatch(cardNum, clickedCard);
        }

        else if (cardTag == "Card9")
        {
            int cardNum = 8;
            MakeMatch(cardNum, clickedCard);
        }

        else if (cardTag == "Card10")
        {
            int cardNum = 9;
            MakeMatch(cardNum, clickedCard);
        }

    }
    

    void MakeMatch(int cardNum, GameObject clickedCard)
    {
        
        if (clickedCard.activeSelf)
        {
            deactivate = true;
            asleepList.Add(clickedCard);
            ChangeState(cardNum, clickedCard);
        }

        if (!cardFrontList[cardNum].activeSelf)
        {
            activate = true;
            awakeList.Add(cardFrontList[cardNum]);
            ChangeState(cardNum, clickedCard);
        }
        


        // add game object to 'asleep' list & front card to 'awake' list
        
        Debug.Log(asleepList);

        if (asleepList.Count == 2 && awakeList.Count == 2)    // checks if 2 cards clicked
        {
            // get tag of awakelist[0] and compare to awakelist[1]
            if (awakeList[0].tag == awakeList[1].tag)
            {
                Destroy(awakeList[0]);
                Destroy(awakeList[1]);
                Destroy(asleepList[0]);
                Destroy(asleepList[1]);

                asleepList.RemoveAt(0);
                asleepList.RemoveAt(1);
                awakeList.RemoveAt(0);
                awakeList.RemoveAt(1);
            }
            else
            {
                awakeList[0].SetActive(false);
                awakeList[1].SetActive(false);
                asleepList[0].SetActive(true);
                asleepList[1].SetActive(true);

                asleepList.RemoveAt(0);
                asleepList.RemoveAt(1);
                awakeList.RemoveAt(0);
                awakeList.RemoveAt(1);
            }
        }
    }

}
