using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;

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
    private Label nonMatchText;
    private Button restartButton;

    private List<GameObject> cardFrontList;
    private List<GameObject> cardList;
    
    private GameObject? activeCard1;
    private GameObject? activeCard2;

    private static int turns;

    private GameObject cardClicked;   // card back clicked on
	private string cardClickedTag;

    private bool completed = false;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turns = 8;

        turnsText = uiDocument.rootVisualElement.Q<Label>("TurnsLabel");
        matchText = uiDocument.rootVisualElement.Q<Label>("MatchLabel");
        nonMatchText = uiDocument.rootVisualElement.Q<Label>("NonMatchLabel");
        matchText.style.display = DisplayStyle.None;
        nonMatchText.style.display = DisplayStyle.None;
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None;

        cardList = new List<GameObject> {Card1_Prefab, Card2_Prefab, Card3_Prefab, Card4_Prefab, Card5_Prefab, Card6_Prefab, Card7_Prefab, Card8_Prefab, Card9_Prefab, Card10_Prefab};

        cardFrontList = new List<GameObject> {Card1_Front, Card2_Front, Card3_Front, Card4_Front, Card5_Front, Card6_Front, Card7_Front, Card8_Front, Card9_Front, Card10_Front};

        foreach (GameObject card in cardFrontList)
        {
            card.GetComponent<SpriteRenderer>().enabled = true;     // sets all card fronts active
        }

    }

    // Update is called once per frame
    void Update()
    {
        turnsText.text = "Turns Left: " + turns;    // updates turns text

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // checks mouse position
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)   // checks if a card is clicked on
            {
                MouseClick(hit.collider.gameObject);
            }

        }
        
    }

    void MouseClick(GameObject gameObject)
    {
        cardClicked = gameObject;   // card back clicked on
	    cardClickedTag = gameObject.tag;
	
	    if (turns > 0 && completed == false)  // if player still has turns left or has not finished the matches
        {
            if (activeCard1 == null || activeCard2 == null) // checks if two cards have been clicked
            {
                if (activeCard1 == null)
                {
                    FlipCard1(cardClicked);     // flips over first card
                }

                else if (activeCard2 == null)
                {
                    FlipCard2(cardClicked);     // flips over second card
                    CheckMatch();   // checks to see if both cards a match
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

        activeCard1 = cardFrontList[index];     // sets active front card
        activeCard1.GetComponent<SpriteRenderer>().enabled = true;  // ensure front card is visible

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

        activeCard2 = cardFrontList[index];     // sets active front card 
        activeCard2.GetComponent<SpriteRenderer>().enabled = true;  // ensure front card is visible

        cardClicked.GetComponent<SpriteRenderer>().enabled = false;	// disabled cardback
        cardClicked.GetComponent<BoxCollider2D>().enabled = false;
    }


    void CheckMatch() 	// make separate file
    {
        turns--;

        foreach (GameObject card in cardList)   // loops through cards
        {
            bool enabled = card.GetComponent<SpriteRenderer>().enabled;     // bool if there exists an active card
            if (enabled == true)    // if there is a card active
            {
                completed = false;  // continue game
                break;  // break loop
            }
            else
            {
                completed = true;   // all cards disabled & game completed
            }
        }


        if (turns == 0 || completed == true)     // checks end condition after updating turns & completed variable
        {
            EndGame();
        }
        
        if (activeCard1 != null && activeCard2 != null)     // if 2 active cards
        {
            if (activeCard1.tag == activeCard2.tag)     // if cards a match
            {
                StartCoroutine(MakeMatch(activeCard1, activeCard2, 1f));
            }

            else if (activeCard1.tag != activeCard2.tag)    // if cards are not a match
            {
                StartCoroutine(BreakMatchCoroutine(1f));  // delay before flipping back
            }
        }
    }

    private IEnumerator MakeMatch(GameObject card1, GameObject card2, float delay)  // deletes cards if match
    {
        ShowMatchText();
        yield return new WaitForSeconds(delay); // pauses match on screen
        Invoke("HideMatchText", 1f);    // hides match text

        card1.GetComponent<SpriteRenderer>().enabled = false;	    // disables front cards after match complete
        card2.GetComponent<SpriteRenderer>().enabled = false;

        activeCard1 = null;     // resets active cards (using class fields)
        activeCard2 = null;

    }


    public void ShowMatchText()
    {
        matchText.style.display = DisplayStyle.Flex;    // displays match text
    }

    public void HideMatchText()
    {
        matchText.style.display = DisplayStyle.None;    // hides match text
    }

    public void ShowNonMatchText()
    {
        nonMatchText.style.display = DisplayStyle.Flex;    // displays nonmatch text
    }
    public void HideNonMatchText()
    {
        nonMatchText.style.display = DisplayStyle.None;    // hides nonmatch text
    }

    private IEnumerator BreakMatchCoroutine(float delay)     // resets cards if not a match
    {
        ShowNonMatchText();
        yield return new WaitForSeconds(delay); // wait so player can see both cards
        Invoke("HideNonMatchText", 1f);    // hides nonmatch text
        
        if (activeCard1 == null || activeCard2 == null) yield break; // safety check

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
        
        // Disable front card sprites first
        activeCard1.GetComponent<SpriteRenderer>().enabled = false;
        activeCard2.GetComponent<SpriteRenderer>().enabled = false;

        // Disable front card sprites first
        activeCard1.GetComponent<SpriteRenderer>().enabled = false;
        activeCard2.GetComponent<SpriteRenderer>().enabled = false;

        // Re-enable backside cards
        cardList[index1].GetComponent<SpriteRenderer>().enabled = true;	    // re-enables backcard of first
        cardList[index2].GetComponent<SpriteRenderer>().enabled = true;     // re-enables backcard of second

        cardList[index1].GetComponent<BoxCollider2D>().enabled = true;
        cardList[index2].GetComponent<BoxCollider2D>().enabled = true;
        
        activeCard1 = null;
        activeCard2 = null;

    }



    void EndGame()
    {
        turns = 0;  // satisfies end condition
        restartButton.style.display = DisplayStyle.Flex;    // displays restart button
        restartButton.clicked += ReloadScene;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     // reloads scene to begin from the start
    }

}
