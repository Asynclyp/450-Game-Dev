using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadCharacters : MonoBehaviour
{
    //public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public GameObject[] characters;
    public GameObject[] characterCameras;

    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectCharacter");
        Debug.Log("Selecting character!" + selectedCharacter);
        //GameObject prefab = characterPrefabs[selectedCharacter];
        //GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        characters[selectedCharacter].SetActive(true);
        characterCameras[selectedCharacter].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
