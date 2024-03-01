using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos;
    public bool creatingSection = false;
    public int secNum;
    public Transform player;

    private List<GameObject> activeScenes = new List<GameObject>();


    void Start()
    {
        zPos = 200;
        for (int i =0; i< 7; i++)
        {
            secNum = Random.Range(0, 3);
            GameObject newScene = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
            activeScenes.Add(newScene);
            zPos += 50;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z > (zPos-300))
        {
            //creatingSection = true;
            GenerateSection();
        }
    }

    void GenerateSection()
    {
        Debug.Log("New scene at " + zPos);
        secNum = Random.Range(0, 3);
        GameObject newScene = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        //yield return new WaitForSeconds(10);
        //creatingSection = false;
        activeScenes.Add(newScene);
        if (activeScenes.Count > 10)
        {
            GameObject sceneToRemove = activeScenes[0];
            activeScenes.RemoveAt(0);
            Destroy(sceneToRemove);
            Debug.Log("Destroy one scene" );

        }
    }

    
}


