using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter;
    public GameObject mainMenu;
    public GameObject characterMenu;
    public TMP_Text characterName;
    public string[] characterNames = { "Jim", "Yoyo", "Sarah", "Peace", "Jane" };
    private string currentCharacter;

    private void Start()
    {
        selectedCharacter = 0;
        currentCharacter = characterNames[selectedCharacter];
        characterName.text = currentCharacter;
        Debug.Log("name " + characterName.text);
        Debug.Log("characters " + characters.Length);
    }

    public void NextCharacter() 
    { 
        int nextIndex = (selectedCharacter + 1) % characterNames.Length;
        currentCharacter = characterNames[nextIndex];
        characterName.text = currentCharacter;
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = nextIndex;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter = characters.Length;
            selectedCharacter = characters.Length - 1;
        }
        characterName.text = characterNames[selectedCharacter];
        characters[selectedCharacter].SetActive(true);
    }


    public void PlayGame()
    {
        Debug.Log("Select " + selectedCharacter);
        PlayerPrefs.SetInt("selectCharacter", selectedCharacter);
        StartCoroutine(LoadYourAsyncScene());
    }
    public void ShowCharacterMenu()
    {
        mainMenu.SetActive(false);
        characterMenu.SetActive(true);
        characters[selectedCharacter].SetActive(true);
    }
    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }


}
