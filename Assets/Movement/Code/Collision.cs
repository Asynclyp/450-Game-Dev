using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Collision : MonoBehaviour
{
    public PlayerMove mainScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log(this.name + " hits " + collision.gameObject.name);
        //Debug.Log("We hit something");
        //Debug.Log(collision.gameObject.name);
        //Debug.Log(collision.gameObject.tag);

        GameObject collisionObject = collision.gameObject;
        if (collisionObject.CompareTag("Obstacle"))
        {
            
            Debug.Log("We hit an obstacle");
            mainScene.GameOver(CollectableControl.coinCount);
            CollectableControl.coinCount = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
