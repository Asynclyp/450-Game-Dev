using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    public float rotationSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("We step on a trap");
            CollectableControl.coinCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
