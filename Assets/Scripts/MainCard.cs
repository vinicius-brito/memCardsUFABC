using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard : MonoBehaviour
{
    [SerializeField] private SceneController controller;
    [SerializeField] private GameObject Card_Back;
    [SerializeField] private GameObject Timer;
    [SerializeField] private GameObject ModoJogo;
    public float teste;
    public float teste1;
    public float teste2;
    private AudioSource fonteAudio;
    public AudioClip[] sons;

    public void OnMouseDown()
    {
       fonteAudio = GetComponent<AudioSource>();
       teste = Timer.GetComponent<TImer>().currentTime;
       teste1 = Timer.GetComponent<TImer>().currentTime1;
       teste2 = Timer.GetComponent<TImer>().currentTime2;

       if(ModoJogo.GetComponent<SceneController>().modoJogo){
           if(teste > 0){
                if(Card_Back.activeSelf && controller.canReveal)
                {
                    fonteAudio.PlayOneShot(sons[0]);
                    Card_Back.SetActive(false);
                    controller.CardRevealed(this);
                }
        }

       }
       else
       {
           if(teste1 > 0){
               if(teste2 > 0){
                   if(ModoJogo.GetComponent<SceneController>().scoreWin){

               
               if(Card_Back.activeSelf && controller.canReveal)
                {
                    fonteAudio.PlayOneShot(sons[0]);
                    Card_Back.SetActive(false);
                    controller.CardRevealed(this);
                }

           }
           }
       }
       }
       
    }

    private int _id;
    public int id
    {
        get { return _id; }

    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
    
    public void Unreveal()
    {
        Card_Back.SetActive(true);
    }

    
}
