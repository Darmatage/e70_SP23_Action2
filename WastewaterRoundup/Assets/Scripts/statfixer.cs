using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statfixer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		if (GameHandler.gotAbility1 == 0) {
			GameHandler.gotAbility1 = 3;
		}
		if (GameHandler.gotAbility2 == 0) {
			GameHandler.gotAbility2 = 3;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
