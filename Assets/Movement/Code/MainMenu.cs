using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter;
    public GameObject mainMenu;
    public GameObject characterMenu;

    private void Start()
    {
        selectedCharacter = 0;
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1)% characters.Length;
        characters[selectedCharacter].SetActive(true);
        Debug.Log(selectedCharacter);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter < 0)
        {
            selectedCharacter = characters.Length-1;
        }
        characters[selectedCharacter].SetActive(true);
        Debug.Log(selectedCharacter);
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
