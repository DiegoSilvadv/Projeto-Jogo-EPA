using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonagemPrincipal : MonoBehaviour {
	public float velocidade = 8f;
	private Rigidbody2D body;
	private SpriteRenderer sprite;
	public bool pular;
	public float forcapulo;
	private Animator animacao;
	public static float meutempo;

	public void Jogar() {
		SceneManager.LoadScene ("comeco");
		tempojogo.tempo = 0;
	}

	public void Menu() {
		SceneManager.LoadScene ("TelaInicia");
	}

	public void Credito(){
		SceneManager.LoadScene ("creditos");
	}

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		animacao = GetComponent<Animator> ();

	}


	void OnCollisionEnter2D(Collision2D obj)
	{	//se o personagem colidir com o chao ele pode pular 
		if (obj.gameObject.tag == "chao") 
		{
			pular = true;
		}
		else if (obj.gameObject.tag == "bomba") {
			SceneManager.LoadScene ("TelaInicia");
			tempojogo.tempo = 0;
		}
		else if (obj.gameObject.tag == "chao") 
		{
			pular = false;
		}
		if (obj.gameObject.tag == "portal1") {
			SceneManager.LoadScene ("cena2");
		}
		if (obj.gameObject.tag == "portal2") {
			SceneManager.LoadScene ("cena3");
		}
		if (obj.gameObject.tag == "finalvitoria") {

			meutempo = tempojogo.tempo;
			SceneManager.LoadScene ("cenadevitoria");


		}

		if (obj.gameObject.tag == "perdeu") {
			SceneManager.LoadScene ("telainicia");
		}

	}

	void OnCollisionExit2D(Collision2D obj)
	{	//evitando pulo duplo se o perssonagem sair do chao 
		if (obj.gameObject.tag == "chao") 
		{
			pular = false;
		}
		if (obj.gameObject.tag == "portal1") {
			SceneManager.LoadScene ("cena2");
		}
		if (obj.gameObject.tag == "portal2") {
			SceneManager.LoadScene ("cena3");

		}
		if (obj.gameObject.tag == "bomba") {
			SceneManager.LoadScene ("TelaInicia");
		}



	}

	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space) && pular) 
		{
			body.AddForce (new Vector2 (0, forcapulo));
			pular= false;
		}
		animacao.SetFloat ("velocidadex", Mathf.Abs (body.velocity.x));
		animacao.SetFloat ("velocidadey", body.velocity.y);
		
	}
	void FixedUpdate(){
		//movimentacao do personagem
		float move = Input.GetAxis ("Horizontal");
		//velocidade de movimentacao e mantem a velocidade do personagem quando estiver no ar 
		body.velocity = new Vector2 (move * velocidade, body.velocity.y);

		//faz a condição se o personagem ta virado para direita ou para esquerda 
		if ((move > 0 && sprite.flipX == true) || (move < 0 && sprite.flipX== false)) {
			flip ();
			
		}

		
	}
	void flip(){
		//se flipX for true ele exibe senao false com false ==false
		sprite.flipX = !sprite.flipX;
		
	}
}
