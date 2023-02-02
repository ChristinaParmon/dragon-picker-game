using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject dragonEggPrefab;
    public float speed = 5f;
    public float timeBetweenEggDrops = 1f;
    public float leftRightDistance = 30f;
    public float chanceDirections = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropEgg", 2f);
    }
    void DropEgg() // 2
    {
        Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg =
            Instantiate<GameObject>(dragonEggPrefab);
        egg.transform.position = transform.position + myVector;
        Invoke("DropEgg", timeBetweenEggDrops);
       
        timeBetweenEggDrops -= 0.02f;
        if (timeBetweenEggDrops <= 0.2f)
        {
            timeBetweenEggDrops = 0.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position; 
        pos.x += speed * Time.deltaTime; 
        transform.position = pos; 
        if (pos.x < -leftRightDistance) 
        {
            speed = Mathf.Abs(speed);
            speed += 0.5f;
        }
        else if (pos.x > leftRightDistance) 
        {
            speed = -Mathf.Abs(speed);
            speed -= 0.5f;
        }
    }
    
    private void FixedUpdate()
    {
        if (Random.value < chanceDirections)
        {
            speed *= -1;
        }
    }
}
