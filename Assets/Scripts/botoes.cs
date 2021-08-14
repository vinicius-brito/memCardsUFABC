using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botoes : MonoBehaviour
{
    public GameController gameController;
    public int idBotao;

    // Start is called before the first frame update
    
    void OnMouseDown()
    {
        if (gameController.gamestate == GameState.RESPONDER)
        {
            gameController.StartCoroutine("responder", idBotao);
        }
    }
}
