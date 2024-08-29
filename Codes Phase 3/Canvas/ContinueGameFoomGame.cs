using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGameFoomGame : MonoBehaviour
{
   public Player player;
  
  
  
  private void Awake()
  {
            if (ContinueGame.instance.ContinueGameBool)
            {
                player.LoadPlayer();
            }
            else
            {
                player.SavePlayer();
            }
  }

}
