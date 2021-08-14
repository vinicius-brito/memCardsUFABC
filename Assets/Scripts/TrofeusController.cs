using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrofeusController : MonoBehaviour
{
    [SerializeField] private GameObject Trofeu1;
    [SerializeField] private GameObject Trofeu2;
    [SerializeField] private GameObject Trofeu3;
    [SerializeField] private GameObject Trofeu4;
    [SerializeField] private GameObject Trofeu5;
    public int[] valores_minimos;
    void Start()
    {
    	Trofeu1.SetActive(false);
    	Trofeu2.SetActive(false);
    	Trofeu3.SetActive(false);
    	Trofeu4.SetActive(false);
    	Trofeu5.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
       int valorGlobal = Themes.scoreTotal;
       if (valorGlobal >= valores_minimos[0]) Trofeu1.SetActive(true);
       if (valorGlobal >= valores_minimos[1]) Trofeu2.SetActive(true);
       if (valorGlobal >= valores_minimos[2]) Trofeu3.SetActive(true);
       if (valorGlobal >= valores_minimos[3]) Trofeu4.SetActive(true);
       if (valorGlobal >= valores_minimos[4]) Trofeu5.SetActive(true);

    }
}
