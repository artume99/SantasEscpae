using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class startGameScript : MonoBehaviour
{
    public void PlayGame()
    {
        AudioManager.Instance.PlaySound(AudioManager.Sounds.ClickButton);
    	GameManager.Instance.StartGame();
    }

    public void OnPointerEnter(BaseEventData eventData)
    {
        AudioManager.Instance.PlaySound(AudioManager.Sounds.HoverButton);
    }
    
}
