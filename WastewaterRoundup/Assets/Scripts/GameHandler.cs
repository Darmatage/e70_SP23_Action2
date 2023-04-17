using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

      private GameObject player;
      public static int playerHealth = 100;
      public int StartPlayerHealth = 100;
      public GameObject healthText;

      public static int gotRedTokens = 0;
	  public static int gotBlueTokens = 0;
	  public static int gotGreenTokens = 0;
	  public static int gotWhiteTokens = 0;
	  public static int gotAbility1 = 0;
	  public static int gotAbility2 = 0;
	  public static int gotAbility3 = 0;
	  public static int gotAbility4 = 0;
	  public static int gotAbility5 = 0;
	  public static int gotAbility6 = 0;
      public GameObject tokensRedText;
	  public GameObject tokensBlueText;
	  public GameObject tokensGreenText;
	  public GameObject tokensWhiteText;

      public bool isDefending = false;

      public static bool stairCaseUnlocked = false;
      //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

      private string sceneName;

      void Start(){
            player = GameObject.FindWithTag("Player");
            sceneName = SceneManager.GetActiveScene().name;
            //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
                  playerHealth = StartPlayerHealth;
            //}
            updateStatsDisplay();
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
            SceneManager.LoadScene("PickupScene");
      }

      public void RestartGame() {
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