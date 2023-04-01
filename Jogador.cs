using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float Speed;         //Variável velocidade
    public float JumpForce;     //Variável força do pulo
    public bool isJumping;      //Variável booleana para saber se o Jogador está ou não pulando
    public bool doubleJump;     //Variável booleana para saber se o doubleJump é true ou false


    private Rigidbody2D rig;   //Variável que se refere ao componente Rigidbody2D (Gravidade)
    private Animator anim;     //Variável que se refere ao componente de animação
    
    void Start()         //O que roda antes do primeiro frame 
    {
        rig = GetComponent<Rigidbody2D>();  //Variável recebendo o locatório do componente
        anim = GetComponent<Animator>();    //Variável recebendo o locatório do componente
    }

    
    void Update()      //O que roda a cada frame
    {
        Move();          //Rodando o 'void Move()' dentro do void Update
        Jump();          //Rodando o 'void Jump()' dentro do void Update
    }

    void Move()  //Movimentação
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);  //Cria um vetor chamado "movement" que recebe 3 parametros (x,y,z) o x se refere a horizontal.
        transform.position += movement * Time.deltaTime * Speed;              //Esse código atualiza a posição do objeto. Esse código permite mover para esquerda ou direta.
        
        if(Input.GetAxis("Horizontal") > 0f )                                 //Se a tecla para direita está pressionada 
        {
            anim.SetBool("walk", true);                                       //Seta animação de "walk" como true
            transform.eulerAngles = new Vector3(0f,0f,0f);                    //define a rotação do objeto para a direção correta usando a função "transform.eulerAngles"
        }

        if (Input.GetAxis("Horizontal") < 0f)                                 //Se a tecla para esquerda está pressionada
        {
            anim.SetBool("walk", true);                                       //Seta animação de "walk" como true
            transform.eulerAngles = new Vector3(0f, 180f, 0f);                //define a rotação do objeto com 180 graus para que o sprite seja espelhado horizontalmente na direção oposta.
        }

        if (Input.GetAxis("Horizontal") == 0f)                                //Se nenhuma tecla de direção estiver sendo pressionada
        {
            anim.SetBool("walk", false);                                      //seta animação de "walk" como false
            
        }
    }
    
    void Jump()        //É o pulo
    {
        if (Input.GetButtonDown("Jump"))                                      //Se a tecla de pulo for pressionada
        {
            if (!isJumping)                     //Verifica se o isJumping é falso (jogador não está pulando)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);      //Impulsiona o jogador para cima usando a função "rig.AddForce" e um novo vetor que representa a força do pulo 
                doubleJump = true;             //Define doubleJump como true
                anim.SetBool("jump", true);    //Seta animação de pulo como true
            }
            else                               //Verifica se o isJumping é verdadeiro (jogador está pulando)
            {                                 
                if (doubleJump)                //Verifica se o jogador consegue fazer um doubleJump
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);   //Impulsiona o jogador para cima novamente
;               doubleJump = false;            //Seta a variável bool doubleJump como falsa para que não seja possível o terceiro pulo
                } 
                
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) //Essa função é chamada quando o jogador colide com outro objeto que tenha um Collision2D anexado
    {
        if(collision.gameObject.layer == 8)        //Verifica se o jogador está colidindo com o layer 8 (o layer que se refere ao chão)
        {
            isJumping = false;                     //isJumping definida como falsa
            anim.SetBool("jump", false);           //Animação de pulo definida como falsa (Interromper animação de pulo)
        }
    }

    void OnCollisionExit2D(Collision2D collision) //Essa função é chamada quando o jogador sai de uma colisão com outro objeto que tenha um Collision2D anexado
    {
        if(collision.gameObject.layer == 8)       //Verifica se o jogador está colidindo com o layer 8 (o layer que se refere ao chão)
        {
            isJumping = true;                     //isJumping definida como true (poderá pular novamente)
        }
    }



}
