using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {

      public static bool GameisPaused = false;
      public GameObject pauseMenuUI;
      public AudioMixer mixer;
      public static float volumeLevel = 1.0f;
      private Slider sliderVolumeCtrl;
	  
	  private GameObject player;
      public static int playerHealth = 100;
      public int StartPlayerHealth = 100;
      public GameObject healthText;

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
      public GameObject tokensRedText;
	  public GameObject tokensBlueText;
	  public GameObject tokensGreenText;
	  public GameObject tokensWhiteText;
	  
	  private string Ability1Number;    // these strings are used by the updatestatsdisplay function
	  private string Ability2Number;    // to convert the number of charges available for each ability
	  private string Ability3Number;	// into text to display the count on the ability bar
	  private string Ability4Number;
	  private string Ability5Number;
	  private string Ability6Number;
	  
	  public GameObject Ability1Count;	// these are the objects used to display ability count on the bar
	  public GameObject Ability2Count;
	  public GameObject Ability3Count;
	  public GameObject Ability4Count;
	  public GameObject Ability5Count;
	  public GameObject Ability6Count;

      public bool isDefending = false;

      public static bool stairCaseUnlocked = false;
      //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

      private string sceneName;

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
			
			player = GameObject.FindWithTag("Player");
            sceneName = SceneManager.GetActiveScene().name;
            //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
                  playerHealth = StartPlayerHealth;
            //}
            updateStatsDisplay();
      }
	  
	  void Update (){
                if (Input.GetKeyDown(KeyCode.Escape)){
                        if (GameisPaused){
                                Resume();
                        }
                        else{
                                Pause();
                        }
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
           if (isDefending == false){
                  playerHealth -= damage;
                  if (playerHealth >=0){
                        updateStatsDisplay();
                  }
                  if (damage > 0){
                        //player.GetComponent<PlayerHurt>().playerHit();       //play GetHit animation
                  }
            }

           if (playerHealth > StartPlayerHealth){
                  playerHealth = StartPlayerHealth;
                  updateStatsDisplay();
            }

           if (playerHealth <= 0){
                  playerHealth = 0;
                  updateStatsDisplay();
                  playerDies();
            }
      }

      public void updateStatsDisplay(){
            Text healthTextTemp = healthText.GetComponent<Text>();
            healthTextTemp.text = "HEALTH: " + playerHealth;

            Text tokensRedTextTemp = tokensRedText.GetComponent<Text>();
            tokensRedTextTemp.text = "RED POOP: " + gotRedTokens;
			
			Text tokensGreenTextTemp = tokensGreenText.GetComponent<Text>();
            tokensGreenTextTemp.text = "GREEN POOP: " + gotGreenTokens;
			
			Text tokensBlueTextTemp = tokensBlueText.GetComponent<Text>();
            tokensBlueTextTemp.text = "BLUE POOP: " + gotBlueTokens;
			
			Text tokensWhiteTextTemp = tokensWhiteText.GetComponent<Text>();
            tokensWhiteTextTemp.text = "WHITE POOP: " + gotWhiteTokens;
			
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
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("EndLose");
      }

      public void StartGame() {
            SceneManager.LoadScene("Gratis_Work");
      }

      public void RestartGame() {
            Time.timeScale = 1f;
			SceneManager.LoadScene("MainMenu");
                // Please also reset all static variables here, for new games!
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