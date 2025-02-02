﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    /// <summary>
    /// This class is used by many other scripts to save produts' data.
    /// </summary>
    
    public string Name;
    public enum EGenre { Adventure, FPS, Horror, Platformer, RPG, Simulation, Sports};
    public EGenre Genre;
    public float Price;
    public float InvestedAmount;
    
    public float DayCreated;

    public float GamePlay;
    public float Graphics;
    public float Dialogue;
    public float GameDesign;
    public float Ai;
    public float Audio;
    public float WorldDesign;

    public float QualityOfTheProduct;

}

