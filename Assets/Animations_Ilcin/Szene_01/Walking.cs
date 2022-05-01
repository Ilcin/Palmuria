using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public GameObject SceneKeiSeeingAgem;
    public GameObject SceneAgemLookingAround;
    public GameObject SceneAgemStealing;
	public GameObject AgemStealingAudio;
    public GameObject obj;
    public float speedX;
    public float speedY;

	public CutsceneController controller;
    public RuntimeAnimatorController KeiBreathing;
    public RuntimeAnimatorController KeiSeeingAgem;
    public RuntimeAnimatorController AgemStealing;
    public RuntimeAnimatorController AgemLookingAround;
	public AudioClip keiBreathingClip;

	public CharacterProps keiProps;
	public CharacterProps agemProps;

	private TextManager textManager;
   
    // Use this for initialization
    void Start()
    {
		textManager = FindObjectOfType<TextManager> ();
    }




    // Update is called once per frame
    void FixedUpdate()
    {
		int count = controller.frameCount;
        // obj.transform.Translate(Vector3.right*Time.deltaTime);

        if (obj.tag == "KeiWalking")
        {
			if (count == 175) {
				textManager.DisplayMessage ("Nicht langsamer werden! Nichts anfassen! Wir sind einer Studienfahrt, nicht auf einer Spielfläche.", null, 0);
			}
			if (count == 250) {
				AudioSource audioSource = GetComponent<AudioSource> ();
				audioSource.Play ();
			}
            if (count > 550)
            {
				if (count == 560) {
					AudioSource audioSource = GetComponent<AudioSource> ();
					audioSource.clip = keiBreathingClip;
					audioSource.loop = false;
					audioSource.spatialize = false;
					audioSource.Play ();
					textManager.DisplayMessage ("*entnervtes Ausatmen*", keiProps, 0);
				}

                this.GetComponent<Animator>().runtimeAnimatorController = KeiBreathing;
                if (count > 560 && count < 570)
                {
                    obj = GameObject.FindGameObjectWithTag("KeiWalking");
                    obj.transform.position = new Vector3(100,100,-100);
                    SceneKeiSeeingAgem.GetComponent<SpriteRenderer>().sortingOrder = 11;
                    SceneKeiSeeingAgem.GetComponent<Animator>().runtimeAnimatorController = KeiSeeingAgem;
                  


                }
                if (count > 680 && count < 700)
                {
                    SceneKeiSeeingAgem.SetActive(false);
                    SceneAgemLookingAround.GetComponent<SpriteRenderer>().sortingOrder = 12;
                    
                    SceneAgemLookingAround.GetComponent<Animator>().runtimeAnimatorController = AgemLookingAround;
                }

				if (count == 770) {
					AgemStealingAudio.SetActive (true);
					textManager.DisplayMessage ("*hämisches Lachen*", agemProps, 0);
				}

                if (count > 840)
                {
                    SceneAgemLookingAround.SetActive(false);
                    SceneAgemStealing.GetComponent<SpriteRenderer>().sortingOrder = 13;
                    SceneAgemStealing.GetComponent<Animator>().runtimeAnimatorController = AgemStealing;
                }




            }
            else
            {
                obj.transform.Translate(1 * speedX, 1 * speedY, 0);
            }

        }
        else
        {
            obj.transform.Translate(1 * speedX, 1 * speedY, 0);
        }
    }

        
    
}
