using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{


    [SerializeField] private Image selectedSkin;
  [SerializeField] private Text coinsText;
  [SerializeField] private SkinManager skinManager;
    public Text MoedaTXT;
    public Text txtUltimoRecord;
         void Start()
    {
       
       if(PlayerPrefs.GetInt("moeda")> 0){
        submarinoScript.moeda = PlayerPrefs.GetInt("moeda");
        MoedaTXT.text = submarinoScript.moeda.ToString();
       }
        Tempo.Profundidade = PlayerPrefs.GetFloat("time");
      txtUltimoRecord.text = Tempo.Profundidade.ToString("F2") + "m";
    }
 
    private void Update()
    {
    submarinoScript.moeda = PlayerPrefs.GetInt("moeda");
        MoedaTXT.text = submarinoScript.moeda.ToString();
    selectedSkin.sprite = skinManager.GetSelectedSkin().sprite;
    }
 
   public void IniciaModo(GameObject painel){
    painel.SetActive(true);
            SoundController.current.PlayMusic(SoundController.current.button);

   }
   public void FecharModo(GameObject painel){
    painel.SetActive(false);
            SoundController.current.PlayMusic(SoundController.current.button);

   }
   public void IniciarGame(){
    
    SceneManager.LoadScene(1);
            SoundController.current.PlayMusic(SoundController.current.button);

   }
 
}
