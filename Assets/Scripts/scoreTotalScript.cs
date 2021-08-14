using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreTotalScript : MonoBehaviour
{
    
    [SerializeField] private TextMesh scoreTotal1;
    public int pontuação;
    public static int scoreTotal = 0;


    // Update is called once per frame
    void Update()
    {
        
        pontuação = Themes.scoreTotal;
        print(pontuação);
        scoreTotal1.text = "Pontuação geral: " + pontuação;
        
    }
}
