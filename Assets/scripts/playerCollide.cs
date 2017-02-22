using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerCollide : MonoBehaviour {

   // public Collider playerCollide ;

	// Use this for initialization
    Camera cam;
    camdescend pDescend;
    GameObject character, player, goPanel, btnPause, ui, maincam, boostLane;
    Button btnShield,btnAttack,btnBoost;
    // GameObject playerObj;
    scoreCounter scoring;
    SwipeMovement swipeScript;
    Animator gameover;
    public Slider healthbarSlider,boostbarSlider;
    RdmObjGen rdmobj;
    bool invokeCollectiblesOnce = false;
    Animation anim;
    SfxPlayer sfxScript;
    boostMusic boostMusicScript;
    int tempGoldCoins, goldCoins;
    highScore hscoreScript;
    Text colCoins;

	void Start () {
   
        rdmobj = GameObject.Find("RdmGen").GetComponent<RdmObjGen>();
        boostLane = GameObject.Find("BoostLane");
        healthbarSlider = GameObject.Find("healthSlider").GetComponent<Slider>();
        boostbarSlider = GameObject.Find("boostSlider").GetComponent<Slider>();
        ui = GameObject.Find("UI");
        maincam = GameObject.Find("Main Camera");
        cam = Camera.main;
        btnPause = GameObject.Find("Pause");
        goPanel = GameObject.Find("goPanel");
        gameover = goPanel.GetComponent<Animator>();
        character = GameObject.FindGameObjectWithTag("character");
        player = GameObject.FindGameObjectWithTag("Player");
        scoring = GameObject.Find("subScoreCounter").GetComponent<scoreCounter>();
        pDescend = player.gameObject.GetComponent<camdescend>();
        anim = GameObject.FindGameObjectWithTag("character").GetComponent<Animation>();
        btnShield = GameObject.Find("btnShield").GetComponent<Button>();
        btnAttack = GameObject.Find("btnAttack").GetComponent<Button>();
        btnBoost = GameObject.Find("btnBoost").GetComponent<Button>();
        PlayerPrefs.DeleteKey("tempGoldCoins");
        colCoins = GameObject.Find("txtCc").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //try lang movement
        //playerObj.transform.Rotate(Vector3.back * Time.deltaTime * rotSpeedX);

        if (boostbarSlider.value == boostbarSlider.maxValue)
        {
           // regenBoostNow = false;
           
            CancelInvoke("regenBoostInvoked");
            rdmobj.stopBoostNow = false;
         //   print("boost resumed");
            if (!invokeCollectiblesOnce)
            {
                rdmobj.invokeCollectibles = true;
                invokeCollectiblesOnce = true;
            }
        }

        if (boostbarSlider.value <= 0f)
        {
           
            regenBoost();
        }
  
        	}

    void regenBoost()
    {

        InvokeRepeating("regenBoostInvoked", 4, 4);
        
    }

    void regenBoostInvoked(){
        boostbarSlider.value += 0.005f;
        swipeScript.boostCap += 0.005f;
        invokeCollectiblesOnce = !invokeCollectiblesOnce;
    }

    void OnTriggerEnter(Collider playerCollider)
    {

        if (playerCollider.gameObject.tag == "Obstacles")
        {
            // game over
           

            gameover.SetBool("isGameOver", true);
            character.GetComponent<Animation>().CrossFade("shopper_dead_top");
            GameObject subScoreCounter = GameObject.Find("subScoreCounter");
            Destroy(subScoreCounter);
          pDescend.enabled = true;
          scoring.stopScoring(true);
          btnPause.SetActive(false);
          cam.SendMessage("TurnBlurOn");
          ui.SetActive(false);

            //highscore
          hscoreScript = GameObject.Find("GameOver").GetComponent<highScore>();
          hscoreScript.CheckAndSet();

            //game over sfx
          GameObject objSfxGameOver = GameObject.Find("sfxGameOver");
          AudioSource asSfxGameOver = objSfxGameOver.GetComponent<AudioSource>();
          asSfxGameOver.Play();
          BoxCollider colPlayer = GetComponent<BoxCollider>();
          colPlayer.enabled = false;

            //addcoin from temp
          if (PlayerPrefs.HasKey("tempGoldCoins"))
          {
              tempGoldCoins = PlayerPrefs.GetInt("tempGoldCoins");
              goldCoins = PlayerPrefs.GetInt("PlayerGold");
              PlayerPrefs.SetInt("PlayerGold", goldCoins + tempGoldCoins);
            
          }
        }

        else if (playerCollider.gameObject.tag == "CollectiblesCap")
        {
            // collectible capacity
            swipeScript = maincam.gameObject.GetComponent<SwipeMovement>();
            swipeScript.swipeCap = healthbarSlider.maxValue;
            healthbarSlider.value = healthbarSlider.maxValue;
            Destroy(playerCollider.gameObject);
            print("cap collided");

            GameObject objSfxCap = GameObject.Find("sfxCollectSwipe");
            sfxScript = objSfxCap.GetComponent<SfxPlayer>();
            sfxScript.playSfx();
        }

        else if (playerCollider.gameObject.tag == "CollectiblesBoost")
        {
            // collectible boost

            btnBoost.interactable = true;
            rdmobj.stopBoostNow = true;
            Destroy(playerCollider.gameObject);

            GameObject objSfxBoost = GameObject.Find("sfxCollectBoost");
            sfxScript = objSfxBoost.GetComponent<SfxPlayer>();
            sfxScript.playSfx();
        }

        else if (playerCollider.gameObject.tag == "CollectiblesShield")
        {
            // collectible shield

            btnShield.interactable = true;
            rdmobj.stopShieldNow = true;
            Destroy(playerCollider.gameObject);

            GameObject objSfxShield = GameObject.Find("sfxCollectShield");
            sfxScript = objSfxShield.GetComponent<SfxPlayer>();
            sfxScript.playSfx();
        }

        else if (playerCollider.gameObject.tag == "CollectiblesAttack")
        {
            // collectible attack
            rdmobj.stopAttackNow = true;
            btnAttack.interactable = true;
            Destroy(playerCollider.gameObject);

            GameObject objSfxAttack = GameObject.Find("sfxCollectAttack");
            sfxScript = objSfxAttack.GetComponent<SfxPlayer>();
            sfxScript.playSfx();
        }

        else if (playerCollider.gameObject.tag == "CollectiblesCoin")
        {
            // collectible attack
            rdmobj.stopAttackNow = true;
            btnAttack.interactable = true;
            Destroy(playerCollider.gameObject);

            GameObject objSfxCoin = GameObject.Find("sfxCollectCoin");
            sfxScript = objSfxCoin.GetComponent<SfxPlayer>();
            sfxScript.playSfx();

            //addCoin from colleced
            PlayerPrefs.SetInt("tempGoldCoins", PlayerPrefs.GetInt("tempGoldCoins") + 1);

            int Cc = int.Parse(colCoins.text);
            Cc += 1;
            colCoins.text = Cc.ToString();

        }
    }

    public void startBoost()
    {
        anim.CrossFade("shopper_girl_spin");
        swipeScript = maincam.gameObject.GetComponent<SwipeMovement>();
        swipeScript.targetPosition = boostLane.transform.position;
        Time.timeScale = 4f;
        rdmobj.stopBoostNow = true;
        InvokeRepeating("decBoost", 4, 4);

        // disable buttons
        btnPause.GetComponent<Button>().interactable = false;
        btnBoost.GetComponent<Button>().enabled = false;
        btnShield.GetComponent<Button>().enabled = false;
        btnAttack.GetComponent<Button>().enabled = false;


    }

    void Unboost()
    {
        swipeScript = maincam.gameObject.GetComponent<SwipeMovement>();
        swipeScript.currentLane = "Lane2";
        anim.CrossFade("shopper_idle_anim_001");
        swipeScript.targetPosition = swipeScript.target2.transform.position;
        Time.timeScale = 1f;
        //destroy all obstacles
        GameObject[] obs = GameObject.FindGameObjectsWithTag("Obstacles");

        foreach (GameObject ob in obs)
        {
            Destroy(ob);
        }

        //destroy collectiblecaps
        GameObject[] obscap = GameObject.FindGameObjectsWithTag("CollectiblesCap");
        foreach (GameObject obcap in obscap)
        {
            Destroy(obcap);
        }

        //destroy collectibleboost
        GameObject[] obsboost = GameObject.FindGameObjectsWithTag("CollectiblesBoost");
        foreach (GameObject obboost in obsboost)
        {
            Destroy(obboost);
        }

        //enable buttons
        btnPause.GetComponent<Button>().interactable = true;
        btnBoost.GetComponent<Button>().enabled = true;
        btnShield.GetComponent<Button>().enabled = true;
        btnAttack.GetComponent<Button>().enabled = true;

        //stop boost music
        GameObject objboostMusic = GameObject.Find("btnBoost");
        boostMusicScript = objboostMusic.GetComponent<boostMusic>();
        boostMusicScript.stopBoostMusic();
       
    }

    void decBoost()
    {
        if (swipeScript.boostCap >= 1f)
        {
            
            swipeScript = maincam.gameObject.GetComponent<SwipeMovement>();
            swipeScript.boostCap -= 1f;
            boostbarSlider.value -= 1f;
        }else 
        {
            //regenBoostNow = true;
            CancelInvoke("decBoost");
            Unboost();
        }
    }


    

    
}
