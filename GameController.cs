using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //Acessa a bibl�oteca do Unity que permite alterar coisas no UI/Canvas

public class GameController : MonoBehaviour
{
    public int totalScore;                 //Vari�vel que se refere ao total de pontos que o jogador tem
    public Text scoreText;                 //Vari�vel que se refere ao texto que mostra a pontua��o
    public static GameController instance; //Vari�vel est�tica com o pr�prio script GameController como valor
    
    void Start()
    {
        instance = this;  //c�digo usado para poder rodar esse script ao acessa-l� em outro script/arquivo
    }
    public void UpdateScoreText() //Atualiza o valor do texto mostrado na tela/GUI
    {
        scoreText.text = totalScore.ToString(); //O texto deste componente � atualizado para exibir o valor da vari�vel "totalScore", que � convertido em uma string usando o m�todo "ToString()"
    }
    
}
