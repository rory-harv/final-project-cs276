using UnityEngine;

public class Card_Backside : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Randomize()
    {
        // start with list of potential cards (5)
        // randomize card objects to associate with a specific front side card (list of 10 containing 2 duplicates per card type)
        // in mousedown, take assigned frontside, delete gameobject, and respawn frontside associated card

        // list[backside cards]
        // list[frontside cards] == [type1, type1, type2, type2 for # of backside cards]
        // list[randint 1-len(list[backside cards])]
        // for i in range(len(list[backside cards]))
            // 
    
    }

    void OnMouseDown()
    {
        objectName = gameObject.name;
        if (objectName == "Card_BackSide1")
        {

        }
        if (objectName == "Card_BackSide2")
        {

        }
        if (objectName == "Card_BackSide3")
        {

        }
        if (objectName == "Card_BackSide4")
        {

        }
        if (objectName == "Card_BackSide5")
        {

        }
        if (objectName == "Card_BackSide6")
        {
            
        }
        Debug.Log(gameObject.name + " was clicked!");
        Destroy(gameObject);
    }
}
