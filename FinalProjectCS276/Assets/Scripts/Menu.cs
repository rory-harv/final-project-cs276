using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{

    public UIDocument uiDocument;
    private Button level1Button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        level1Button = uiDocument.rootVisualElement.Q<Button>("Level1Button");
        level1Button.style.display = DisplayStyle.Flex;
    }

    // Update is called once per frame
    void Update()
    {
        level1Button.clicked += Level1Scene;    // checks if level 1 button pressed
    }

    void Level1Scene()
    {
        SceneManager.LoadScene("Game"); // reloads scene from starter to level 1
    }
}
