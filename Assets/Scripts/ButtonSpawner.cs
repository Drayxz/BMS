using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    public GameObject ball;
    public float xpos = 0;
    public float ypos = 0;
    public float zpos = 0;
    private bool ballExist = false;

    void Start()
    {
       
    }

    public void SpawnBall()
    {
        Instantiate(ball, new Vector3(xpos, ypos, zpos), Quaternion.identity);
    }
    public void DespawnBall()
    {
        Destroy(GameObject.FindWithTag("ball"));
    }
}
