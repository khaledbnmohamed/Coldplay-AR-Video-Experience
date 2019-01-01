using UnityEngine;
using System.Collections;

public class UMG_SceneOptions : MonoBehaviour {

    void Awake()
    {
        GetInfoOptions();
    }

    /// <summary>
    /// Get saved info
    /// </summary>
    void GetInfoOptions()
    {
        int CurrentQuality = 0;
        int CurrentAS = 0;
        int CurrentBW = 0;
        int CurrentAA = 0;
        int CurrentVSC = 0;

        if (PlayerPrefs.HasKey(UMGKeys.Quality)) { CurrentQuality = PlayerPrefs.GetInt(UMGKeys.Quality); } else { CurrentQuality = QualitySettings.GetQualityLevel(); }
        if (PlayerPrefs.HasKey(UMGKeys.AnisoStropic)) { CurrentAS = PlayerPrefs.GetInt(UMGKeys.AnisoStropic); }
        if (PlayerPrefs.HasKey(UMGKeys.AntiAliasing)) { CurrentAA = PlayerPrefs.GetInt(UMGKeys.AntiAliasing); }
        if (PlayerPrefs.HasKey(UMGKeys.BlendWeight)) { CurrentBW = PlayerPrefs.GetInt(UMGKeys.BlendWeight); }
        if (PlayerPrefs.HasKey(UMGKeys.VSync)) { CurrentVSC = PlayerPrefs.GetInt(UMGKeys.VSync); }
        if (PlayerPrefs.HasKey(UMGKeys.Volumen)) { AudioListener.volume = PlayerPrefs.GetFloat(UMGKeys.Volumen); }

        QualitySettings.SetQualityLevel(CurrentQuality);
        switch (CurrentAS)
        {
            case 0:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                break;
            case 1:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
                break;
            case 2:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                break;
        }
        //
        switch (CurrentAA)
        {
            case 0:
                QualitySettings.antiAliasing = 0;
                break;
            case 1:
                QualitySettings.antiAliasing = 2;
                break;
            case 2:
                QualitySettings.antiAliasing = 4;
                break;
            case 3:
                QualitySettings.antiAliasing = 8;
                break;
        }
        //
        switch (CurrentVSC)
        {
            case 0:
                QualitySettings.vSyncCount = 0;
                break;
            case 1:
                QualitySettings.vSyncCount = 1;
                break;
            case 2:
                QualitySettings.vSyncCount = 2;
                break;
        }
        //
        switch (CurrentBW)
        {
            case 0:
                QualitySettings.blendWeights = BlendWeights.OneBone;
                break;
            case 1:
                QualitySettings.blendWeights = BlendWeights.TwoBones;
                break;
            case 2:
                QualitySettings.blendWeights = BlendWeights.FourBones;
                break;
        }
    }
}