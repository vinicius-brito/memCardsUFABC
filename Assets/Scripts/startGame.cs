using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    public GameController GameController;

    // Start is called before the first frame update
    void OnMouseDown()
    {
        GameController.StartGame();
    }
}
