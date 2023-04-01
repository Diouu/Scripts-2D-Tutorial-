using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float Speed;         //Vari�vel velocidade
    public float JumpForce;     //Vari�vel for�a do pulo
    public bool isJumping;      //Vari�vel booleana para saber se o Jogador est� ou n�o pulando
    public bool doubleJump;     //Vari�vel booleana para saber se o doubleJump � true ou false


    private Rigidbody2D rig;   //Vari�vel que se refere ao componente Rigidbody2D (Gravidade)
    private Animator anim;     //Vari�vel que se refere ao componente de anima��o
    
    void Start()         //O que roda antes do primeiro frame 
    {
        rig = GetComponent<Rigidbody2D>();  //Vari�vel recebendo o locat�rio do componente
        anim = GetComponent<Animator>();    //Vari�vel recebendo o locat�rio do componente
    }

    
    void Update()      //O que roda a cada frame
    {
        Move();          //Rodando o 'void Move()' dentro do void Update
        Jump();          //Rodando o 'void Jump()' dentro do void Update
    }

    void Move()  //Movimenta��o
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);  //Cria um vetor chamado "movement" que recebe 3 parametros (x,y,z) o x se refere a horizontal.
        transform.position += movement * Time.deltaTime * Speed;              //Esse c�digo atualiza a posi��o do objeto. Esse c�digo permite mover para esquerda ou direta.
        
        if(Input.GetAxis("Horizontal") > 0f )                                 //Se a tecla para direita est� pressionada 
        {
            anim.SetBool("walk", true);                                       //Seta anima��o de "walk" como true
            transform.eulerAngles = new Vector3(0f,0f,0f);                    //define a rota��o do objeto para a dire��o correta usando a fun��o "transform.eulerAngles"
        }

        if (Input.GetAxis("Horizontal") < 0f)                                 //Se a tecla para esquerda est� pressionada
        {
            anim.SetBool("walk", true);                                       //Seta anima��o de "walk" como true
            transform.eulerAngles = new Vector3(0f, 180f, 0f);                //define a rota��o do objeto com 180 graus para que o sprite seja espelhado horizontalmente na dire��o oposta.
        }

        if (Input.GetAxis("Horizontal") == 0f)                                //Se nenhuma tecla de dire��o estiver sendo pressionada
        {
            anim.SetBool("walk", false);                                      //seta anima��o de "walk" como false
            
        }
    }
    
    void Jump()        //� o pulo
    {
        if (Input.GetButtonDown("Jump"))                                      //Se a tecla de pulo for pressionada
        {
            if (!isJumping)                     //Verifica se o isJumping � falso (jogador n�o est� pulando)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);      //Impulsiona o jogador para cima usando a fun��o "rig.AddForce" e um novo vetor que representa a for�a do pulo 
                doubleJump = true;             //Define doubleJump como true
                anim.SetBool("jump", true);    //Seta anima��o de pulo como true
            }
            else                               //Verifica se o isJumping � verdadeiro (jogador est� pulando)
            {                                 
                if (doubleJump)                //Verifica se o jogador consegue fazer um doubleJump
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);   //Impulsiona o jogador para cima novamente
;               doubleJump = false;            //Seta a vari�vel bool doubleJump como falsa para que n�o seja poss�vel o terceiro pulo
                } 
                
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) //Essa fun��o � chamada quando o jogador colide com outro objeto que tenha um Collision2D anexado
    {
        if(collision.gameObject.layer == 8)        //Verifica se o jogador est� colidindo com o layer 8 (o layer que se refere ao ch�o)
        {
            isJumping = false;                     //isJumping definida como falsa
            anim.SetBool("jump", false);           //Anima��o de pulo definida como falsa (Interromper anima��o de pulo)
        }
    }

    void OnCollisionExit2D(Collision2D collision) //Essa fun��o � chamada quando o jogador sai de uma colis�o com outro objeto que tenha um Collision2D anexado
    {
        if(collision.gameObject.layer == 8)       //Verifica se o jogador est� colidindo com o layer 8 (o layer que se refere ao ch�o)
        {
            isJumping = true;                     //isJumping definida como true (poder� pular novamente)
        }
    }



}
