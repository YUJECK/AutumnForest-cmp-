using UnityEngine;

namespace AutumnForest
{
    static public class GameManager 
    {
        static private PlayerController player;
        static public PlayerController Player => player;

        static public void SetPlayer(PlayerController newPlayer)
        {
            if(player != null)
            {
                GameObject.Destroy(player.gameObject);
                return;
            }
            player = newPlayer;
        }
    }
}