using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }
    public void EnemyMovement()
    {
        Vector3 targetPosition = new Vector3(playerPos.transform.position.x, transform.position.y, playerPos.transform.position.z);
        transform.LookAt(targetPosition);

    }
}
