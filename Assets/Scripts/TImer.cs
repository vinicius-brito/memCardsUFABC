using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TImer : MonoBehaviour
{
    [SerializeField] private GameObject vocePerdeu;
    [SerializeField] private GameObject vocePerdeu1;
    [SerializeField] private GameObject vocePerdeu2;
    public GameObject score1;
    public bool placar;
    public float currentTime = 0f;
    public float currentTime1 = 0f;
    public float currentTime2 = 0f;
    public float startingTime = 50f;
    public GameObject jogador;
    public bool timerAux = true;

    [SerializeField] TextMesh countdownText;
    [SerializeField] TextMesh countdownText1;
    [SerializeField] TextMesh countdownText2;


    void Start()
    {
        currentTime = startingTime;
        currentTime1 = startingTime;
        currentTime2 = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        placar = score1.GetComponent<SceneController>().scoreAux;
        if(score1.GetComponent<SceneController>().modoJogo){
            if(placar)
            {
                countdownText.text = "Timer: " + currentTime.ToString("0");
            }
            else{
                currentTime -= 1 * Time.deltaTime;
                countdownText.text = "Timer: " + currentTime.ToString("0");
            }
        }
        else{
            if(score1.GetComponent<SceneController>().scoreWin == false){
                currentTime1 = currentTime1 + 0;
                currentTime2 = currentTime2 + 0;
            }
            else{
            if(score1.GetComponent<SceneController>().player){
                currentTime1 -= 1 * Time.deltaTime;
                countdownText1.text = "Timer 1: " + currentTime1.ToString("0");
            }
            else
            {
                currentTime2 -= 1 * Time.deltaTime;
                countdownText2.text = "Timer 2: " + currentTime2.ToString("0");
            }
        }
        }
        
        if(currentTime1 <= 0){
            currentTime1 = 0;
            currentTime2 = currentTime2 + 0;
            if(timerAux){
                vocePerdeu1.SetActive(true);
                timerAux = false;
            }
        }
        
        
        if(currentTime2 <= 0){
            currentTime2 = 0;
            currentTime1 = currentTime1 + 0;
            if(timerAux){
                vocePerdeu2.SetActive(true);
                timerAux = false;
            }
            
        }
        
        if(score1.GetComponent<SceneController>().modoJogo){
            if(currentTime <= 0 ){
                currentTime = 0;
                vocePerdeu.SetActive(true);
                SceneController.pontos0[0] =  score1.GetComponent<SceneController>()._score;
        }
        }
      
        
    }
}
