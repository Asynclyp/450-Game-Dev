using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    public static int coinCount;
    public static int highestScore = 0;
    public GameObject coinCountDisplay;
    public GameObject highestScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        highestScoreDisplay.GetComponent<Text>().text = "" + highestScore;
    }

    // Update is called once per frame
    void Update()
    {
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
    }
}
