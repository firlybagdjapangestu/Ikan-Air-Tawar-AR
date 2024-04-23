using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishMenuId : MonoBehaviour
{
    [SerializeField] private FishData fishData;
    [SerializeField] private TextMeshProUGUI fishName;
    [SerializeField] private TextMeshProUGUI fishDescription;
    [SerializeField] private Image fishImage;
    [SerializeField] private AudioSource audioSource;
    private AudioClip audioClip;
    public int lenguageID;
    private bool isMusicPlaying = false;

    void Start()
    {
        UpdateLenguage();
    }

    public void UpdateLenguage()
    {
        lenguageID = PlayerPrefs.GetInt("LocaleKey");
        fishImage.sprite = fishData.fishImage;
        if (lenguageID == 0)
        {
            DisplayDescriptionFoundationEN();
        }
        else
        {
            DisplayDescriptionFoundationID();
        }
    }

    void DisplayDescriptionFoundationID() // fungsi menampilkan bahasa indonesia
    {
        fishName.text = fishData.namaIkan;
        fishDescription.text = fishData.deskripsiIkan;
        audioClip = fishData.suaraPenjelasanIkan;
    }

    void DisplayDescriptionFoundationEN() // fungsi menampilkan bahasa inggirs
    {
        fishName.text = fishData.fishName;
        fishDescription.text = fishData.fishDescription;
        audioClip = fishData.fishSoundDescription;
    }

    public void ToggleMusic() // fungsi untuk mengeluarkan suara
    {
        if (isMusicPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.PlayOneShot(audioClip);
        }

        isMusicPlaying = !isMusicPlaying; // Mengubah status pemutaran musik
    }
}
