using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Simple class made to handle the fake menu in the demo scene
/// 
/// </summary>
public class MenuButtonManager : MonoBehaviour
{
    /// <summary>
    /// The menu panel gameobject. We need it to show the menu or hide it.
    /// The public means that can be edited in the editor 
    /// (the designer can choose the element wanted without having to touch the code)
    /// </summary>
    public GameObject menuPanel;

    /// <summary>
    /// The Open button game object. Used to show the button.
    /// </summary>
    public GameObject openButton;
    /// <summary>
    /// The Close button game object. Used to hide the button.
    /// </summary>
    public GameObject closeButton;

    /// <summary>
    /// Simple text UI element in which we'll add the a number after a string
    /// </summary>
    public TextMeshProUGUI textWithNumber;

    /// <summary>
    /// Default string. Being public, this can be changed in the editor directly by the designer.
    /// This is the string put before the number when a button is pressed.
    /// </summary>
    public string stringToShow = "Button pressed is:";


    /// <summary>
    /// Method called when the button is selected to show the menu.
    /// This also hides the open menu and shows the close one
    /// </summary>
    public void OpenMenuButton()
    {
        menuPanel.SetActive(true);
        openButton.SetActive(false);
        closeButton.SetActive(true);
    }

    /// <summary>
    /// Method called when the button is selected to hide the menu
    /// </summary>
    public void CloseMenuButton()
    {
        menuPanel.SetActive(false);
        //instead of this you could use just 1 button,
        //check a local state and just change the text of the button. I like the easy way, sorry
        openButton.SetActive(true);
        closeButton.SetActive(false);
    }

    /// <summary>
    /// Method called by the fake button in the menu. 
    /// It will just show at the center of the panel the string and the number selected
    /// </summary>
    /// <param name="number">the number configured in the editor</param>
    public void ButtonWithNumber(int number)
    {
        //this puts in the text UI element the string followed by the number configured in the editor.
        textWithNumber.text = stringToShow + number;
    }

}
