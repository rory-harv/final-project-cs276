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

    public GameObject Card1_Front;
    public GameObject Card2_Front;
    public GameObject Card3_Front;
    public GameObject Card4_Front;
    public GameObject Card5_Front;
    public GameObject Card6_Front;
    public GameObject Card7_Front;
    public GameObject Card8_Front;
    public GameObject Card9_Front;
    public GameObject Card10_Front;

    public List<GameObject> cardFrontList;
    public List<GameObject> cardList;
    public List<GameObject> awakeList;
    public List<GameObject> asleepList;
    public List<string> cardFrontTagList;

    public int turns = 6;
    public int clicks = 0;
    public Dictionary<GameObject, string> awakeDict = new Dictionary<GameObject, string>();

    public GameObject cardClicked;   // card back clicked on
	public string cardClickedTag;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        cardList = new List<GameObject> {Card1_Prefab, Card2_Prefab, Card3_Prefab, Card4_Prefab, Card5_Prefab, Card6_Prefab, Card7_Prefab, Card8_Prefab, Card9_Prefab, Card10_Prefab};

        cardFrontList = new List<GameObject> {Card1_Front, Card2_Front, Card3_Front, Card4_Front, Card5_Front, Card6_Front, Card7_Front, Card8_Front, Card9_Front, Card10_Front};

        awakeDict = new Dictionary<GameObject, string>();

        foreach (GameObject card in cardList)
        {
            card.GetComponent<SpriteRenderer>().enabled = true; 
        }

        foreach (GameObject card in cardFrontList)
        {
            card.GetComponent<SpriteRenderer>().enabled = false; 
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnMouseDown()
    {
        cardClicked = gameObject;   // card back clicked on
	    cardClickedTag = gameObject.tag;
	
	    if (turns > 0)  // if player still has turns left
        {
            if (clicks < 2) // checks if two cards have been clicked
            {
                if (cardClicked.GetComponent<SpriteRenderer>().enabled = true)	// if cardback enabled
                {
                    AddToAwake(cardClicked, cardClickedTag);    // adds clicked card to the awake list
                    FlipCard(cardClicked);  // flips card from back to front side showing
                }
            }

            else 
            {
                CheckMatch();   // checks if 2 cards clicked are a match
            }	
        }

        else 
        {
            EndGame();  // ends games if out of turns
        }
    }
    
    void FlipCard(GameObject cardClicked)
    {
        cardClicked.GetComponent<SpriteRenderer>().enabled = false;	// disabled cardback
        
        clicks ++;
    }

    void AddToAwake(GameObject cardClicked, string cardClickedTag)
    {
        awakeDict[cardClicked] = cardClickedTag; // adds cardclicked to awakedict
    }

    void CheckMatch() 	// make separate file
    {
        if (awakeDict.Count == 2)
        {
            List<GameObject> keysList = new List<GameObject>(awakeDict.Keys);

            if (keysList[0] == keysList[1])
            {
                MakeMatch(awakeDict);
            }

            else
            {
                turns--;
                clicks = 0;
                Update();
            }
        }
    }

    void MakeMatch(Dictionary<GameObject, string> awakeDict)
    {
        List<GameObject> keysList = new List<GameObject>(awakeDict.Keys);

        GameObject Card1 = keysList[0];	// declare cards as objects
        GameObject Card2 = keysList[1];
        
        string cardtag = awakeDict[Card1];

        awakeDict.Remove(Card1);
        awakeDict.Remove(Card2); 	// remove cards from awake
        
        turns--;
        clicks = 0;

        Card1.GetComponent<SpriteRenderer>().enabled = false;	
        Card2.GetComponent<SpriteRenderer>().enabled = false;
    }

    void EndGame()
    {
        turns = 0;
        clicks = 2;
        //Display restart
    }



}
