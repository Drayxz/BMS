using UnityEngine;

public class ballControl : MonoBehaviour
{
    [SerializeField]
    private GameObject ball_prefab; //gets the prefab of the ball

    private GameObject ball; //spawners internal ball object to keep track of
    private bool spawned; //true if ball is spawned

    private void Start()
    {
        Spawn();
    }

    void Update()
    {
        if (!spawned)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        if (spawned)
        {
            Despawn();
        }
        ball = Instantiate(ball_prefab) as GameObject;
        ball.transform.parent = transform;
        spawned = true;
    }

    public void Despawn()
    {
        Destroy(ball);
        spawned = false;
    }
}