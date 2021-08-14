using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public enum GameState
{
    SEQUENCIA,
    RESPONDER,
    NOVA,
    ERRO
}


public class GameController : MonoBehaviour
{
    public GameState gamestate;

    [SerializeField] public TextMesh rodadaTxt, qtdCardsTxt;

    public Color[] cor;
    public Image[] botoes;
    public GameObject startButton;

    public List<int> cores;
    public int idResposta, qtdCards, rodada;

    private AudioSource fonteAudio;
    public AudioClip[] sons;

    public int _score = 0;
    public int _scoreAntigo = 0;

    [SerializeField] private TextMesh scoreLabel;

    public string nomeDaCenaAtual;

    void Start()
    {
        nomeDaCenaAtual = SceneManager.GetActiveScene().name;
        fonteAudio = GetComponent<AudioSource>();
        novaRodada();
    }

    public void StartGame()
    {
        StartCoroutine("sequencia", qtdCards + rodada);
    }

    public void novaRodada()
    {
        foreach (Image img in botoes)
        {
            img.color = cor[0];
        }

        if (nomeDaCenaAtual == "Sequencial 3" || nomeDaCenaAtual == "Sequencial 4" || nomeDaCenaAtual == "Sequencial 5")
        {
            cores.Clear();
        }

        startButton.SetActive(true);
        scoreLabel.text = "Score: " + _score;
        rodadaTxt.text = "Rodada: " + (rodada + 1).ToString();
        qtdCardsTxt.text = "Sequ�ncia: " + (qtdCards + rodada).ToString();
    }

    IEnumerator sequencia(int qtd)
    {
        startButton.SetActive(false);

        if  (nomeDaCenaAtual == "Sequencial 1" || nomeDaCenaAtual == "Sequencial 2")
        {
            if (qtd == 3)
            {
                for (int r = qtd; r > 0; r--)
                {
                    yield return new WaitForSeconds(0.5f);
                    int i = Random.Range(0, botoes.Length);
                    botoes[i].color = cor[1];
                    fonteAudio.PlayOneShot(sons[i]);

                    cores.Add(i);

                    yield return new WaitForSeconds(0.5f);
                    botoes[i].color = cor[0];

                }
            }
            else
            {
                int i = Random.Range(0, botoes.Length);
                cores.Add(i);
                for (int r = 0; r < qtd; r++)
                {
                    int y = cores[r];
                    yield return new WaitForSeconds(0.5f);

                    botoes[y].color = cor[1];
                    fonteAudio.PlayOneShot(sons[y]);

                    yield return new WaitForSeconds(0.5f);
                    botoes[y].color = cor[0];
                }
            }
        } else
        {
            for (int r = qtd; r > 0; r--)
            {
                yield return new WaitForSeconds(0.5f);
                int i = Random.Range(0, botoes.Length);
                botoes[i].color = cor[1];
                fonteAudio.PlayOneShot(sons[i]);

                cores.Add(i);

                yield return new WaitForSeconds(0.5f);
                botoes[i].color = cor[0];

            }
        }


           

        gamestate = GameState.RESPONDER;
        idResposta = 0;
    }

    IEnumerator responder(int idBotao)
    {

        botoes[idBotao].color = cor[1];

        if(cores[idResposta] == idBotao)
        {
            fonteAudio.PlayOneShot(sons[idBotao]);
        }
        else
        {
            gamestate = GameState.ERRO;
            rodada = 0;
            StartCoroutine("GameOver");
            cores.Clear();
        }

        idResposta += 1;

        if(idResposta == cores.Count)
        {
            gamestate = GameState.NOVA;
            _scoreAntigo = _score;
            _score = _score + qtdCards + rodada;
            Themes.scoreTotal = Themes.scoreTotal + _score - _scoreAntigo;

            rodada += 1;
            yield return new WaitForSeconds(1);
            novaRodada();
        }

        yield return new WaitForSeconds(0.3f);
        botoes[idBotao].color = cor[0];

    }

    IEnumerator GameOver()
    {
        rodada = 0;
        fonteAudio.PlayOneShot(sons[8]);
        yield return new WaitForSeconds(1);

        for (int i = 3; i > 0; i--)
        {

            foreach (Image img in botoes)
            {
                img.color = cor[1];
            }

            yield return new WaitForSeconds(0.3f);

            foreach (Image img in botoes)
            {
                img.color = cor[0];
            }

            yield return new WaitForSeconds(0.3f);

        }
        int idB = 0;
        for(int i = 16; i > 0; i--)
        {
            botoes[idB].color = cor[1];
            yield return new WaitForSeconds(0.1f); 
            botoes[idB].color = cor[0];

            idB += 1; if (idB == 8) { idB = 0; }

        }

        gamestate = GameState.NOVA;
        novaRodada();
    }

}
