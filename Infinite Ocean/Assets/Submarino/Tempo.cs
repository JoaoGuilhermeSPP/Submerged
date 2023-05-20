using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tempo : MonoBehaviour
{
   
   public Text txtRecordeAtual;
      public Text textoTempo;
      public static float Profundidade;
     public static bool StopProfundidade;

    void Start()
    {
   Profundidade = 0f;
        StopProfundidade = false;
        if(Profundidade >=200f){
        scriptPedra.speed = 15f;
        ScriptBomb.speed = 15f;
        ScriptTubarao.speed = 25f;
        
        }
       else if(Profundidade >= 100f){
        scriptPedra.speed = 10f;
        ScriptBomb.speed = 10f;
        ScriptTubarao.speed = 15f;
        
       }
       else if(Profundidade >= 60f){
          scriptPedra.speed = 8f;
        ScriptBomb.speed = 8f;
        ScriptTubarao.speed = 10f;
       }
       else if(Profundidade >=30f){
          scriptPedra.speed = 6f;
        ScriptBomb.speed = 6f;
        ScriptTubarao.speed = 8f;
        
       }
    }

    void Update()
    {
        if(StopProfundidade == false){
     Profundidade = Profundidade + Time.deltaTime;
     textoTempo.text = Profundidade.ToString("F2") + "m";
    PlayerPrefs.SetFloat("time", Profundidade);
        }
    if(StopProfundidade == true){
      PlayerPrefs.SetFloat("time", Profundidade);
       txtRecordeAtual.text = Profundidade.ToString("F2") + "m";
    }  
    if(Profundidade > PlayerPrefs.GetFloat("timeR")){
      PlayerPrefs.SetFloat("timeR", Profundidade);
    }
    }
   
}
