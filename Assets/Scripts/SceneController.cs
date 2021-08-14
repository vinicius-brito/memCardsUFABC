using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 4;
    public const int gridCols = 4;
    public const float offsetX = 3.5f;
    public const float offsetY = 2.2f;
    public bool scoreAux;
    public float time1;
    public float time2;
    public int scoreAux1 = 0;
    public static int[] pontos0 = new int[25];
    public bool modoJogo = true;
    public bool player = true;
    public int ScorePlayer1;
    public int ScorePlayer2;
    public bool scoreWin = true;
    


    [SerializeField] private MainCard originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private GameObject voceGanhou;
    [SerializeField] private GameObject voceGanhou1;
    [SerializeField] private GameObject voceGanhou2;
    [SerializeField] private GameObject empate;
    [SerializeField] private GameObject Jogando2;
    [SerializeField] private GameObject Jogando1;
    [SerializeField] private TextMesh scoreLabel;
    [SerializeField] private TextMesh scoreLabel1;
    [SerializeField] private TextMesh scoreLabel2;
    [SerializeField] private GameObject timerLabel1;
    [SerializeField] private GameObject timerLabel2;
    [SerializeField] private GameObject scoreBlock;
    [SerializeField] private GameObject timerBlock;
    
    public string nomeDaCenaAtual;
    
    private MainCard _firstRevealed;
    private MainCard _secondRevealed;

    public int _score = 0;

    public GameObject Timer;
    public float timer;

    private void Start()
    {
        if(modoJogo){
           Jogando1.SetActive(false);
           Jogando2.SetActive(false);
           timerLabel1.SetActive(false);
           timerLabel2.SetActive(false);
        }
        else{
            scoreBlock.SetActive(false);
            timerBlock.SetActive(false);
            timerLabel1.GetComponent<SpriteRenderer>().color = new Color(255,0,0,255);
            timerLabel2.GetComponent<SpriteRenderer>().color = new Color(0,0,0,255);
            Jogando1.GetComponent<SpriteRenderer>().color = new Color(255,0,0,255);
            Jogando2.GetComponent<SpriteRenderer>().color = new Color(0,0,0,255);
        }
        nomeDaCenaAtual = SceneManager.GetActiveScene().name;
        
        Vector3 startPos = originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7};
        numbers = ShuffleArray(numbers);
        for(int i = 0; i < gridCols; i++)
        {
            for(int j = 0; j < gridRows; j++)
            {
                MainCard card;
                if(i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MainCard;
                }
                int index = j * gridCols + i;
                int id = numbers[index];
                card.ChangeSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    //------------------

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(MainCard card)
    {
        if(_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    public void Update()
    {
        if(modoJogo){
        if(nomeDaCenaAtual == "Level 1"){
            Rankings.auxiliar = 1;
        }
        if(nomeDaCenaAtual == "Level 2"){
            Rankings.auxiliar = 2;
        }
        if(nomeDaCenaAtual == "Level 3"){
            Rankings.auxiliar = 3;
        }
        if(nomeDaCenaAtual == "Level 4"){
            Rankings.auxiliar = 4;
        }
        if(nomeDaCenaAtual == "Level 5"){
            Rankings.auxiliar = 5;
        }
        if(scoreAux1 == 8){
                
                if(nomeDaCenaAtual == "Level 1")
                {
                    
                    
                    if(_score > pontos0[0])
                    {
                        pontos0[4] = pontos0[3];
                        pontos0[3] = pontos0[2];
                        pontos0[2] = pontos0[1];
                        pontos0[1] = pontos0[0];
                        pontos0[0] = _score;
                        Rankings.valor[0] = pontos0[0];
                        Rankings.valor[1] = pontos0[1];
                        Rankings.valor[2] = pontos0[2];
                        Rankings.valor[3] = pontos0[3];
                        Rankings.valor[4] = pontos0[4];
                        
                    }
                    else
                    {
                        if(_score > pontos0[1] && _score < pontos0[0])
                        {
                            pontos0[4] = pontos0[3];
                            pontos0[3] = pontos0[2];
                            pontos0[2] = pontos0[1];
                            pontos0[1] = _score;
                            Rankings.valor[1] = pontos0[1];
                            Rankings.valor[2] = pontos0[2];
                            Rankings.valor[3] = pontos0[3];
                            Rankings.valor[4] = pontos0[4];
                            

                        }
                        else
                        {
                            if(_score > pontos0[2] && _score < pontos0[0] && _score < pontos0[1] )
                            {
                                pontos0[4] = pontos0[3];
                                pontos0[3] = pontos0[2];
                                pontos0[2] = _score;
                                Rankings.valor[2] = pontos0[2];
                                Rankings.valor[3] = pontos0[3];
                                Rankings.valor[4] = pontos0[4];
                            }
                            else
                            {
                                if(_score > pontos0[3] && _score < pontos0[0] && _score < pontos0[1] && _score < pontos0[2])
                                {
                                    pontos0[4] = pontos0[3];
                                    pontos0[3] = _score;
                                    Rankings.valor[3] = pontos0[3];
                                    Rankings.valor[4] = pontos0[4];
                                }
                                else
                                {
                                    if(_score > pontos0[4] && _score < pontos0[0] && _score < pontos0[1] && _score < pontos0[2] && _score < pontos0[3])
                                    {
                                        pontos0[4] = _score;
                                        Rankings.valor[4] = pontos0[4];
                                    }

                                }
                            }
                        }
                    }
                    
                }//1

                if(nomeDaCenaAtual == "Level 2")
                {
                    Rankings.auxiliar = 2;
                    
                    if(_score > pontos0[5])
                    {
                        pontos0[9] = pontos0[8];
                        pontos0[8] = pontos0[7];
                        pontos0[7] = pontos0[6];
                        pontos0[6] = pontos0[5];
                        pontos0[5] = _score;
                        Rankings.valor[5] = pontos0[5];
                        Rankings.valor[6] = pontos0[6];
                        Rankings.valor[7] = pontos0[7];
                        Rankings.valor[8] = pontos0[8];
                        Rankings.valor[9] = pontos0[9];
                        
                    }
                    else
                    {
                        if(_score > pontos0[6] && _score < pontos0[5])
                        {
                            pontos0[9] = pontos0[8];
                            pontos0[8] = pontos0[7];
                            pontos0[7] = pontos0[6];
                            pontos0[6] = _score;
                            Rankings.valor[6] = pontos0[6];
                            Rankings.valor[7] = pontos0[7];
                            Rankings.valor[8] = pontos0[8];
                            Rankings.valor[9] = pontos0[9];
                            

                        }
                        else
                        {
                            if(_score > pontos0[7] && _score < pontos0[5] && _score < pontos0[6] )
                            {
                                pontos0[9] = pontos0[8];
                                pontos0[8] = pontos0[7];
                                pontos0[7] = _score;
                                Rankings.valor[7] = pontos0[7];
                                Rankings.valor[8] = pontos0[8];
                                Rankings.valor[9] = pontos0[9];
                            }
                            else
                            {
                                if(_score > pontos0[8] && _score < pontos0[5] && _score < pontos0[6] && _score < pontos0[7])
                                {
                                    pontos0[9] = pontos0[8];
                                    pontos0[8] = _score;
                                    Rankings.valor[8] = pontos0[8];
                                    Rankings.valor[9] = pontos0[9];
                                }
                                else
                                {
                                    if(_score > pontos0[9] && _score < pontos0[5] && _score < pontos0[6] && _score < pontos0[7] && _score < pontos0[8])
                                    {
                                        pontos0[9] = _score;
                                        Rankings.valor[9] = pontos0[9];
                                    }

                                }
                            }
                        }
                    }
                    
                }//1

                if(nomeDaCenaAtual == "Level 3")
                {
                    Rankings.auxiliar = 3;
                    
                    if(_score > pontos0[10])
                    {
                        pontos0[14] = pontos0[13];
                        pontos0[13] = pontos0[12];
                        pontos0[12] = pontos0[11];
                        pontos0[11] = pontos0[10];
                        pontos0[10] = _score;
                        Rankings.valor[10] = pontos0[10];
                        Rankings.valor[11] = pontos0[11];
                        Rankings.valor[12] = pontos0[12];
                        Rankings.valor[13] = pontos0[13];
                        Rankings.valor[14] = pontos0[14];
                        
                    }
                    else
                    {
                        if(_score > pontos0[11] && _score < pontos0[10])
                        {
                            pontos0[14] = pontos0[13];
                            pontos0[13] = pontos0[12];
                            pontos0[12] = pontos0[11];
                            pontos0[11] = _score;
                            Rankings.valor[11] = pontos0[11];
                            Rankings.valor[12] = pontos0[12];
                            Rankings.valor[13] = pontos0[13];
                            Rankings.valor[14] = pontos0[14];
                            

                        }
                        else
                        {
                            if(_score > pontos0[12] && _score < pontos0[10] && _score < pontos0[11] )
                            {   
                                pontos0[14] = pontos0[13];
                                pontos0[13] = pontos0[12];
                                pontos0[12] = _score;
                                Rankings.valor[12] = pontos0[2];
                                Rankings.valor[13] = pontos0[13];
                                Rankings.valor[14] = pontos0[14];
                            }
                            else
                            {
                                if(_score > pontos0[13] && _score < pontos0[10] && _score < pontos0[11] && _score < pontos0[12])
                                {
                                    pontos0[14] = pontos0[13];
                                    pontos0[13] = _score;
                                    Rankings.valor[13] = pontos0[3];
                                    Rankings.valor[14] = pontos0[14];
                                }
                                else
                                {
                                    if(_score > pontos0[14] && _score < pontos0[10] && _score < pontos0[11] && _score < pontos0[12] && _score < pontos0[13])
                                    {
                                        pontos0[14] = _score;
                                        Rankings.valor[14] = pontos0[4];
                                    }

                                }
                            }
                        }
                    }
                    
                }//1

                if(nomeDaCenaAtual == "Level 4")
                {
                    Rankings.auxiliar = 4;
                    
                    if(_score > pontos0[15])
                    {
                        pontos0[19] = pontos0[18];
                        pontos0[18] = pontos0[17];
                        pontos0[17] = pontos0[16];
                        pontos0[16] = pontos0[15];
                        pontos0[15] = _score;
                        Rankings.valor[15] = pontos0[15];
                        Rankings.valor[16] = pontos0[16];
                        Rankings.valor[17] = pontos0[17];
                        Rankings.valor[18] = pontos0[18];
                        Rankings.valor[19] = pontos0[19];
                        
                    }
                    else
                    {
                        if(_score > pontos0[16] && _score < pontos0[15])
                        {
                            pontos0[19] = pontos0[18];
                            pontos0[18] = pontos0[17];
                            pontos0[17] = pontos0[16];
                            pontos0[16] = _score;
                            Rankings.valor[16] = pontos0[16];
                            Rankings.valor[17] = pontos0[17];
                            Rankings.valor[18] = pontos0[18];
                            Rankings.valor[19] = pontos0[19];
                            

                        }
                        else
                        {
                            if(_score > pontos0[17] && _score < pontos0[15] && _score < pontos0[16] )
                            {
                                pontos0[19] = pontos0[18];
                                pontos0[18] = pontos0[17];
                                pontos0[17] = _score;
                                Rankings.valor[17] = pontos0[17];
                                Rankings.valor[18] = pontos0[18];
                                Rankings.valor[19] = pontos0[19];
                            }
                            else
                            {
                                if(_score > pontos0[18] && _score < pontos0[15] && _score < pontos0[16] && _score < pontos0[17])
                                {
                                    pontos0[19] = pontos0[18];
                                    pontos0[18] = _score;
                                    Rankings.valor[18] = pontos0[18];
                                    Rankings.valor[19] = pontos0[19];
                                }
                                else
                                {
                                    if(_score > pontos0[19] && _score < pontos0[15] && _score < pontos0[16] && _score < pontos0[17] && _score < pontos0[18])
                                    {
                                        pontos0[19] = _score;
                                        Rankings.valor[19] = pontos0[19];
                                    }

                                }
                            }
                        }
                    }
                    
                }//1

                if(nomeDaCenaAtual == "Level 5")
                {
                    Rankings.auxiliar = 5;
                    
                    if(_score > pontos0[20])
                    {
                        pontos0[24] = pontos0[23];
                        pontos0[23] = pontos0[22];
                        pontos0[22] = pontos0[21];
                        pontos0[21] = pontos0[20];
                        pontos0[20] = _score;
                        Rankings.valor[20] = pontos0[20];
                        Rankings.valor[21] = pontos0[21];
                        Rankings.valor[22] = pontos0[22];
                        Rankings.valor[23] = pontos0[23];
                        Rankings.valor[24] = pontos0[24];
                        
                    }
                    else
                    {
                        if(_score > pontos0[21] && _score < pontos0[20])
                        {
                            pontos0[24] = pontos0[23];
                            pontos0[23] = pontos0[22];
                            pontos0[22] = pontos0[21];
                            pontos0[21] = _score;
                            Rankings.valor[21] = pontos0[21];
                            Rankings.valor[22] = pontos0[22];
                            Rankings.valor[23] = pontos0[23];
                            Rankings.valor[24] = pontos0[24];
                            

                        }
                        else
                        {
                            if(_score > pontos0[22] && _score < pontos0[20] && _score < pontos0[21] )
                            {
                                pontos0[24] = pontos0[23];
                                pontos0[23] = pontos0[22];
                                pontos0[22] = _score;
                                Rankings.valor[22] = pontos0[22];
                                Rankings.valor[23] = pontos0[23];
                                Rankings.valor[24] = pontos0[24];
                            }
                            else
                            {
                                if(_score > pontos0[23] && _score < pontos0[20] && _score < pontos0[21] && _score < pontos0[22])
                                {
                                    pontos0[24] = pontos0[23];
                                    pontos0[23] = _score;
                                    Rankings.valor[23] = pontos0[23];
                                    Rankings.valor[24] = pontos0[24];
                                }
                                else
                                {
                                    if(_score > pontos0[24] && _score < pontos0[20] && _score < pontos0[21] && _score < pontos0[22] && _score < pontos0[23])
                                    {
                                        pontos0[24] = _score;
                                        Rankings.valor[24] = pontos0[24];
                                    }

                                }
                            }
                        }
                    }
                    
                }//1


            }
    }
    else{
        if(ScorePlayer1 > 4){
            voceGanhou1.SetActive(true);
            scoreWin = false;
        }
        if(ScorePlayer2 > 4){
            voceGanhou2.SetActive(true);
            scoreWin = false;
        }
        if(ScorePlayer2 == 4 && ScorePlayer1 == 4){
            empate.SetActive(true);
            scoreWin = false;
        }
    }
        timer = Timer.GetComponent<TImer>().currentTime;
    }

    private IEnumerator CheckMatch()
    {
        
        if(_firstRevealed.id == _secondRevealed.id)
        {
            if(modoJogo){
                if(timer > time1)
                {
                    _score = _score + 3;
                    scoreLabel.text = "Score: " + _score;
                    scoreAux1++;
                }
                else{
                    if(timer > time2)
                    {
                        _score = _score + 2;
                        scoreLabel.text = "Score: " + _score;
                        scoreAux1++;
                    }
                    else{
                        _score++;
                        scoreLabel.text = "Score: " + _score;
                        scoreAux1++;
                    }
                }
                if(scoreAux1 == 8){
                    voceGanhou.SetActive(true);
                    scoreAux = true;
                    Themes.scoreTotal = Themes.scoreTotal + _score;
                    //1
                }
            }
            else{
                if(player){
                    ScorePlayer1++;
                    scoreLabel1.text = "Player 1: " + ScorePlayer1;
                }
                else{
                    if(player == false)
                    {
                        ScorePlayer2++;
                        scoreLabel2.text = "Player 2: " + ScorePlayer2;
                    }
                }
            }

        }
        else
        {
            if(modoJogo == false){
            if(player){
                player = false;
                //Jogando1.SetActive(false);
                //Jogando2.SetActive(true);
                timerLabel1.GetComponent<SpriteRenderer>().color = new Color(0,0,0,255);
                timerLabel2.GetComponent<SpriteRenderer>().color = new Color(255,0,0,255);
                Jogando1.GetComponent<SpriteRenderer>().color = new Color(0,0,0,255);
                Jogando2.GetComponent<SpriteRenderer>().color = new Color(255,0,0,255);
            }
            else
            {
                player = true;
                //Jogando2.SetActive(false);
                //Jogando1.SetActive(true);
                timerLabel1.GetComponent<SpriteRenderer>().color = new Color(255,0,0,255);
                timerLabel2.GetComponent<SpriteRenderer>().color = new Color(0,0,0,255);
                Jogando1.GetComponent<SpriteRenderer>().color = new Color(255,0,0,255);
                Jogando2.GetComponent<SpriteRenderer>().color = new Color(0,0,0,255);
            }
            }
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        
        }

        _firstRevealed = null;
        _secondRevealed = null;

    }

    public void Restart()
    {
        SceneManager.LoadScene("JogoPrincipal");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    
}