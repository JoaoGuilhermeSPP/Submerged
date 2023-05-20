using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPedra : MonoBehaviour
{
    private Camera cam; 
    [SerializeField]
    public static float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y > cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y)
        {
            Destroy(gameObject);
        }
    }
}
