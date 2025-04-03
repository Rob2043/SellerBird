using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialGame : MonoBehaviour
{
    [SerializeField] private MapGenerator mapGenerator;
    [SerializeField] private MovingPlayer player;
    [SerializeField] private GameMenu gameMenu;
    private void Awake()
    {
        player.Init();
        mapGenerator.Init();
        gameMenu.Init();
    }
}
