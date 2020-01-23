using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class meutempo : MonoBehaviour {
	public Text txttempo;
	// Use this for initialization
	void Start () {//nao esquecer 
		txttempo.text = "Tempo: "+PersonagemPrincipal.meutempo.ToString("n2");//adicionando tempo pausado
		//com 2 casas decimais

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
