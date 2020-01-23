using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class tempojogo : MonoBehaviour {
	public Text tempoTexto;
	public static float tempo = 0;
	

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
		if (tempo >= 0) { 
			
			tempo += Time.deltaTime; 
			//converte o valor float para int
			int tempoText = (int)tempo; 
			// configura o text para o texto Tempo: 10
			tempoTexto.text = tempoText.ToString (); 
		}
		//se o tempo for menor ou igual a 0
	



		
	}
}
