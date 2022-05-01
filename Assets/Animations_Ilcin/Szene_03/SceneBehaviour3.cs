using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehaviour3 : MonoBehaviour {

    public GameObject Activating;
    public GameObject Kei;
    public GameObject ActivatingWOKei;
	public AudioSource KeiAudio;
	public AudioSource AgemAudio;
	public CharacterProps KeiProps;
	public CharacterProps AgemProps;
    
	public CutsceneController controller;
    public RuntimeAnimatorController SceneActivating;
    public RuntimeAnimatorController SceneKei;
	public AudioClip KeiWasGetan;
	public AudioClip AgemWarumAnschnauzen;
	public AudioClip KeiDeineIdee;
	public AudioClip AgemSchrottteil;
	public AudioClip Woah;
	public AudioClip AgemLassGehen;

	private TextManager textManager;

	// Use this for initialization
	void Start () {
        Kei.SetActive(false);
        ActivatingWOKei.SetActive(false);
		textManager = FindObjectOfType<TextManager> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		int count = controller.frameCount;

		if (count == 60) {
			KeiAudio.clip = KeiWasGetan;
			KeiAudio.Play ();
			textManager.DisplayMessage ("Was hast du getan?", KeiProps, 0);
		}

		if (count == 100) {
			AgemAudio.clip = AgemWarumAnschnauzen;
			AgemAudio.Play ();
			textManager.DisplayMessage ("Warum schnauzt du mich jetzt an? Du hast uns in die Schlucht geschubst!", AgemProps, 0);
		}

		if (count == 260) {
			KeiAudio.clip = KeiDeineIdee;
			KeiAudio.Play ();
			textManager.DisplayMessage ("Es war doch deine Idee das … Ding zu stehlen.", KeiProps, 0);
		}

		if (count == 450) {
			AgemAudio.clip = AgemSchrottteil;
			AgemAudio.Play ();
			textManager.DisplayMessage ("Meinst du das Schrottteil hier?", AgemProps, 0);
		}

		if (count == 550) {
			KeiAudio.clip = Woah;
			KeiAudio.Play ();
			textManager.DisplayMessage ("Woah!", KeiProps, 0);
		}

		if (count == 800) {
			AgemAudio.clip = AgemLassGehen;
			AgemAudio.Play ();
			textManager.DisplayMessage ("Pack das alte Ding weg! Lass uns gehen.", AgemProps, 0);
		}

        if(count > 880 && count <1000)
        {
            Kei.SetActive(true);
            ActivatingWOKei.GetComponent<SpriteRenderer>().sortingOrder = 10;
            ActivatingWOKei.SetActive(true);
            Kei.GetComponent<Animator>().runtimeAnimatorController = SceneKei;
            Kei.transform.Translate(0.01F, 0.03F, 0);
            Kei.GetComponent<SpriteRenderer>().sortingOrder = 11;
        }
	}
}
