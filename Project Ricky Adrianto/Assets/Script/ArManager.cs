using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArManager : MonoBehaviour
{
    [SerializeField] private FishData[] fishData;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject descriptionImage;
    private AudioClip audioClip;
    private int choiceFoundation;
    public int lenguageID;
    private bool isMusicPlaying = false; // Menandakan apakah musik sedang diputar

    // Start is called before the first frame update
    void Start()
    {
        // mengambil penyimpanan data
        choiceFoundation = PlayerPrefs.GetInt("ChoiceFoundation"); 
        lenguageID = PlayerPrefs.GetInt("LocaleKey");
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
        titleText.text = fishData[choiceFoundation].namaIkan;
        descriptionText.text = fishData[choiceFoundation].deskripsiIkan;
        audioClip = fishData[choiceFoundation].suaraPenjelasanIkan;
    }

    void DisplayDescriptionFoundationEN() // fungsi menampilkan bahasa inggirs
    {
        titleText.text = fishData[choiceFoundation].fishName;
        descriptionText.text = fishData[choiceFoundation].fishDescription;
        audioClip = fishData[choiceFoundation].fishSoundDescription;
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
    public void ToggleDescription() // fungsi untuk menampilkan deskripsi
    {
        if (descriptionImage.activeSelf) // Periksa apakah descriptionImage sedang aktif
        {
            descriptionImage.SetActive(false); // Jika aktif, nonaktifkan
        }
        else
        {
            descriptionImage.SetActive(true); // Jika tidak aktif, aktifkan
        }
    }
}
