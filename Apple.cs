using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer sr;           //Vari�vel referente ao Component SpriteRenderer
    private CircleCollider2D circle;     //Vari�vel referente ao Component CircleCollider2D

    public GameObject collected; //Vari�vel referente a quando o item for coletado
    public int Score;  //Vari�vel referente ao score do jogo 
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();        //Fun��o GetComponent usada para obter componentes de SpriteRender anexado no objeto
        circle = GetComponent<CircleCollider2D>();  //Fun��o GetComponent usada para obter componentes de CircleCollider2D anexado no objeto

    }

    

    void OnTriggerEnter2D(Collider2D collider)     //Fun��o utilizada quando um Collider2D entra em contato com o Collider2D anexado no objeto
    {
        if(collider.gameObject.tag == "Player")    //Checa se o objeto colidiu com o objeto da layer "Player''
        {
            sr.enabled = false;                     //Torna false os componentes de SpriteRender anexados ao objeto (desliga)
            circle.enabled = false;                 //Torna false os componentes de CircleCollider2D anexados ao objeto (desliga)
            collected.SetActive(true);              // Ativa a anima��o de coleta do objeto

            GameController.instance.totalScore += Score;  //A var�avel no script 'GameController' ser� somada com a var�avel 'Score'
            GameController.instance.UpdateScoreText();    //Ao pegar uma ma�a, atualiza o Score do Texto no Script "GameController"

            Destroy(gameObject, 0.3f);              //Destroy o objeto ap�s 0,3segundos de o item ser coletado. 
        }
    }
}
