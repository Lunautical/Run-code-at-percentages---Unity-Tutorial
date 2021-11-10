using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    /// <summary>
    /// Created by Lunautical
    /// Definitely could be done much better, but should still work with whatever you want to achieve.
    /// Check out my YouTube channel: https://www.youtube.com/channel/UChbMcWryfyjrzpT1p74_lcw
    /// </summary>

    //Health values
    private float health;
    public float maxHealth;

    //Text component
    public Text healthTxt;


    private void Start()
    {
        //Set health to the max health
        health = maxHealth;
        //Update the text UI
        healthTxt.text = "Health: " + health.ToString();
    }

    private void Update()
    {
        //Lower Health
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(health > 0)
            {
                //Temp variables sent to the HealthPercentage() method
                float previousHealth = health;
                bool healthIncrease = false;
                //Decrease the health
                health -= 5;
                //Update UI
                UpdateHealth();
                //Call the Percentage Method
                HealthPercentage(previousHealth, healthIncrease);
            }
        }
        //Increase Health
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(health < maxHealth)
            {
                //Temp variables sent to the HealthPercentage() method
                float previousHealth = health;
                bool healthIncrease = true;
                //Increase the health
                health += 5;
                //Update the UI
                UpdateHealth();
                //Call the Percentage Method
                HealthPercentage(previousHealth, healthIncrease);
            }
        }
    }

    //Just updates the UI when called
    private void UpdateHealth()
    {
        healthTxt.text = "Health: " + health.ToString();
    }

    //Bulk of the script, determines percentage and runs code if milestone reached
    private void HealthPercentage(float preHealth, bool healthIncrease)
    {
        //Preset percentages, will also work if maxHealth changes
        float oneForth = maxHealth * 0.25f;
        float oneHalf = maxHealth * 0.5f;
        float threeForth = maxHealth * 0.75f;

        //If the health increased
        if (healthIncrease)
        {
            if(preHealth < oneForth)
            {
                if(health >= oneForth)
                {
                    Debug.Log("Do stuff (1/4)");
                }
            }
            else if(preHealth < oneHalf)
            {
                if(health >= oneHalf)
                {
                    Debug.Log("Do stuff (1/2)");
                }
            }
            else if(preHealth < threeForth)
            {
                if(health >= threeForth)
                {
                    Debug.Log("Do stuff (3/4)");
                }
            }
            else if(preHealth < maxHealth)
            {
                if(health >= maxHealth)
                {
                    Debug.Log("Do stuff (1)");
                }
            }
        }
        //If the health decreased
        if (!healthIncrease)
        {
            if(preHealth > threeForth)
            {
                if(health <= threeForth)
                {
                    Debug.Log("Do stuff (3/4)");
                }
            }
            else if(preHealth > oneHalf)
            {
                if(health <= oneHalf)
                {
                    Debug.Log("Do stuff (1/2)");
                }
            }
            else if(preHealth > oneForth)
            {
                if(health <= oneForth)
                {
                    Debug.Log("Do stuff (1/4)");
                }
            }
        }
    }
}
