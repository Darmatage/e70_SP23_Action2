using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NewInventory : MonoBehaviour {
	public GameObject InventoryMenu;
    //public GameObject CraftMenu;
    public bool InvIsOpen = false;
	
	
	// Assign by dragging the GameObject with ScriptA into the inspector before running the game.
    public GameHandler m_GameHandler; 
	  
	  
	  
	// Crafting buttons. Uncomment and add for each button:
    public GameObject buttonCraft1; // create ability 1
	public GameObject buttonCraft2; // create ability 2
	public GameObject buttonCraft3; // create ability 3
	public GameObject buttonCraft4; // create ability 4
	public GameObject buttonCraft5; // create ability 5
	public GameObject buttonCraft6; // create ability 6
	
    // Start is called before the first frame update
    void Start(){
    InventoryMenu.SetActive(false);	
    }

    // Update is called once per frame
    void Update(){
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
		
		if (GameHandler.gotRedTokens >= 1 && GameHandler.gotWhiteTokens >= 1) {   // controls visibility of craft button 4
			buttonCraft4.SetActive(true);
		}
		else {
			buttonCraft4.SetActive(false);
		}
		
		if (GameHandler.gotGreenTokens >= 1 && GameHandler.gotBlueTokens >= 1) {   // controls visibility of craft button 5
			buttonCraft5.SetActive(true);
		}
		else {
			buttonCraft5.SetActive(false);
		}
		
		if (GameHandler.gotWhiteTokens >= 1 && GameHandler.gotBlueTokens >= 1) {   // controls visibility of craft button 6
			buttonCraft6.SetActive(true);
		}
		else {
			buttonCraft6.SetActive(false);
		}
    }
	public void OpenCloseInventory(){
        if (InvIsOpen){ InventoryMenu.SetActive(false); }
        else { InventoryMenu.SetActive(true); }
        InvIsOpen = !InvIsOpen;
    }
	public void CraftObject1(){
        GameHandler.gotRedTokens = GameHandler.gotRedTokens - 1;
		GameHandler.gotBlueTokens = GameHandler.gotBlueTokens - 1;
		GameHandler.gotAbility1 = GameHandler.gotAbility1 + 1;
		m_GameHandler.updateStatsDisplay();
		Debug.Log("A1 Created!");
    }
	public void CraftObject2(){
        GameHandler.gotGreenTokens = GameHandler.gotGreenTokens - 1;
		GameHandler.gotWhiteTokens = GameHandler.gotWhiteTokens - 1;
		GameHandler.gotAbility2 = GameHandler.gotAbility2 + 1;
		m_GameHandler.updateStatsDisplay();
		Debug.Log("A2 Created!");
    }
	public void CraftObject3(){
        GameHandler.gotRedTokens = GameHandler.gotRedTokens - 1;
		GameHandler.gotGreenTokens = GameHandler.gotGreenTokens - 1;
		GameHandler.gotAbility3 = GameHandler.gotAbility3 + 1;
		m_GameHandler.updateStatsDisplay();
		Debug.Log("A3 Created!");
    }
	public void CraftObject4(){
        GameHandler.gotRedTokens = GameHandler.gotRedTokens - 1;
		GameHandler.gotWhiteTokens = GameHandler.gotWhiteTokens - 1;
		GameHandler.gotAbility4 = GameHandler.gotAbility4 + 1;
		m_GameHandler.updateStatsDisplay();
		Debug.Log("A4 Created!");
    }
	public void CraftObject5(){
        GameHandler.gotGreenTokens = GameHandler.gotGreenTokens - 1;
		GameHandler.gotBlueTokens = GameHandler.gotBlueTokens - 1;
		GameHandler.gotAbility5 = GameHandler.gotAbility5 + 1;
		m_GameHandler.updateStatsDisplay();
		Debug.Log("A5 Created!");
    }
	public void CraftObject6(){
        GameHandler.gotWhiteTokens = GameHandler.gotWhiteTokens - 1;
		GameHandler.gotBlueTokens = GameHandler.gotBlueTokens - 1;
		GameHandler.gotAbility6 = GameHandler.gotAbility6 + 1;
		m_GameHandler.updateStatsDisplay();
		Debug.Log("A6 Created!");
    }
}
