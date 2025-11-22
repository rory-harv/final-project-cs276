using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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

    private Label turnsText;

    private Label matchText;

    private List<GameObject> cardFrontList;
    private List<GameObject> cardList;
    
    private GameObject? activeCard1;
    private GameObject? activeCard2;

    private static int turns = 6;
    
    private Dictionary<GameObject, string> awakeDict = new Dictionary<GameObject, string>();

    private GameObject cardClicked;   // card back clicked on
	private string cardClickedTag;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        turnsText = uiDocument.rootVisualElement.Q<Label>("TurnsLabel");
        matchText = uiDocument.rootVisualElement.Q<Label>("MatchLabel");
        matchText.style.display = DisplayStyle.None;

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
        turnsText.text = "Turns Left: " + turns;

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
        turns--;
        if (activeCard1 != null && activeCard2 != null)
        {
            if (activeCard1.tag == activeCard2.tag)
            {
                MakeMatch(activeCard1, activeCard2);
            }

            else if (activeCard1.tag != activeCard2.tag)
            {
                BreakMatch(activeCard1, activeCard2);
            }
        }
    }

    void MakeMatch(GameObject activeCard1, GameObject activeCard2)  // deletes cards if match
    {
        ShowText();
        Invoke("HideText", 2f);

        activeCard1.GetComponent<SpriteRenderer>().enabled = false;	    // disables front cards after match complete
        activeCard2.GetComponent<SpriteRenderer>().enabled = false;

        activeCard1 = null;     // resets active cards
        activeCard2 = null;

    }

    public void ShowText()
    {
        matchText.style.display = DisplayStyle.Flex;
    }

    public void HideText()
    {
        matchText.style.display = DisplayStyle.None;
    }

    void BreakMatch(GameObject activeCard1, GameObject activeCard2)     // resets cards if not a match
    {

        int index1 = 0; // finds backside of first card
        for (int i = 0; i < cardList.Count; i++)
        {
            if (activeCard1 == cardFrontList[i])
            {
                index1 = i;
            }
        }

        int index2 = 0; // finds backside of second card
        for (int j = 0; j < cardList.Count; j++)
        {
            if (activeCard2 == cardFrontList[j])
            {
                index2 = j;
            }
        }

        cardList[index1].GetComponent<SpriteRenderer>().enabled = true;	    // re-enables backcard of first
        cardList[index1].GetComponent<BoxCollider2D>().enabled = true;

        cardList[index2].GetComponent<SpriteRenderer>().enabled = true;     // re-enables backcard of second
        cardList[index2].GetComponent<BoxCollider2D>().enabled = true;

        activeCard1 = null;     // resets active cards
        activeCard2 = null;
    }



    void EndGame()
    {
        turns = 0;
        //Display restart
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
