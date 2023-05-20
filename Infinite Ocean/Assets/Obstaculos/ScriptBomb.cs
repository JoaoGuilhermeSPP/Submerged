using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBomb : MonoBehaviour
{
    public Animator anim;
     public float patrolDistance = 5f;
     public float moveSpeed;
     [SerializeField]
     public static float speed = 2f;
    private Camera cam;

    private int moveDirection = 1;
     private Vector2 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
          cam = Camera.main;
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
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y > cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y)
        {
            Destroy(gameObject);
        }
    }
  
}
