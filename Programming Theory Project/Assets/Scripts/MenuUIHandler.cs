using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject chooseAnimalScreen;
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private TMP_Dropdown animalSelectDropdown;
    
    // Start is called before the first frame update
    public void SubmitName()
    {
        playerNameInput.GetComponent<TMP_InputField>();
        MainManager.instance.playerName = playerNameInput.text;
        Debug.Log(MainManager.instance.playerName);
        titleScreen.SetActive(false);
        chooseAnimalScreen.SetActive(true);
    }

    // Update is called once per frame
    public void SubmitAnimal()
    {
        animalSelectDropdown.GetComponent<TMP_Dropdown>();
        MainManager.instance.animalChoice = animalSelectDropdown.options[animalSelectDropdown.value].text;
        Debug.Log(MainManager.instance.animalChoice);
    }
}
