using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NewInventory : MonoBehaviour {
	public GameObject InventoryMenu;
    //public GameObject CraftMenu;
    public bool InvIsOpen = true;
	
	public Text Ability1_count;
	public Text Ability2_count;
	public Text Ability3_count;
	public Text Ability4_count;
	//public Text Ability5_count;
	//public Text Ability6_count;
	
	//private float craftMenuTime = 0f;
	
	
	
	// Assign by dragging the GameObject with ScriptA into the inspector before running the game.
    public GameHandler theGameHandler; 
	  
	  
	  
	// Crafting buttons. Uncomment and add for each button:
    public GameObject buttonCraft1; // create ability 1
	public GameObject buttonCraft2; // create ability 2
	public GameObject buttonCraft3; // create ability 3
	public GameObject buttonCraft4; // create ability 4
	//public GameObject buttonCraft5; // create ability 5
	//public GameObject buttonCraft6; // create ability 6
	
    // Start is called before the first frame update
    void Start(){
    InventoryMenu.SetActive(true);
	Ability1_count.text = GameHandler.gotAbility1.ToString();
	Ability2_count.text = GameHandler.gotAbility2.ToString();
	Ability3_count.text = GameHandler.gotAbility3.ToString();
	Ability4_count.text = GameHandler.gotAbility4.ToString();
	//Ability5_count.text = GameHandler.gotAbility5.ToString();
	//Ability6_count.text = GameHandler.gotAbility6.ToString();
    }

    // Update is called once per frame
    void Update(){
		
		if (theGameHandler.GameisPaused == false) {
			if (InvIsOpen == true) {
				//Time.timeScale = 0.25f;
			}	
			else {
				//Time.timeScale = 1f;
			}
		}
			
		
		
		//Time.timeScale = 0f;
                //GameisPaused = true;
		
		/*if (Time.time >= craftMenuTime){
			if (Input.GetAxis("CraftMenu") > 0) {
				OpenCloseInventory();
				craftMenuTime = Time.time + 0.15f;
			}
		}*/
		
		if (GameHandler.gotRedTokens >= 1 && GameHandler.gotBlueTokens >= 1) {   // controls visibility of craft button 1
			buttonCraft1.SetActive(true);
		}
		else {
			buttonCraft1.SetActive(false);
		}
		
		if (GameHandler.gotGreenTokens >= 1 && GameHandler.gotWhiteTokens >= 1) {   // controls visibility of craft button 2
			buttonCraft2.SetActive(true);
		}
		else {
			buttonCraft2.SetActive(false);
		}
		
		if (GameHandler.gotRedTokens >= 1 && GameHandler.gotGreenTokens >= 1) {   // controls visibility of craft button 3
			buttonCraft3.SetActive(true);
		}
		else {
			buttonCraft3.SetActive(false);
		}
		
		if (GameHandler.gotBlueTokens >= 1 && GameHandler.gotWhiteTokens >= 1) {   // controls visibility of craft button 4
			buttonCraft4.SetActive(true);
		}
		else {
			buttonCraft4.SetActive(false);
		}
    } // END OF UPDATE FUNCTION
	
	/*public void OpenCloseInventory(){
        if (InvIsOpen){ InventoryMenu.SetActive(false); }
        else { InventoryMenu.SetActive(true); }
        InvIsOpen = !InvIsOpen;
    }*/
	public void CraftObject1(){   // Dash
        GameHandler.gotRedTokens = GameHandler.gotRedTokens - 1;       //decreases required resource 1
		GameHandler.gotBlueTokens = GameHandler.gotBlueTokens - 1;     //decreases required resource 2
		GameHandler.gotAbility1 = GameHandler.gotAbility1 + 2;			//adds 2 uses of ability to ability count
		Ability1_count.text = GameHandler.gotAbility1.ToString();		// updates ability display with new ability count
		theGameHandler.updateStatsDisplay();								//update the rest of the stat display
		Debug.Log("A1 Created!");
    }
	public void CraftObject2(){     // Zap
        GameHandler.gotGreenTokens = GameHandler.gotGreenTokens - 1;
		GameHandler.gotWhiteTokens = GameHandler.gotWhiteTokens - 1;
		GameHandler.gotAbility2 = GameHandler.gotAbility2 + 3;
		Ability2_count.text = GameHandler.gotAbility2.ToString();
		theGameHandler.updateStatsDisplay();
		Debug.Log("A2 Created!");
    }
	public void CraftObject3(){
        GameHandler.gotRedTokens = GameHandler.gotRedTokens - 1;
		GameHandler.gotGreenTokens = GameHandler.gotGreenTokens - 1;
		GameHandler.gotAbility3 = GameHandler.gotAbility3 + 1;
		Ability3_count.text = GameHandler.gotAbility3.ToString();
		theGameHandler.updateStatsDisplay();
		Debug.Log("A3 Created!");
    }
	public void CraftObject4(){
        GameHandler.gotBlueTokens = GameHandler.gotBlueTokens - 1;
		GameHandler.gotWhiteTokens = GameHandler.gotWhiteTokens - 1;
		GameHandler.gotAbility4 = GameHandler.gotAbility4 + 1;
		Ability4_count.text = GameHandler.gotAbility4.ToString();
		theGameHandler.updateStatsDisplay();
		Debug.Log("A4 Created!");
    }
}
