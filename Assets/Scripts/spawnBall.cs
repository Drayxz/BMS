using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBall : MonoBehaviour
{
    public GameObject ballprefab;
    public float xpos;
    public float ypos;
    public float zpos;

    public void RespawnBall()
    {
        if (GameObject.FindWithTag("ball"))
        {
            DespawnBall();
        }
        Instantiate(ballprefab, new Vector3(xpos, ypos, zpos), Quaternion.identity);
    }

    public void DespawnBall()
    {
        Destroy(GameObject.FindWithTag("ball"));
    }
}
