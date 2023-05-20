using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScipt : MonoBehaviour
{
    
    public MeshRenderer Mr;

 private float speed = 0.2f;
   
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(AnimateTexture());
    }
 IEnumerator AnimateTexture()
    {
        while (true)
        {
           Mr.material.mainTextureOffset -= new Vector2(0, speed * Time.deltaTime);
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
