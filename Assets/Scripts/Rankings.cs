using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rankings : MonoBehaviour
{
    public static int[] valor = new int[24];
    public static int auxiliar;
    [SerializeField] private TextMesh scoreLabel0;
    [SerializeField] private TextMesh scoreLabel1;
    [SerializeField] private TextMesh scoreLabel2;
    [SerializeField] private TextMesh scoreLabel3;
    [SerializeField] private TextMesh scoreLabel4;
    [SerializeField] private TextMesh Level;


    void Update()
    {
        if(auxiliar == 1){
            Level.text = "Level: " + 1;
            scoreLabel0.text = "1º " + valor[0] + " pontos";
            scoreLabel1.text = "2º " + valor[1] + " pontos";
            scoreLabel2.text = "3º " + valor[2] + " pontos";
            scoreLabel3.text = "4º " + valor[3] + " pontos";
            scoreLabel4.text = "5º " + valor[4] + " pontos";
        }
        if(auxiliar == 2){
            Level.text = "Level: " + 2;
            scoreLabel0.text = "1º " + valor[5] + " pontos";
            scoreLabel1.text = "2º " + valor[6] + " pontos";
            scoreLabel2.text = "3º " + valor[7] + " pontos";
            scoreLabel3.text = "4º " + valor[8] + " pontos";
            scoreLabel4.text = "5º " + valor[9] + " pontos";
        }
        if(auxiliar == 3){
            Level.text = "Level: " + 3;
            scoreLabel0.text = "1º " + valor[10] + " pontos";
            scoreLabel1.text = "2º " + valor[11] + " pontos";
            scoreLabel2.text = "3º " + valor[12] + " pontos";
            scoreLabel3.text = "4º " + valor[13] + " pontos";
            scoreLabel4.text = "5º " + valor[14] + " pontos";
        }
        if(auxiliar == 4){
            Level.text = "Level: " + 4;
            scoreLabel0.text = "1º " + valor[15] + " pontos";
            scoreLabel1.text = "2º " + valor[16] + " pontos";
            scoreLabel2.text = "3º " + valor[17] + " pontos";
            scoreLabel3.text = "4º " + valor[18] + " pontos";
            scoreLabel4.text = "5º " + valor[19] + " pontos";
        }
        if(auxiliar == 5){
            Level.text = "Level: " + 5;
            scoreLabel0.text = "1º " + valor[20] + " pontos";
            scoreLabel1.text = "2º " + valor[21] + " pontos";
            scoreLabel2.text = "3º " + valor[22] + " pontos";
            scoreLabel3.text = "4º " + valor[23] + " pontos";
            scoreLabel4.text = "5º " + valor[24] + " pontos";
        }
        
        
    }

    public void changeScene1(){
        Invoke("changeScene", 0.2f);
    }

    public void changeScene(){
        if(auxiliar == 1){
            SceneManager.LoadScene("Level 1");
        }
        if(auxiliar == 2){
            SceneManager.LoadScene("Level 2");
        }
        if(auxiliar == 3){
            SceneManager.LoadScene("Level 3");
        }
        if(auxiliar == 4){
            SceneManager.LoadScene("Level 4");
        }
        if(auxiliar == 5){
            SceneManager.LoadScene("Level 5");
        }
    }
}
