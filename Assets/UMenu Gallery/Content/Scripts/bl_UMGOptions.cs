using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class bl_UMGOptions: MonoBehaviour {

    public Text QualityText = null;
    private int CurrentQuality = 0;

    public Text AntiStropicText = null;
    private int CurrentAS = 0;

    public Text AntiAliasingText = null;
    private int CurrentAA = 0;
    private string[] AAOptions = new string[] { "X0", "X2", "X4", "X8" };

    public Text vSyncText = null;
    private int CurrentVSC = 0;
    private string[] VSCOptions = new string[] { "A Sky Full of Stars", "All I can think about is you"};

    public Text blendWeightsText = null;
    private int CurrentBW = 0;

    public Text ResolutionText;
    private int CurrentRS = 0;
    [Space(5)]
    public Slider VolumenSlider;


    void Start()
    {
        GetInfoOptions();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mas"></param>
    public void GameQuality(bool mas)
    {
        if (mas)
        {
            CurrentQuality = (CurrentQuality + 1) % QualitySettings.names.Length;
        }
        else
        {
            if (CurrentQuality != 0)
            {
                CurrentQuality = (CurrentQuality - 1) % QualitySettings.names.Length;
            }
            else
            {
                CurrentQuality = (QualitySettings.names.Length - 1);
            }
        }
        QualityText.text = QualitySettings.names[CurrentQuality];
        QualitySettings.SetQualityLevel(CurrentQuality);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="b"></param>
    public void AntiStropic(bool b)
    {
        if (b) { CurrentAS = (CurrentAS + 1) % 2; }
        else
        {
            if (CurrentAS != 0) { CurrentAS = (CurrentAS - 1) % 3; }
            else { CurrentAS = 2; }
        }

        switch (CurrentAS)
        {
            case 0:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                AntiStropicText.text = "All I can think about is You";
                break;
            case 1:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
                AntiStropicText.text = "A Sky Full of Stars";
                break;
         
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="b"></param>
    public void AntiAliasing(bool b)
    {
        CurrentAA = (b) ? (CurrentAA + 1) % 4 : (CurrentAA != 0) ?(CurrentAA - 1) % 4 : 3;
        AntiAliasingText.text = AAOptions[CurrentAA];
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
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="b"></param>
    /// VideoPlayer CHANGER
    public void VSyncCount(bool b)
    {
        CurrentVSC = (b) ? (CurrentVSC + 1) % 2 : (CurrentVSC != 0) ?  (CurrentVSC - 1) % 3 : 2;
        vSyncText.text = VSCOptions[CurrentVSC];
        switch (CurrentVSC)
        {
            case 0:
                QualitySettings.vSyncCount = 0;
                break;
            case 1:
                QualitySettings.vSyncCount = 1;
                break;
       
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="b"></param>
    public void blendWeights(bool b)
    {
        CurrentBW = (b) ? (CurrentBW + 1) % 3 : (CurrentBW != 0) ? (CurrentBW - 1) % 3 : 2;
        switch (CurrentBW)
        {
            case 0:
                QualitySettings.blendWeights = BlendWeights.OneBone;
                blendWeightsText.text = BlendWeights.OneBone.ToString();
                break;
            case 1:
                QualitySettings.blendWeights = BlendWeights.TwoBones;
                blendWeightsText.text = BlendWeights.TwoBones.ToString();
                break;
            case 2:
                QualitySettings.blendWeights = BlendWeights.FourBones;
                blendWeightsText.text = BlendWeights.FourBones.ToString();
                break;
        }
    }

    /// <summary>
    /// Change resolution of screen
    /// NOTE: this work only in build game, this not work in
    /// Unity Editor.
    /// </summary>
    /// <param name="b"></param>
    public void Resolution(bool b)
    {
        CurrentRS = (b) ? (CurrentRS + 1) % Screen.resolutions.Length : (CurrentRS != 0) ? (CurrentRS - 1) % Screen.resolutions.Length : Screen.resolutions.Length - 1;
        ResolutionText.text = Screen.resolutions[CurrentRS].width + " X " + Screen.resolutions[CurrentRS].height;
    }
    /// <summary>
    /// Update Volumen of game
    /// </summary>
    /// <param name="v"></param>
    public void UpdateVolumen(float v)
    {
        //Apply volumen
        AudioListener.volume = v;
    }

    /// <summary>
    /// Get saved info
    /// </summary>
    void GetInfoOptions()
    {
        if (PlayerPrefs.HasKey(UMGKeys.Quality)) { CurrentQuality = PlayerPrefs.GetInt(UMGKeys.Quality); } else { CurrentQuality = QualitySettings.GetQualityLevel(); }
        if (PlayerPrefs.HasKey(UMGKeys.AnisoStropic)) { CurrentAS = PlayerPrefs.GetInt(UMGKeys.AnisoStropic); }
        if (PlayerPrefs.HasKey(UMGKeys.AntiAliasing)) { CurrentAA = PlayerPrefs.GetInt(UMGKeys.AntiAliasing); }
        if (PlayerPrefs.HasKey(UMGKeys.BlendWeight)) { CurrentBW = PlayerPrefs.GetInt(UMGKeys.BlendWeight); }
        if (PlayerPrefs.HasKey(UMGKeys.VSync)) { CurrentVSC = PlayerPrefs.GetInt(UMGKeys.VSync); }
        if (PlayerPrefs.HasKey(UMGKeys.Resolution)) { CurrentRS = PlayerPrefs.GetInt(UMGKeys.Resolution); }
        if (PlayerPrefs.HasKey(UMGKeys.Volumen)) { AudioListener.volume = PlayerPrefs.GetFloat(UMGKeys.Volumen); }

        VolumenSlider.value = AudioListener.volume;
        QualityText.text = QualitySettings.names[CurrentQuality];
        //
        switch (CurrentAS)
        {
            case 0:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                AntiStropicText.text = AnisotropicFiltering.Disable.ToString();
                break;
            case 1:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
                AntiStropicText.text = AnisotropicFiltering.Enable.ToString();
                break;
            case 2:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                AntiStropicText.text = AnisotropicFiltering.ForceEnable.ToString();
                break;
        }
        //
        AntiAliasingText.text = AAOptions[CurrentAA];
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
        vSyncText.text = VSCOptions[CurrentVSC];
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
                blendWeightsText.text = BlendWeights.OneBone.ToString();
                break;
            case 1:
                QualitySettings.blendWeights = BlendWeights.TwoBones;
                blendWeightsText.text = BlendWeights.TwoBones.ToString();
                break;
            case 2:
                QualitySettings.blendWeights = BlendWeights.FourBones;
                blendWeightsText.text = BlendWeights.FourBones.ToString();
                break;
        }
        //
        ResolutionText.text = Screen.resolutions[CurrentRS].width + " X " + Screen.resolutions[CurrentRS].height;
    }

    /// <summary>
    /// Saved Options
    /// </summary>
    public void Apply()
    {
        PlayerPrefs.SetInt(UMGKeys.Quality, CurrentQuality);
        PlayerPrefs.SetInt(UMGKeys.AnisoStropic, CurrentAS);
        PlayerPrefs.SetInt(UMGKeys.AntiAliasing, CurrentAA);
        PlayerPrefs.SetInt(UMGKeys.VSync, CurrentVSC);
        PlayerPrefs.SetInt(UMGKeys.BlendWeight, CurrentBW);
        PlayerPrefs.SetInt(UMGKeys.Resolution, CurrentRS);
        PlayerPrefs.SetFloat(UMGKeys.Volumen, AudioListener.volume);
        Screen.SetResolution(Screen.resolutions[CurrentRS].width, Screen.resolutions[CurrentRS].height, true);
    }
}