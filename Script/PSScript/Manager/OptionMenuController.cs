using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuController : MonoBehaviour
{
    public GameObject ButtonHandeler;
    public void Accumalator(bool input)
    {
        PlainFighterPlayer.Accumalator = input;
        ButtonHandeler.SetActive(!input);
        
    }
}
