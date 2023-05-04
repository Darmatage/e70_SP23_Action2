using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {

      private Animator anim;
	  public bool GameisPaused = false;
      public GameObject pauseMenuUI;
      public AudioMixer mixer;
      public static float volumeLevel = 1.0f;
      private Slider sliderVolumeCtrl;
	  
	  public Image healthBar;
	  public Image oxygenBar;
	  
	  private GameObject player;
      public static float playerHealth = 100f;
      public float StartPlayerHealth = 100f;
	  public float MaxPlayerHealth = 200f;
      // changing public static to just public
	  public float playerOxygen = 100f;
      public float StartPlayerOxygen = 100f;
      public GameObject healthText;
	  public GameObject oxygenText;
	  
	  

      public static int gotRedTokens = 0;		// these intergers track the number of resources collected
	  public static int gotBlueTokens = 0;		
	  public static int gotGreenTokens = 0;
	  public static int gotWhiteTokens = 0;
	  public static int gotAbility1 = 0;		// these track the number of abilities created
	  public static int gotAbility2 = 0;
	  public static int gotAbility3 = 0;
	  public static int gotAbility4 = 0;
	  public static int gotAbility5 = 0;
	  public static int gotAbility6 = 0;
	  public static int howManyEnemies = 0;
      public GameObject tokensRedText;
	  public GameObject tokensBlueText;
	  public GameObject tokensGreenText;
	  public GameObject tokensWhiteText;
	  public GameObject enemyCountText;
	  
	  private string Ability1Number;    // these strings are used by the updatestatsdisplay function
	  private string Ability2Number;    // to convert the number of charges available for each ability
	  private string Ability3Number;	// into text to display the count on the ability bar
	  private string Ability4Number;
	  private string Ability5Number;
	  private string Ability6Number;
	  
	  private string RedTokenNumber;
	  private string WhiteTokenNumber;
	  private string GreenTokenNumber;
	  private string BlueTokenNumber;
	  
	  public GameObject Ability1Count;	// these are the objects used to display ability count on the bar
	  public GameObject Ability2Count;
	  public GameObject Ability3Count;
	  public GameObject Ability4Count;
	  public GameObject Ability5Count;
	  public GameObject Ability6Count;

      public bool isDefending = false;
	  
	  public PlayerMove_Rotate PM;

      public static bool stairCaseUnlocked = false;
      //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

      private string sceneName;
	  
	  //used in getHit to test for player follower removal:
	  bool is120; bool is140; bool is160; bool is180; bool is200;

      void Awake (){
                SetLevel (volumeLevel);
                GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                if (sliderTemp != null){
                        sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                        sliderVolumeCtrl.value = volumeLevel;
                }
        }
	  
	  void Start(){
			pauseMenuUI.SetActive(false);
            GameisPaused = false;
			
			healthBar.fillAmount = playerHealth / MaxPlayerHealth;
			
			player = GameObject.FindWithTag("Player");
            sceneName = SceneManager.GetActiveScene().name;
            if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
                  playerHealth = StartPlayerHealth;
            }
			
			if (GameObject.FindWithTag ("Player") != null) {
                PM = GameObject.FindWithTag ("Player").GetComponent<PlayerMove_Rotate> ();
            }
			
			if (GameObject.FindWithTag ("PLAYERART") != null) {
                anim = GameObject.FindWithTag ("PLAYERART").GetComponent<Animator> ();
            }
			
			//FindObjectOfType<GameHandler_PlayerFollowers>().AddToFollowerList(1);
			
            updateStatsDisplay();
      }
	  
	  void Update (){
                updateStatsDisplay();
				if (Input.GetKeyDown(KeyCode.Escape)){
                        if (GameisPaused){
                                Resume();
                        }
                        else{
                                Pause();
                        }
                }
				
				if(playerHealth >= 101) {
					
				}
        }
		
		void Pause(){
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GameisPaused = true;
        }
		
		public void Resume(){
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameisPaused = false;
        }
		
		public void SetLevel (float sliderValue){
                mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
                volumeLevel = sliderValue;
        } 
	  

      public void playerGetRedTokens(int newRedTokens){
            gotRedTokens += newRedTokens;
            updateStatsDisplay();
      }
	  public void playerGetBlueTokens(int newBlueTokens){
            gotBlueTokens += newBlueTokens;
           updateStatsDisplay();
      }
	  public void playerGetGreenTokens(int newGreenTokens){
            gotGreenTokens += newGreenTokens;
            updateStatsDisplay();
      }
	  public void playerGetWhiteTokens(int newWhiteTokens){
            gotWhiteTokens += newWhiteTokens;
            updateStatsDisplay();
      }

	public void playerGetHit(int damage){
		//note: poop adds to health with "negative damage"
		if ((PM.isDashing == false)||(damage < 0)){
			//check to add follower
			if ((damage < 0)&&(playerHealth==119 || playerHealth==139 || playerHealth==159 || playerHealth==179 || playerHealth==199)){
				GetComponent<GameHandler_PlayerFollowers>().AddToFollowerList(1);
				GameHandler_PlayerFollowers.playerFollowers ++;
			}
			
			//prepare check to remove follower:
			if 	((playerHealth > 119)&&(playerHealth < 140)){is120=true;}
			else if ((playerHealth > 139)&&(playerHealth < 160)){is140=true;}	
			else if ((playerHealth > 159)&&(playerHealth < 180)){is160=true;}
			else if ((playerHealth > 179)&&(playerHealth < 200)){is180=true;}
			else if (playerHealth >= 200){is200=true;}
			
            playerHealth -= damage;
			
			// check to remove follower:
			if ((is120)&&(playerHealth < 120)){GetComponent<GameHandler_PlayerFollowers>().RemoveFromFollowerList();is120=false;}
			else if ((is140)&&(playerHealth < 140)){GetComponent<GameHandler_PlayerFollowers>().RemoveFromFollowerList();is140=false;}
			else if ((is160)&&(playerHealth < 160)){GetComponent<GameHandler_PlayerFollowers>().RemoveFromFollowerList();is160=false;}
			else if ((is180)&&(playerHealth < 180)){GetComponent<GameHandler_PlayerFollowers>().RemoveFromFollowerList();is180=false;}
			else if ((is200)&&(playerHealth < 200)){GetComponent<GameHandler_PlayerFollowers>().RemoveFromFollowerList();is200=false;}
			
				  healthBar.fillAmount = playerHealth / MaxPlayerHealth;
                  if (playerHealth >=0){
                        updateStatsDisplay();
                  }
                  if (damage > 0){
                        //player.GetComponent<PlayerGetHurt>().playerHit();       //play GetHit animation
                  }
				  else if (damage < 0){
                        //player.GetComponent<PlayerMove_Rotate>().playerChomp();       //play Chomp animation
                  }
            }

           if (playerHealth > MaxPlayerHealth){
                  playerHealth = MaxPlayerHealth;
                  updateStatsDisplay();
            }

           if (playerHealth <= 0){
                  playerHealth = 0;
                  updateStatsDisplay();
                  playerDies();
            }
      }
	  
      public void updateStatsDisplay(){
            oxygenBar.fillAmount = playerOxygen / StartPlayerOxygen;
			
			healthBar.fillAmount = playerHealth / MaxPlayerHealth;
			
			Text healthTextTemp = healthText.GetComponent<Text>();
            healthTextTemp.text = "HEALTH: " + playerHealth;
			
			Text oxygenTextTemp = oxygenText.GetComponent<Text>();
            oxygenTextTemp.text = "OXYGEN: " + playerOxygen;

            Text tokensRedTextTemp = tokensRedText.GetComponent<Text>();
            tokensRedTextTemp.text = ": " + gotRedTokens;
			
			Text tokensGreenTextTemp = tokensGreenText.GetComponent<Text>();
            tokensGreenTextTemp.text = ": " + gotGreenTokens;
			
			Text tokensBlueTextTemp = tokensBlueText.GetComponent<Text>();
            tokensBlueTextTemp.text = ": " + gotBlueTokens;
			
			Text tokensWhiteTextTemp = tokensWhiteText.GetComponent<Text>();
            tokensWhiteTextTemp.text = ": " + gotWhiteTokens;
			
			
			GameObject[] hives = GameObject.FindGameObjectsWithTag("Hive");
            howManyEnemies = hives.Length;
            // Debug.Log("There are "+ howManyEnemies + " enemies remaining.");
			
			
			Text enemyCountTextTemp = enemyCountText.GetComponent<Text>();
            enemyCountTextTemp.text = "REMAINING HIVES: " + howManyEnemies;
			
			Text Ability1CountTemp = Ability1Count.GetComponent<Text>();  //declare some temp text, set it to the text component of the proper object
			Ability1Number = gotAbility1.ToString();						//we take the AbilityXNumber string, and use the ToString function to turn the interger that tracks ability count into this string
            Ability1CountTemp.text = Ability1Number;						// now we set the actual text to be equal to this string, which was just updated to match the number of remaining ability uses
			
			Text Ability2CountTemp = Ability2Count.GetComponent<Text>();
            Ability2Number = gotAbility2.ToString();
            Ability2CountTemp.text = Ability2Number;
			
			Text Ability3CountTemp = Ability3Count.GetComponent<Text>();
            Ability3Number = gotAbility3.ToString();
            Ability3CountTemp.text = Ability3Number;
			
			Text Ability4CountTemp = Ability4Count.GetComponent<Text>();
            Ability4Number = gotAbility4.ToString();
            Ability4CountTemp.text = Ability4Number;
			
			Text Ability5CountTemp = Ability5Count.GetComponent<Text>();
            Ability5Number = gotAbility5.ToString();
            Ability5CountTemp.text = Ability5Number;
			
			Text Ability6CountTemp = Ability6Count.GetComponent<Text>();
            Ability6Number = gotAbility6.ToString();
            Ability6CountTemp.text = Ability6Number;
      }

      public void playerDies(){
           // player.GetComponent<PlayerHurt>().playerDead();       //play Death animation
            StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
            //player.GetComponent<PlayerMove>().isAlive = false;
           // player.GetComponent<PlayerJump>().isAlive = false;
            anim.SetTrigger("Death");
			gotRedTokens = 0;		// these intergers track the number of resources collected
			gotBlueTokens = 0;		
			gotGreenTokens = 0;
			gotWhiteTokens = 0;
			gotAbility1 = 0;		// these track the number of abilities created
			gotAbility2 = 0;
			gotAbility3 = 0;
			gotAbility4 = 0;
			gotAbility5 = 0;
			gotAbility6 = 0;
			yield return new WaitForSeconds(3.5f);
            SceneManager.LoadScene("End_Lose");
		}

      public void StartGame() {
            SceneManager.LoadScene("Rishabh_Work");
      }
	  
	  public void StartLate() {
            SceneManager.LoadScene("Gratis_Work");
      }

      public void RestartGame() {
            Time.timeScale = 1f;
			SceneManager.LoadScene("MainMenu");
			GameHandler_PlayerFollowers.playerFollowers = 0;
			
                // Please also reset all static variables here, for new games!
			gotRedTokens = 0;		
			gotBlueTokens = 0;		
			gotGreenTokens = 0;
			gotWhiteTokens = 0;
			gotAbility1 = 0;		
			gotAbility2 = 0;
			gotAbility3 = 0;
			gotAbility4 = 0;
			gotAbility5 = 0;
			gotAbility6 = 0;
			
			
            playerHealth = StartPlayerHealth;
		}

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
      }
}