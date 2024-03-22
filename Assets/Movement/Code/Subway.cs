using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subway : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            StartCoroutine(JumpPowerUp());
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    IEnumerator JumpPowerUp()
    {
        PlayerMove.jumpPower = 10;
        PlayerMove.jumpDuration = 0.7f;
        yield return new WaitForSeconds(5f);
        PlayerMove.jumpPower = 5;
        PlayerMove.jumpDuration = 0.45f;
        this.gameObject.SetActive(false);
    }
}
