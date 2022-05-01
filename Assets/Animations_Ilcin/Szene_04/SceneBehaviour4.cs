using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehaviour4 : MonoBehaviour {

    public GameObject Kei;
    public GameObject Agem;
    public GameObject Ruine;
    public GameObject SchluchtH;
    public GameObject SchluchtV;

	public AudioClip KeiGuckMalAgem;
	public AudioClip AgemBauerntoelpel;
	public AudioClip KeiLetzteWoche;
	public CharacterProps KeiProps;
	public CharacterProps AgemProps;
    
	public CutsceneController controller;

	private TextManager textManager;

	// Use this for initialization
	void Start () {
		textManager = FindObjectOfType<TextManager> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		int count = controller.frameCount;
     
        //AusSchluchtRaus
        if(count > 0)
        {
            if(count > 0&& count <10)
            {
                Kei.transform.localScale = new Vector3(2f, 2f, 1f);
                Kei.transform.position = new Vector3(8, 1, 0);
            }
            //setup
            SchluchtV.GetComponent<SpriteRenderer>().sortingOrder = 30;
            SchluchtH.GetComponent<SpriteRenderer>().sortingOrder = 20;
            Kei.GetComponent<SpriteRenderer>().sortingOrder = 25;
            Agem.GetComponent<SpriteRenderer>().sortingOrder = 25;


            //moving
            Agem.SetActive(true);
           // 
            Kei.transform.Translate(-0.06f, 0, 0);  
            Agem.transform.Translate(-0.04f, 0, 0);
			Kei.GetComponent<Animator>().SetFloat("speedMulti", 1.6f);

        }

		if (count == 15) {
			AudioSource audioSource = Kei.GetComponent<AudioSource> ();
			audioSource.clip = KeiGuckMalAgem;
			audioSource.Play ();
			textManager.DisplayMessage ("Guck mal! Agem! Da vorne ist eine Ruine. Ich will da hin.\n" +
				"Da gibts bestimmt gutes Material für meine Cyber-Projekte. Lass uns da vorbeischauen!", KeiProps, 0);
		}

		if (count == 380) {
			AudioSource audioSource = Agem.GetComponent<AudioSource> ();
			audioSource.clip = AgemBauerntoelpel;
			audioSource.Play ();
			textManager.DisplayMessage ("*Genervtes Stöhnen* Dieser Bauerntölpel!", AgemProps, 0);
		}

		if (count == 460) {
			AudioSource audioSource = Kei.GetComponent<AudioSource> ();
			audioSource.clip = KeiLetzteWoche;
			audioSource.Play ();
			textManager.DisplayMessage ("Letzte Woche zum Beispiel, da hab ich ein ganz tolles Zahnrad gefunden und …", KeiProps, 0);
		}

        //BlickaufRuine
        if(count > 570)
        {
			Kei.GetComponent<SpriteRenderer>().enabled = false;
			Agem.GetComponent<SpriteRenderer>().enabled = false;
            SchluchtH.SetActive(false);
            SchluchtV.SetActive(false);
            Ruine.SetActive(true);
            Ruine.GetComponent<SpriteRenderer>().sortingOrder = 40;

        }
        
		
	}
}
