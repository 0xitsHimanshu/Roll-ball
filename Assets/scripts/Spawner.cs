using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform _spawnPointofPlayer;
    [SerializeField] GameObject[] CharacterPrefabs;
    
    void Awake()
    {
        int selectedIndex = PlayerPrefs.GetInt("SelectedItem");
        GameObject prefab = CharacterPrefabs[selectedIndex];
        GameObject clone = Instantiate(prefab, _spawnPointofPlayer.position,Quaternion.identity);
        
    }
}
