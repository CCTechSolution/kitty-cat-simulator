using UnityEngine;
using System.Collections;



public class SoundManager : Singleton<SoundManager> {

	const string PlayerPrefs_KEY = "sounds_settings_key";
	public AudioClip _defaultBGClip = null;

	private bool _soundEnabled = true;
	private bool _effectEnabled = true;
	private bool _musicEnabled = true;
	public AudioSource _BGAudioSource;
	public AudioSource _FGAudioSource;
	private float _effectsVolume = 0;
	private float _musicVolume = 0;


    void Awake()
    {
        _FGAudioSource = gameObject.AddComponent<AudioSource>();
        _FGAudioSource.name = "(AudioSource)FG";
        _BGAudioSource = gameObject.AddComponent<AudioSource>();
        _BGAudioSource.name = "(AudioSource)BG";
        _soundEnabled = bool.Parse(PlayerPrefs.GetString(PlayerPrefs_KEY, _soundEnabled.ToString()));
		_BGAudioSource.volume = 0.1f;

	}

    public bool IsEffectsPlaying()
    {
        if (_FGAudioSource.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool EnableSounds {
		set { 
			_soundEnabled = value;
			_BGAudioSource.enabled = _soundEnabled;
			_FGAudioSource.enabled = _soundEnabled;
		}
		get { 
			return _soundEnabled;
		}
	}

	public bool MusicEnabled {
		set { 
			_soundEnabled = value;
			_BGAudioSource.enabled = _soundEnabled;
		}
		get { 
			return _soundEnabled;
		}
	}
	public bool EffectsEnabled {
		set { 
			_soundEnabled = value;
			_FGAudioSource.enabled = _soundEnabled;
		}
		get { 
			return _soundEnabled;
		}
	}

	public float EffectsVolume {
		set { 
			_effectsVolume = value;
			if (_effectsVolume < 0) {
				_effectsVolume = 0;
			}
			_FGAudioSource.volume = Mathf.Clamp01 (_effectsVolume);
		}
	}
	public float MusicVolume {
		set { 
			_musicVolume = value;
			if (_musicVolume < 0) {
				_musicVolume = 0;
			}
			_BGAudioSource.volume = Mathf.Clamp01 (_musicVolume);
		}
	}

	public AudioClip DefaultBGClip {
		set { 
			_defaultBGClip = value;
		}
		get { 
			return _defaultBGClip;
		}
	}
	

	public void Play ()
	{
		if (_defaultBGClip ==null) {
			Debug.LogWarning ("Default Audio Clip is required for SoundManager ");
			return;
		}
		PlayBackgroundMusic (_defaultBGClip);
	}


	public void PlayEffect (AudioClip _clip)
	{
		if (_soundEnabled & _clip != null) {
			_FGAudioSource.PlayOneShot (_clip);
		}
	}

	public void PlayVocal (AudioClip _clip)
	{
		if (_soundEnabled & _clip != null) {
			_FGAudioSource.Stop ();
			_FGAudioSource.clip = _clip;
			_FGAudioSource.Play ();
		}

	}
	public void PlayEffect(AudioClip _clip , bool status){
		_FGAudioSource.clip = _clip;
		_FGAudioSource.loop = status;
		_FGAudioSource.Play ();
	}
	public void StopEffect(AudioClip _clip){
		_FGAudioSource.Stop ();

	}

	public void PlayBackgroundMusic (AudioClip _clip)
	{
		if (_soundEnabled && _clip != null) {
			_BGAudioSource.clip = _clip;
			_BGAudioSource.loop = true;
			_BGAudioSource.Play ();
		}
	}
	public void StopBackgroundMusic(AudioClip _clip)
	{
		if (_soundEnabled && _clip != null)
		{
			_BGAudioSource.clip = _clip;
			_BGAudioSource.loop = false;
			_BGAudioSource.Stop();
		}
	}

	public void Pause ()
	{
		EnableSounds = false;
	}

	public void Resume ()
	{
		EnableSounds = true;
	}

	void PersistSetting ()
	{
		PlayerPrefs.SetString (PlayerPrefs_KEY, _soundEnabled.ToString ());
		PlayerPrefs.Save ();
	}

}
