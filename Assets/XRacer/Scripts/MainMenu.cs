using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using StartApp;
//using admob;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {


	public GameObject Buttons;
	public GameObject Settings,LoadingPanel;

	public Image SoundImage;
	public Sprite soundOn;
	public Sprite SoundOff;

	bool once,once1;
	float timer;
	void Start () {


		if (!PlayerPrefs.HasKey ("GameVolume")) {
			PlayerPrefs.SetInt ("GameVolume", 0);
		} else if (PlayerPrefs.GetInt ("GameVolume") == 0) {
			AudioListener.volume = 1;
			SoundImage.sprite = soundOn;
		} else {
			AudioListener.volume = 0;
			SoundImage.sprite = SoundOff;
		}

		Time.timeScale = 1f;
		once = true;
		once1 = true;
		timer = 5.0f;
		//Admob.Instance ().initAdmob ("ca-app-pub-7178974598002163/4397795969", "ca-app-pub-7178974598002163/5655693856");
		//Admob.Instance ().loadInterstitial ();

	}

	void Update () {
		if (timer > 0)
		{
			timer -= Time.deltaTime;
			LoadingPanel.SetActive (true);

			if (once) {
				//Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.MIDDLE_LEFT,0,"banner2");

				once = false;
			}
			if (Levels.mainclicked) {
				//if (Admob.Instance ().isInterstitialReady ()) {

				//	Admob.Instance ().showInterstitial ();
				//	Admob.Instance ().loadInterstitial ();
				//	Levels.mainclicked = false;
				//}


			}
		}

		if (timer <= 0) {

			if (once1) {
				//Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_LEFT,0,"playpanelbanner");
				once1 = false;
			}
			//Admob.Instance ().removeBanner ("banner2");

			LoadingPanel.SetActive (false);
		}

	}

	public void EnableSound()
	{
		if(PlayerPrefs.GetInt("GameVolume") == 0)
		{
			PlayerPrefs.SetInt("GameVolume", 1);
			AudioListener.volume = 0;
			SoundImage.sprite = SoundOff;

		}
		else

		{
			PlayerPrefs.SetInt("GameVolume", 0);
			AudioListener.volume = 1;
			SoundImage.sprite = soundOn;

		}
	}

	public void Touch()
	{
		PlayerPrefs.SetInt ("Touch", 1);
		PlayerPrefs.SetInt ("acc", 0);
	}
	public void Accelerometer()
	{
		PlayerPrefs.SetInt ("acc", 1);
		PlayerPrefs.SetInt ("Touch", 0);
	}



	public void OnButtonPress(string button)
	{
		switch (button) {
		case "Play":
			//Admob.Instance ().removeBanner ("playpanelbanner");
			SceneManager.LoadScene ("Select");
                AudioListener.pause = true;
                GameDistribution.Instance.ShowAd();
			break;

		case "Settings":
			//Admob.Instance ().removeBanner ("playpanelbanner");
			//Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.MIDDLE_RIGHT,0,"Set");
			Settings.SetActive (true);
			Buttons.SetActive (false);
			break;

		case "BackFromSettings":
			//Admob.Instance ().removeBanner ("Set");
			Settings.SetActive(false);
			Buttons.SetActive(true);
			break;

		case "RateUs":
			Application.OpenURL ("https://gamedistribution.com/games?company=zuma%20studio");

			break;


		case "MoreGames":
			Application.OpenURL ("https://gamedistribution.com/games?company=zuma%20studio");
			break;


		case "PrivacyPolicy":
			Application.OpenURL ("https://gamedistribution.com/games?company=zuma%20studio");
			break;
		}
	}

}
