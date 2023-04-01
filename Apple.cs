using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer sr;           //Variável referente ao Component SpriteRenderer
    private CircleCollider2D circle;     //Variável referente ao Component CircleCollider2D

    public GameObject collected; //Variável referente a quando o item for coletado
    public int Score;  //Variável referente ao score do jogo 
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();        //Função GetComponent usada para obter componentes de SpriteRender anexado no objeto
        circle = GetComponent<CircleCollider2D>();  //Função GetComponent usada para obter componentes de CircleCollider2D anexado no objeto

    }

    

    void OnTriggerEnter2D(Collider2D collider)     //Função utilizada quando um Collider2D entra em contato com o Collider2D anexado no objeto
    {
        if(collider.gameObject.tag == "Player")    //Checa se o objeto colidiu com o objeto da layer "Player''
        {
            sr.enabled = false;                     //Torna false os componentes de SpriteRender anexados ao objeto (desliga)
            circle.enabled = false;                 //Torna false os componentes de CircleCollider2D anexados ao objeto (desliga)
            collected.SetActive(true);              // Ativa a animação de coleta do objeto

            GameController.instance.totalScore += Score;  //A varíavel no script 'GameController' será somada com a varíavel 'Score'
            GameController.instance.UpdateScoreText();    //Ao pegar uma maça, atualiza o Score do Texto no Script "GameController"

            Destroy(gameObject, 0.3f);              //Destroy o objeto após 0,3segundos de o item ser coletado. 
        }
    }
}
