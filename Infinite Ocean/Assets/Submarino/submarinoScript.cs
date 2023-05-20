using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class submarinoScript : MonoBehaviour
{

private ADSMANAGER AD;
  [SerializeField]  private SkinManager skinmanger;
      public float moveSpeed = 5f;
    private Rigidbody2D rb;  
    public Text moedaTX;
    public static int moeda;
    public GameObject painel;
  
    
    void Start()
    {
      
      GetComponent<SpriteRenderer>().sprite = skinmanger.GetSelectedSkin().sprite;
      
      if(PlayerPrefs.GetInt("moeda") > 0){
        moeda = PlayerPrefs.GetInt("moeda");
        moedaTX.text = moeda.ToString();
       }
      
      rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
        }
        else
        {
       rb.velocity = new Vector2(0, rb.velocity.y);
        }   
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("pedra")){
       SoundController.current.PlayMusic(SoundController.current.explodir);

      GetComponent<SpriteRenderer>().color = new Color(1.0f,0.25f,0.25f,0.25f);
      Invoke("DestroyObject", 0.95f);
       Invoke("Perder",1.2f);
      Tempo.StopProfundidade = true;
      }
       if(other.gameObject.CompareTag("bomb")){
        SoundController.current.PlayMusic(SoundController.current.explodir);
        GetComponent<SpriteRenderer>().color = new Color(1.0f,0.25f,0.25f,0.25f);
         Destroy(other.gameObject);
         
        Invoke("DestroyObject", 0.95f);  
        Invoke("Perder",1.2f);
        Tempo.StopProfundidade = true;
       }
       if(other.gameObject.CompareTag("Moedas")){
        Destroy(other.gameObject);
        SoundController.current.PlayMusic(SoundController.current.coin);
        moeda++;
         moedaTX.text = moeda.ToString();
        PlayerPrefs.SetInt("moeda",moeda);

       }
       if(other.gameObject.CompareTag("tubarao")){
        SoundController.current.PlayMusic(SoundController.current.explodir);
        GetComponent<SpriteRenderer>().color = new Color(1.0f,0.25f,0.25f,0.25f);
        Invoke("DestroyObject",0.9f);
        Invoke("Perder", 1.2f);
        Tempo.StopProfundidade = true; 
       }
}
public void DestroyObject(){
  gameObject.SetActive(false);
  
  
}
 public  void Perder(){
     painel.SetActive(true);

   }
   public void VoltaMenu(){
  
    SceneManager.LoadScene(0);
     SoundController.current.PlayMusic(SoundController.current.button);

   }
   public void Reiniciar(){
    if(moeda >= 60){
      SoundController.current.PlayMusic(SoundController.current.button);
      moeda = moeda - 60;
       PlayerPrefs.SetInt("moeda", moeda);
        moedaTX.text = moeda.ToString();

      Tempo.StopProfundidade = false; 
      painel.SetActive(false);
      gameObject.SetActive(true);
      GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
    }
   }
 
   
}
