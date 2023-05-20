using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRandom : MonoBehaviour
{
  public GameObject Monstros;
public float tempospawn;
public Transform[] spawnrandom;

//metodo estar com IEnumerator
private IEnumerator Start() 
{
    //loop infinito
    while (true)
    {
        //esperar x tempo
        yield return new WaitForSeconds(tempospawn);
        int pontospawnindex = Random.Range(0, spawnrandom.Length);
        Instantiate(Monstros, spawnrandom[pontospawnindex].position, spawnrandom[pontospawnindex].rotation);
    }
}
}
