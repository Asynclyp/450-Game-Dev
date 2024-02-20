using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos;
    public bool creatingSection = false;
    public int secNum;


    void Start()
    {
        zPos = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }   
    }

    IEnumerator GenerateSection()
    {
        Debug.Log("New scene at " + zPos);
        secNum = Random.Range(0, 3);
        Instantiate(section[secNum], new Vector3(0,0, zPos), Quaternion.identity);
        zPos += 50; 
        yield return new WaitForSeconds(10);
        creatingSection = false;
    }
}
