using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //Acessa a biblíoteca do Unity que permite alterar coisas no UI/Canvas

public class GameController : MonoBehaviour
{
    public int totalScore;                 //Variável que se refere ao total de pontos que o jogador tem
    public Text scoreText;                 //Variável que se refere ao texto que mostra a pontuação
    public static GameController instance; //Variável estática com o próprio script GameController como valor
    
    void Start()
    {
        instance = this;  //código usado para poder rodar esse script ao acessa-ló em outro script/arquivo
    }
    public void UpdateScoreText() //Atualiza o valor do texto mostrado na tela/GUI
    {
        scoreText.text = totalScore.ToString(); //O texto deste componente é atualizado para exibir o valor da variável "totalScore", que é convertido em uma string usando o método "ToString()"
    }
    
}
