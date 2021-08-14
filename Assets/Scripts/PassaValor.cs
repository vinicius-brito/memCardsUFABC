using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassaValor : MonoBehaviour
{
    public static int aux;
    [SerializeField] private GameObject Theme1;
    [SerializeField] private GameObject Theme2;
    [SerializeField] private GameObject Theme3;
    void Start()
    {
        if(aux == 1)
        {
            Theme1.SetActive(true);
            Theme2.SetActive(false);
            Theme3.SetActive(false);
        }
        else{
            if(aux == 2)
            {
                Theme2.SetActive(true);
                Theme1.SetActive(false);
                Theme3.SetActive(false);
            }
            else
            {
                if(aux == 3)
                {
                    Theme3.SetActive(true);
                    Theme2.SetActive(false);
                    Theme1.SetActive(false);

                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
