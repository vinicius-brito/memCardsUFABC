using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Themes : MonoBehaviour
{

    [SerializeField] private GameObject Theme1;
    [SerializeField] private GameObject Theme2;
    [SerializeField] private GameObject Theme3;
    public static int scoreTotal = 0;
    [SerializeField] private GameObject TemaNãoDesbloqueado;
    
    

    public int thema = 1;

    public void Start(){
    
    }
    

    public void theme1()
    {
        Theme1.SetActive(true);
        Theme2.SetActive(false);
        Theme3.SetActive(false);
        
    }

    public void theme2()
    {
        if(scoreTotal > 30){
            Theme2.SetActive(true);
            Theme1.SetActive(false);
            Theme3.SetActive(false);

        }
        else{
            TemaNãoDesbloqueado.SetActive(true);
            Invoke("Voltar", 2);
        }
        
    }

    public void Voltar(){
        TemaNãoDesbloqueado.SetActive(false);
    }

    public void theme3()
    {
        if(scoreTotal > 80){
            Theme3.SetActive(true);
            Theme2.SetActive(false);
            Theme1.SetActive(false);

        }
        else{
            TemaNãoDesbloqueado.SetActive(true);
            Invoke("Voltar", 2);

        }
        
    }
    public void Update()
    {
        
        if(Theme1.activeSelf){
            thema = 1;
        }
        else
        {
            if(Theme2.activeSelf)
            {
                thema = 2;
            }
            else{
                if(Theme3.activeSelf)
                {
                    thema = 3;
                }

            }
        }
        PassaValor.aux = thema;
        
    }
    

    
    }
