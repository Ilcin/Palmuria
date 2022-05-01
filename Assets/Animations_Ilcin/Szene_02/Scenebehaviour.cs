using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenebehaviour : MonoBehaviour {

    public RuntimeAnimatorController SceneKeiAusTuer;
    public RuntimeAnimatorController SceneAgemAuffordernd;
    public RuntimeAnimatorController SceneKeiRunning;
    public RuntimeAnimatorController SceneFalling;
	public AudioClip KeiBringsZurueck;
	public AudioClip AgemPah;
	public AudioClip Kampf;
	public AudioClip FallSchrei;
	public CharacterProps KeiProps;
	public CharacterProps AgemProps;

	public CutsceneController controller;
    public GameObject KeiAusTuer;
    public GameObject AgemAuffordernd;
    public GameObject KeiRunning;
    public GameObject Falling;
	public AudioSource AgemAudio;
	public AudioSource KeiAudio;

	private TextManager textManager;

    // Use this for initialization
    void Start () {
		
        Falling.SetActive(false);
        KeiRunning.SetActive(false);
        AgemAuffordernd.SetActive(false);
		textManager = FindObjectOfType<TextManager> ();
    }
	
	void FixedUpdate () {
       
		int count = controller.frameCount;

		if (count == 20) {
			KeiAudio.clip = KeiBringsZurueck;
			KeiAudio.Play ();
			textManager.DisplayMessage ("Hey Agem, bring das zurück!", KeiProps, 0);
		}

        //KeiAusTuer-->AgemAuffordernd
        if (count > 27)
        {
            //KeiAusTuer.SetActive(false);
            AgemAuffordernd.SetActive(true);
            AgemAuffordernd.GetComponent<SpriteRenderer>().sortingOrder = 10;
            AgemAuffordernd.GetComponent<Animator>().runtimeAnimatorController = SceneAgemAuffordernd;
        }

		if (count == 100) {
			AgemAudio.clip = AgemPah;
			AgemAudio.Play ();
			textManager.DisplayMessage ("Pah! Bring's doch selbst zurück!", AgemProps, 0);
		}

        //AgemAuffordernd-->KeiRunning
        if (count > 200)
        {
            KeiRunning.SetActive(true);
            AgemAuffordernd.SetActive(false);
            KeiRunning.GetComponent<SpriteRenderer>().sortingOrder = 20;
            KeiRunning.GetComponent<Animator>().runtimeAnimatorController = SceneKeiRunning;
        }

		if (count == 240) {
			KeiAudio.clip = Kampf;
			KeiAudio.Play ();
			textManager.DisplayMessage ("*laute Rauferei*", null, 0);
		}

        //KeiRunning --> Faling
        if (count > 600)
        {
			KeiRunning.GetComponent<Animator> ().SetBool ("Falling", true);
        }

		if (count == 650) {
			KeiAudio.clip = FallSchrei;
			KeiAudio.Play ();
			textManager.DisplayMessage ("*Schrei*", null, 0);
		}

        if (count > 700)
        {
           
            KeiAusTuer.SetActive(false);
        }


     
    }
}
