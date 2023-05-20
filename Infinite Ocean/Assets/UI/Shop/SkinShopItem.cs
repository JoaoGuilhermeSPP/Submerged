using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinShopItem : MonoBehaviour
{
  [SerializeField] private SkinManager skinManager;
  [SerializeField] private int skinIndex;
  [SerializeField] private Button buyButton;
  [SerializeField] private Text costText;
  private skin skin;

  void Start()
  {
    skin = skinManager.skins[skinIndex];

    GetComponent<Image>().sprite = skin.sprite;

    if (skinManager.IsUnlocked(skinIndex))
    {
      buyButton.gameObject.SetActive(false);
    }
    else
    {
      buyButton.gameObject.SetActive(true);
      costText.text = skin.cost.ToString();
    }
  }

  public void OnSkinPressed()
  {
    if (skinManager.IsUnlocked(skinIndex))
    {
      skinManager.SelectSkin(skinIndex);
    }
                SoundController.current.PlayMusic(SoundController.current.button);

  }

  public void OnBuyButtonPressed()
  {
    int coins = PlayerPrefs.GetInt("moeda", 0);
            SoundController.current.PlayMusic(SoundController.current.button);


    // Unlock the skin
    if (coins >= skin.cost && !skinManager.IsUnlocked(skinIndex))
    {
      PlayerPrefs.SetInt("moeda", submarinoScript.moeda - skin.cost);
      skinManager.Unlock(skinIndex);
      buyButton.gameObject.SetActive(false);
      skinManager.SelectSkin(skinIndex);
    }
    else
    {
      Debug.Log("Not enough coins :(");
    }
  }
}
