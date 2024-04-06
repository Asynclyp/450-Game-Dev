using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subway : MonoBehaviour
{
    public float rotationSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
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
