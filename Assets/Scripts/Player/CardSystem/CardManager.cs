using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    public Button[] cardButtons; 

    public Sprite[] cardSprites; 

    private PlayerShooting playerShooting;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;
    
    private void Start()
    {
        playerShooting = FindObjectOfType<PlayerShooting>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerMovement = FindObjectOfType<PlayerMovement>();

        gameObject.SetActive(false); // Default Hide Card Panel
    }

    public void ShowCardPanel()
    {
        Time.timeScale = 0; // pause game
        gameObject.SetActive(true);

        // Create a list of available effects and fill in all effects
        List<int> availableEffects = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

        // Assign a random card effect and image to each button
        for (int i = 0; i < cardButtons.Length; i++)
        {
            int randomIndex = Random.Range(0, availableEffects.Count); 
            int selectedEffect = availableEffects[randomIndex];

            cardButtons[i].onClick.RemoveAllListeners(); // Remove all old listening events

            void LocalButtonFunction(int effect)
            {
                cardButtons[i].onClick.AddListener(() => ApplyEffect(effect));
            }
            LocalButtonFunction(selectedEffect);

            cardButtons[i].GetComponent<Image>().sprite = cardSprites[selectedEffect - 1]; // set button sprites
            
            availableEffects.RemoveAt(randomIndex); 
        }
    }


    public void ApplyEffect(int effectId)
    {
        switch (effectId)
        {
            case 1:
                playerHealth.Heal(3);
                break;
            case 2:
                playerShooting.multipleShotsCount++;
                break;
            case 3:
                playerShooting.spreadShotCount+=2;
                break;
            case 4:
                playerMovement.speed++;
                break;
            case 5:
                playerShooting.HomingShotsCount++; 
                break;
            case 6:
                
                playerMovement.dashDistance++;
                break;
            case 7:
                playerHealth.StartInvincibility(10f);
                break;
                
        }

        gameObject.SetActive(false); // hide card panel
        Time.timeScale = 1; // continue game
    }
}
