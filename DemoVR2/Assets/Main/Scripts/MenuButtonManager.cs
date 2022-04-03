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
    /// Time that the closing/opening interaction will last
    /// </summary>
    public float timeToCloseMenu = 1f;

    public float minScaleForMenu = 0.001f;

    public float maxScaleForMenu = 1f;

    /// <summary>
    /// The state of the menu. At the start we want this closed
    /// </summary>
    private bool isMenuClosed = true;

    private RectTransform menuTransform;

    /// <summary>
    /// Method called when the button is selected to show the menu.
    /// This also hides the open menu and shows the close one
    /// </summary>
    public void OpenMenuButton()
    {
        StartCoroutine(CloseMenuSmoothly(false));
    }

    /// <summary>
    /// Method called when the button is selected to hide the menu
    /// </summary>
    public void CloseMenuButton()
    {
        StartCoroutine(CloseMenuSmoothly(true));
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

    /// <summary>
    /// Method enumerator called to smoothly transition the Menu.
    /// If is closing, the method will shrink the menu and close it.
    /// If it is opening (isClosing=false), then it will go back to the normale scale from small.
    /// </summary>
    /// <param name="isClosing">the parameter that say if it is shrinking or not</param>
    /// <returns> nothing, the return is used to  wait for the next frame and continue execution</returns>
    private IEnumerator CloseMenuSmoothly(bool isClosing)
    {
        if (menuTransform == null)
        {
            menuTransform = menuPanel.GetComponent<RectTransform>();
        }
        if (isClosing && !isMenuClosed)
        {
            while (menuTransform.localScale.x > minScaleForMenu)
            {
                menuTransform.localScale -=  Time.deltaTime/ timeToCloseMenu * Vector3.one;
                yield return null;
            }
            menuPanel.SetActive(false);
            //instead of this you could use just 1 button,
            //check a local state and just change the text of the button. I like the easy way, sorry
            openButton.SetActive(true);
            closeButton.SetActive(false);
            isMenuClosed = true;
        }
        if(!isClosing && isMenuClosed)
        {
            menuPanel.SetActive(true);
            menuTransform.localScale = Vector3.one*0.01f;
            while (menuTransform.localScale.x < maxScaleForMenu)
            {
                menuTransform.localScale +=  Time.deltaTime/ timeToCloseMenu * Vector3.one;
                yield return null;
            }
            menuTransform.localScale = Vector3.one;

            openButton.SetActive(false);
            closeButton.SetActive(true);
            isMenuClosed = false;
        }
    }
}
