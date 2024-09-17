using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject chooseAnimalScreen;
    [SerializeField] private GameObject setFriendsScreen;
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private TMP_Dropdown animalSelectDropdown;
    [SerializeField] private TMP_InputField numberOfFriendsInput;
    
    // Start is called before the first frame update
    public void SubmitName()
    {
        playerNameInput.GetComponent<TMP_InputField>();
        MainManager.instance.playerName = playerNameInput.text;

        titleScreen.SetActive(false);
        chooseAnimalScreen.SetActive(true);
    }

    // Update is called once per frame
    public void SubmitAnimal()
    {
        animalSelectDropdown.GetComponent<TMP_Dropdown>();
        MainManager.instance.animalChoice = animalSelectDropdown.options[animalSelectDropdown.value].text;

        chooseAnimalScreen.SetActive(false);
        setFriendsScreen.SetActive(true);
    }

    public void StartGame()
    {
        numberOfFriendsInput.GetComponent<TMP_InputField>();
        MainManager.instance.spawnAmount = int.Parse(numberOfFriendsInput.text);
        
        SceneManager.LoadScene(1);
    }
}
