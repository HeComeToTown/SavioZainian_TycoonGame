using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    ///<summary>
    /// This class performs the tutorial at the beginning of the game.
    /// </summary>
    
    [SerializeField] private GameObject Tutorialx1;
    [SerializeField] private GameObject Tutorialx2;
    [SerializeField] private GameObject Tutorialx3;
    [SerializeField] private GameObject Tutorialx4;
    [SerializeField] private GameObject Tutorialx5;
    [SerializeField] private GameObject Tutorialx6;
    [SerializeField] private GameObject Tutorialx7;
    [SerializeField] private GameObject Tutorialx8;
    [SerializeField] private GameObject Tutorialx9;
    [SerializeField] private GameObject Tutorialx10;
    [SerializeField] private GameObject Tutorialx11;

    [SerializeField] private GameObject Button;

    [SerializeField] private Button ProductsPannel;
    [SerializeField] private Button StatsPannel;

    [SerializeField] private Button Timex1;
    [SerializeField] private Button Timex2;
    [SerializeField] private Button Timex4;


    [SerializeField] private TimeSystem _timeSystem;

    private GameObject[] Tutorials = new GameObject[11];

    private bool isBussyWithTutorial = false;
    private bool isDoneWithTutorial = false;

    private void Start()
    {
        Tutorials[0] = Tutorialx1;
        Tutorials[1] = Tutorialx2;
        Tutorials[2] = Tutorialx3;
        Tutorials[3] = Tutorialx4;
        Tutorials[4] = Tutorialx5;
        Tutorials[5] = Tutorialx6;
        Tutorials[6] = Tutorialx7;
        Tutorials[7] = Tutorialx8;
        Tutorials[8] = Tutorialx9;
        Tutorials[9] = Tutorialx10;
        Tutorials[10] = Tutorialx11;



        _timeSystem.StartTutorial += TutorialStart;


    }
   
    //Sets the buttons to not be interavtable while the game tutorial is busy.
    private void Update()
    {
        if (isBussyWithTutorial == true)
        {
            ProductsPannel.interactable = false;
            StatsPannel.interactable = false;
            Timex1.interactable = false;
            Timex2.interactable = false;
            Timex4.interactable = false;
        }
        else
        {
            ProductsPannel.interactable = true;
            StatsPannel.interactable = true;
            Timex1.interactable = true;
            Timex2.interactable = true;
            Timex4.interactable = true;
        }

    }

    //Tutorial will only start at the beginning of the game.
    private void TutorialStart()
    {
        if (_timeSystem.daysPlayedTotal <= 0)
        {
            Button.SetActive(true);
            Tutorials[0].SetActive(true);
            isBussyWithTutorial = true;
            Time.timeScale = 0;
        }
        else
            return;
    }

    //For loop cannot be used here, as it gives null reference when used.
    public void ChangeTutorial()
    {
        int x = 0;
        isBussyWithTutorial = true;

        if (Tutorials[0].activeInHierarchy == true)
        {
            x = 0;
            //currency tutorial
        }
        else if (Tutorials[1].activeInHierarchy == true)
        {
            x = 1;
            //time of day tutorial
        }
        else if (Tutorials[2].activeInHierarchy == true)
        {
            x = 2;
            //currency per day tutorial
        }
        else if (Tutorials[3].activeInHierarchy == true)
        {
            x = 3;
            //current days tutorial
        }
        else if (Tutorials[4].activeInHierarchy == true)
        {
            x = 4;
            //stop time tutorial
        }
        else if (Tutorials[5].activeInHierarchy == true)
        {
            x = 5;
            //x1 tutorial
        }
        else if (Tutorials[6].activeInHierarchy == true)
        {
            x = 6;
            //x2 tutorial
        }
        else if (Tutorials[7].activeInHierarchy == true)
        {
            x = 7;
            //x4 tutorial
        }
        else if (Tutorials[8].activeInHierarchy == true)
        {
            x = 8;
            //stats panel tutorial
        }
        else if (Tutorials[9].activeInHierarchy == true)
        {
            x = 9;
            //prodcuts panel tutorial
        }
        else if (Tutorials[10].activeInHierarchy == true)
        {
            x = 10;
            isDoneWithTutorial = true;
            //final tutorial
        }

        if (isDoneWithTutorial == false)
        {
            int y = x + 1;
            Tutorials[x].SetActive(false);
            Tutorials[y].SetActive(true);
        }
        else
        {
            Tutorials[x].SetActive(false);
            Button.SetActive(false);
            isBussyWithTutorial = false;
            Time.timeScale = 1;
        }

    }
}
