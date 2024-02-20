using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
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
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("We hit an obstacle");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
