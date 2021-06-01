using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingPlairForInsertData : MonoBehaviour
{
    public static int inputSpeed = 0;
    public void Shift(int insert)
    {
        inputSpeed = insert;
    }
}
