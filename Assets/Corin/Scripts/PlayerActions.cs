using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    public GameObject Ass;
    public GameObject Poo;
    public Image PooIcon;
    public Image HammerIcon;
    public Image KickIcon;
    public int chargeCounter00 = 0;
    public int chargeCounter01 = 0;
    public int chargeCounter02 = 0;

    public AudioSource FartSound;
    public AudioSource KickSound;
    public AudioSource PunchSound;
    public AudioSource ExlosionSound;

    public GameObject player;   
    private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    if(CrossPlatformInputManager.GetButton("Fire1")){
   
        chargeCounter00++;
        PooIcon.fillAmount = chargeCounter00 / 150f;
        m_Animator.SetBool("Crouch", true);

        if(chargeCounter00 >= 150){
            Instantiate(Poo, Ass.transform.position, Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))));
            chargeCounter00 = 0 ;
            FartSound.Play();
        }
    }

    if(CrossPlatformInputManager.GetButton("Fire2")){
   
        chargeCounter01++;
        HammerIcon.fillAmount = chargeCounter01 / 100f;
        m_Animator.SetBool("Smash", true);
            //PunchSound.Play();

        if(chargeCounter01 >= 100f){
            chargeCounter01 = 0 ;
            //PunchSound.Play();
            ExlosionSound.PlayDelayed(10);

        }
    }

    if(CrossPlatformInputManager.GetButton("Fire3")){
   
        chargeCounter02++;
        KickIcon.fillAmount = chargeCounter02 / 100f;
        m_Animator.SetBool("Kick", true);
            //KickSound.Play();

        if(chargeCounter02 >= 100f){
            chargeCounter02 = 0 ;
            //KickSound.Play();
            ExlosionSound.PlayDelayed(10);
        }
    }



        if (CrossPlatformInputManager.GetButtonUp("Fire1")){
            chargeCounter00 = 0 ;
            PooIcon.fillAmount = 0;
        }

        if (CrossPlatformInputManager.GetButtonUp("Fire2")){
            chargeCounter01 = 0 ;
            HammerIcon.fillAmount = 0;
                    m_Animator.SetBool("Smash", false);

        }

        if (CrossPlatformInputManager.GetButtonUp("Fire3")){
            chargeCounter02 = 0 ;
            KickIcon.fillAmount = 0;
                    m_Animator.SetBool("Kick", false);

        }

    }
}
