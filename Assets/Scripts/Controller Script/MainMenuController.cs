using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
   public void PlayGame() {
       Application.LoadLevel("LevelMenu");
   }

   public void BackToMenuButton() {
       Application.LoadLevel("MainMenu");
   }

   public void PlayGameLevel() {
       Application.LoadLevel("PlayMenu");
   }
}
