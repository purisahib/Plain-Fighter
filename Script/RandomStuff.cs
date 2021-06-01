using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomStuff : MonoBehaviour
{
   public Text largeText;

   public void BtnAction()
   {
       //largeText.text = "Hi-There";
       //PickRandomNumber(6);
       //PickRandomFromList();
       CreateRandomString();
   }
   private void PickRandomNumber(int maxInt)
   {
       int randomNum = Random.Range(1, maxInt+1);
       largeText.text = randomNum.ToString();
   }
   private void PickRandomFromList()
   {
       string[] students = new string[] {"Harry", "Rhan", "Ram"};
       string randomName = students[Random.Range(0, students.Length)]; 
       largeText.text = randomName;
   }
   private void CreateRandomString(int stringLength = 10)
   {
       int _stringLength = stringLength - 1;
       string randomString = "";
       string[] characters = new string[] {"a", "b", "c", "d", "e"};
       for (int i = 0; i <= _stringLength; i++)
       {
           randomString = randomString + characters[Random.Range(0, characters.Length)];
       }
       largeText.text = randomString;
   }
}
