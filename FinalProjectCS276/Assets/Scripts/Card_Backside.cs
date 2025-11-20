using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
public class Card_Backside : MonoBehaviour
{
    public UIDocument uiDocument;

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

    private List<GameObject> cardFrontList;
    private List<GameObject> cardList;
    
    private GameObject? activeCard1;
    private GameObject? activeCard2;

    private int turns = 6;
    
    private Dictionary<GameObject, string> awakeDict = new Dictionary<GameObject, string>();

    private GameObject cardClicked;   // card back clicked on
	private string cardClickedTag;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        cardList = new List<GameObject> {Card1_Prefab, Card2_Prefab, Card3_Prefab, Card4_Prefab, Card5_Prefab, Card6_Prefab, Card7_Prefab, Card8_Prefab, Card9_Prefab, Card10_Prefab};

        cardFrontList = new List<GameObject> {Card1_Front, Card2_Front, Card3_Front, Card4_Front, Card5_Front, Card6_Front, Card7_Front, Card8_Front, Card9_Front, Card10_Front};

        awakeDict = new Dictionary<GameObject, string>();

        foreach (GameObject card in cardFrontList)
        {
            card.GetComponent<SpriteRenderer>().enabled = true; 
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                // Create a ray from the camera through the mouse position
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit.collider != null)
                {
                    MouseClick(hit.collider.gameObject);
                }

        }
        
    }

    void MouseClick(GameObject gameObject)
    {
        cardClicked = gameObject;   // card back clicked on
	    cardClickedTag = gameObject.tag;
	
	    if (turns > 0)  // if player still has turns left
        {
            if (activeCard1 == null || activeCard2 == null) // checks if two cards have been clicked
            {
                if (activeCard1 == null)
                {
                    FlipCard1(cardClicked);
                }

                else if (activeCard2 == null)
                {
                    FlipCard2(cardClicked);
                    CheckMatch();
                }
                // if (cardClicked.GetComponent<SpriteRenderer>().enabled = true)	// if cardback enabled
                // {
                //     AddToAwake(cardClicked, cardClickedTag);    // adds clicked card to the awake list
                //     FlipCard(cardClicked, activeCard1);  // flips card from back to front side showing
                // }

            }
	
        }

        else 
        {
            EndGame();  // ends games if out of turns
        }
    }
    
    void FlipCard1(GameObject cardClicked)
    {
        int index = 0;
        for (int i = 0; i < cardList.Count; i++)
        {
            if (cardClicked == cardList[i])
            {
                index = i;
            }
        }

        activeCard1 = cardFrontList[index];

        cardClicked.GetComponent<SpriteRenderer>().enabled = false;	// disabled cardback
        cardClicked.GetComponent<BoxCollider2D>().enabled = false;
    }

     void FlipCard2(GameObject cardClicked)
    {
        int index = 0;
        for (int i = 0; i < cardList.Count; i++)
        {
            if (cardClicked == cardList[i])
            {
                index = i;
            }
        }

        activeCard2 = cardFrontList[index];

        cardClicked.GetComponent<SpriteRenderer>().enabled = false;	// disabled cardback
        cardClicked.GetComponent<BoxCollider2D>().enabled = false;
    }


    void CheckMatch() 	// make separate file
    {
        if (activeCard1 != null && activeCard2 != null)
        {
            if (activeCard1.tag == activeCard2.tag)
            {
                MakeMatch(activeCard1, activeCard2);
            }

            else
            {
                turns--;
                activeCard1 = null;
                activeCard2 = null;
            }
        }
    }

    void MakeMatch(GameObject activeCard1, GameObject activeCard2)
    {
        //List<GameObject> keysList = new List<GameObject>(awakeDict.Keys);

        // GameObject Card1 = keysList[0];	// declare cards as objects
        // GameObject Card2 = keysList[1];
        
        // string cardtag = awakeDict[Card1];

        // awakeDict.Remove(Card1);
        // awakeDict.Remove(Card2); 	// remove cards from awake
        
        turns--;
        //clicks = 0;

        activeCard1.GetComponent<SpriteRenderer>().enabled = false;	
        activeCard2.GetComponent<SpriteRenderer>().enabled = false;

        activeCard1 = null;
        activeCard2 = null;


    }

    void EndGame()
    {
        turns = 0;
        //clicks = 2;
        //Display restart
    }



}
