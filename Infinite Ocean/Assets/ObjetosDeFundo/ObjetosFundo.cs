using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosFundo : MonoBehaviour
{
    public float moveSpeed;
      public float patrolDistance = 5f;
     
     public static float speed = 2f;
      private int moveDirection = 1;
     private Vector2 startingPosition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = transform.position + new Vector3(moveDirection * moveSpeed * Time.deltaTime, 0, 0);
        if (Mathf.Abs(transform.position.x - startingPosition.x) > patrolDistance)
        {
        moveDirection *= -1;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        } 
    }
}
