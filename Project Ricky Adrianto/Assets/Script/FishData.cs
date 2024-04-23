using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "Fish Data", order = 1)]
public class FishData : ScriptableObject
{
    public Sprite fishImage;
    public string fishName;
    [TextArea(3, 5)]
    public string fishDescription;
    public AudioClip fishSoundDescription;

    public string namaIkan;
    [TextArea(3, 5)]
    public string deskripsiIkan;
    public AudioClip suaraPenjelasanIkan;

    public GameObject fishPrefabs;
}
