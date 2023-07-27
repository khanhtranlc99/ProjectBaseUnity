using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.Advertisements;
//using admob;
//using Heyzap;
//using StartApp;

public class Levels : MonoBehaviour {

	public static Levels instance;
	public int loadedlevel;

	public bool levelComplete;
	public GameObject[] obstacles;
	public Text completeText;
	public Text TargetText;
    public GameObject PausePanel, instPanel, LevelButton, loading;

	public Material[] blocks;

	public Image SoundImage;
	public Sprite soundOn;
	public Sprite soundOff;
	public static bool mainclicked;

	void Awake () {
		
		loadedlevel = PlayerPrefs.GetInt ("level1");
		TargetText.text = PlayerPrefs.GetString ("target");
		levelComplete = false;


	}

	public bool adbool;
	void Start()
	{
        AudioListener.pause = false;
		instance = this;
		levelLoad ();
//		ColorChanger();
		if (PlayerPrefs.GetInt ("Touch") == 1) 
		{
			FindObjectOfType<PlayerControl> ().inputMode = PlayerControl.MobileInputMode.Touch;

			if (PlayerPrefs.HasKey ("ReadInstruction")) {
				instPanel.SetActive (false);
				Time.timeScale = 1;
			} else {

				instPanel.SetActive (true);
				Time.timeScale = 0;
			}
		}
		if (PlayerPrefs.GetInt ("acc") == 1) 
		{
			FindObjectOfType<PlayerControl> ().inputMode = PlayerControl.MobileInputMode.Accelerometer;
		}

		adbool = true;


		if (!PlayerPrefs.HasKey ("GameVolume")) {
			PlayerPrefs.SetInt ("GameVolume", 0);

		} else if
			(PlayerPrefs.GetInt ("GameVolume") == 0) {
			AudioListener.volume = 1;
			SoundImage.sprite = soundOn;
		}

		else

		{
			AudioListener.volume = 0;
			SoundImage.sprite = soundOff;

		}

		//Advertisement.Initialize ("1630724");

		//HeyzapAds.Start ("e6e1a383edb894bb8a3968d231b51363", HeyzapAds.FLAG_NO_OPTIONS);
		//HZInterstitialAd.Fetch ();

		//Admob.Instance ().initAdmob ("ca-app-pub-7178974598002163/4397795969","ca-app-pub-7178974598002163/5655693856");
		//Admob.Instance ().loadInterstitial ();

		//Admob.Instance ().showBannerRelative (AdSize.Banner, AdPosition.BOTTOM_CENTER,0,"gameplay" );



	}

	void Update()
	{
		if (levelComplete == false) {
			LevelEnd ();
		}
	}
		public void levelLoad()
		{
			if (loadedlevel == 1) {

				PlayerControl.instance.speed = 50.0f;
			foreach (var item in blocks) {
				item.color = Color.Lerp (Color.blue, Color.green, .5f);
			}

				obstacles [5].SetActive (false);
				obstacles [6].SetActive (false);
			}

			else if (loadedlevel == 2) 
			{

				PlayerControl.instance.speed = 60.0f;

			foreach (var item in blocks) {
				item.color = Color.Lerp (Color.green, Color.red, .8f);
			}

				obstacles [2].GetComponent<RandomSection> ().length = 10;
				obstacles [7].GetComponent<RandomSection> ().length = 13;
			}
			else if (loadedlevel == 3) 
			{

				PlayerControl.instance.speed = 70.0f;
			foreach (var item in blocks) {
				item.color = Color.Lerp (Color.green, Color.yellow, .5f);
			}

				obstacles [3].SetActive (true);
				obstacles [2].GetComponent<RandomSection> ().length = 13;
				obstacles [7].GetComponent<RandomSection> ().length = 13;
			}

			else if (loadedlevel == 4) 
			{

				PlayerControl.instance.speed = 80.0f;
			foreach (var item in blocks) {
				item.color = Color.Lerp (Color.magenta, Color.yellow, .5f);
			}

				obstacles [3].SetActive (true);
				obstacles [8].SetActive (true);

				obstacles [2].GetComponent<RandomSection> ().length = 10;
				obstacles [7].GetComponent<RandomSection> ().length = 13;
				obstacles [8].GetComponent<RandomSection> ().length = 3;
			}
			else if (loadedlevel == 5) 
			{

				PlayerControl.instance.speed = 90.0f;
			foreach (var item in blocks) {
				item.color = Color.Lerp (Color.cyan, Color.yellow, .3f);
			}

				obstacles [3].SetActive (true);
				obstacles [8].SetActive (true);

				obstacles [2].GetComponent<RandomSection> ().length = 10;
				obstacles [6].GetComponent<ConstantSection> ().length = 5;
				obstacles [3].GetComponent<RandomSection> ().length = 6;
				obstacles [7].GetComponent<RandomSection> ().length = 13;
				obstacles [8].GetComponent<RandomSection> ().length = 5;
			}
			else if (loadedlevel == 6) 
			{

				PlayerControl.instance.speed = 100.0f;
			foreach (var item in blocks) {
				item.color = Color.Lerp (Color.cyan, Color.blue, .5f);
			}

				obstacles [3].SetActive (true);
				obstacles [8].SetActive (true);
				obstacles [10].SetActive (true);
				obstacles [11].SetActive (true);

				obstacles [1].GetComponent<RandomSection> ().length = 15;
				obstacles [2].GetComponent<RandomSection> ().length = 10;
				obstacles [3].GetComponent<RandomSection> ().length = 6;
				obstacles [6].GetComponent<ConstantSection> ().length = 5;
				obstacles [7].GetComponent<RandomSection> ().length = 7;
				obstacles [8].GetComponent<RandomSection> ().length = 5;
			}
			else if (loadedlevel == 7) 
			{

				PlayerControl.instance.speed = 102.0f;
			foreach (var item in blocks) {
				item.color = Color.Lerp (Color.red, Color.gray, .6f);
			}


				obstacles [3].SetActive (true);
				obstacles [8].SetActive (true);
				obstacles [10].SetActive (true);
				obstacles [11].SetActive (true);

				obstacles [1].GetComponent<RandomSection> ().length = 15;
				obstacles [2].GetComponent<RandomSection> ().length = 10;
				obstacles [3].GetComponent<RandomSection> ().length = 6;
				obstacles [6].GetComponent<ConstantSection> ().length = 5;
				obstacles [7].GetComponent<RandomSection> ().length = 13;
				obstacles [8].GetComponent<RandomSection> ().length = 8;
				obstacles [11].GetComponent<RandomSection> ().length = 6;


			}

			else if (loadedlevel == 8) 
			{

				PlayerControl.instance.speed = 103.0f;

			foreach (var item in blocks) {
				item.color = Color.Lerp (Color.yellow, Color.black, .6f);
			}

				obstacles [3].SetActive (true);
				obstacles [8].SetActive (true);
				obstacles [10].SetActive (true);
				obstacles [11].SetActive (true);

				obstacles [1].GetComponent<RandomSection> ().length = 20;
				obstacles [2].GetComponent<RandomSection> ().length = 15;
				obstacles [3].GetComponent<RandomSection> ().length = 15;
				obstacles [6].GetComponent<ConstantSection> ().length = 5;
				obstacles [7].GetComponent<RandomSection> ().length = 20;
				obstacles [8].GetComponent<RandomSection> ().length = 10;
				obstacles [11].GetComponent<RandomSection> ().length = 10;


			}


			else if (loadedlevel == 9) 
			{

				PlayerControl.instance.speed = 103.0f;
			foreach (var item in blocks) {
				item.color = Color.Lerp (Color.blue, Color.green, .5f);
			}

			obstacles [3].SetActive (true);
			obstacles [8].SetActive (true);
			obstacles [10].SetActive (true);
			obstacles [11].SetActive (true);

			obstacles [1].GetComponent<RandomSection> ().length = 20;
			obstacles [2].GetComponent<RandomSection> ().length = 15;
			obstacles [3].GetComponent<RandomSection> ().length = 15;
			obstacles [6].GetComponent<ConstantSection> ().length = 5;
			obstacles [7].GetComponent<RandomSection> ().length = 20;
			obstacles [8].GetComponent<RandomSection> ().length = 10;
			obstacles [11].GetComponent<RandomSection> ().length = 10;


			}
			else if (loadedlevel == 10) 
			{

				PlayerControl.instance.speed = 105.0f;
			foreach (var item in blocks) {
				item.color = Color.Lerp (Color.green, Color.red, .8f);
			}

				obstacles [3].SetActive (true);
				obstacles [8].SetActive (true);
				obstacles [10].SetActive (true);
				obstacles [11].SetActive (true);

				obstacles [1].GetComponent<RandomSection> ().length = 25;
				obstacles [2].GetComponent<RandomSection> ().length = 15;
				obstacles [3].GetComponent<RandomSection> ().length = 20;
				obstacles [6].GetComponent<ConstantSection> ().length = 5;
				obstacles [7].GetComponent<RandomSection> ().length = 25;
				obstacles [8].GetComponent<RandomSection> ().length = 10;
				obstacles [11].GetComponent<RandomSection> ().length = 10;


			}


		}

	void LevelEnd()
	{
		if (LevelManager.instance.currentSection == LevelManager.instance.levelSections.Length-1) 
		{

			//Debug.Log ("LevelCompleted");
			//completeText.text = "Level Completed";
			////Time.timeScale = 0;

			//PlayerControl.instance.isInvincible = true;
			//levelUnlock ();
			//levelComplete = true;
			//LevelButton.SetActive (true);

			//obstacles [13].GetComponent<ConstantSection> ().isInfinite = true;
			//GameManager.instance.GameOver ();
			//levelComplete = true;
			////Admob.Instance ().removeBanner ("gameplay");
			////Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT,0,"cmpl1" );

			////if (Advertisement.IsReady ()) {
			////	Advertisement.Show ();
			////	adbool = false;
			////} else if (HZInterstitialAd.IsAvailable ()) {
			////	HZInterstitialAd.Show ();
			////	HZInterstitialAd.Fetch ();
			////	adbool = false;
			////} else {
			////	StartAppWrapper.showAd ();
			////	StartAppWrapper.loadAd ();
			////	adbool = false;
			////}
			//Debug.LogError("Win");
		}			

	}

	public void levelUnlock()
	{
		if (PlayerPrefs.GetInt ("level1") == 1)
			PlayerPrefs.SetInt ("Race2", 1);
		else if (PlayerPrefs.GetInt ("level1") == 2)
			PlayerPrefs.SetInt ("Race3", 1);
		else if (PlayerPrefs.GetInt ("level1") == 3)
			PlayerPrefs.SetInt ("Race4", 1);
		else if (PlayerPrefs.GetInt ("level1") == 4)
			PlayerPrefs.SetInt ("Race5", 1);
		else if (PlayerPrefs.GetInt ("level1") == 5)
			PlayerPrefs.SetInt ("Race6", 1);
		else if (PlayerPrefs.GetInt ("level1") == 6)
			PlayerPrefs.SetInt ("Race7", 1);
		else if (PlayerPrefs.GetInt ("level1") == 7)
			PlayerPrefs.SetInt ("Race8", 1);
		else if (PlayerPrefs.GetInt ("level1") == 8)
			PlayerPrefs.SetInt ("Race9", 1);
		else if (PlayerPrefs.GetInt ("level1") == 9)
			PlayerPrefs.SetInt ("Race10", 1);
	}

	public void restartLevel()
	{
		//Admob.Instance ().removeBanner ("gameplay");
		//Admob.Instance ().removeBanner ("pause2");

		//Admob.Instance ().removeBanner ("fail1");

		//Admob.Instance ().removeBanner ("cmpl1");
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

	}

	public void Levelselect()
	{
		//Admob.Instance ().removeBanner ("pause2");

		//Admob.Instance ().removeBanner ("fail1");

		//Admob.Instance ().removeBanner ("cmpl1");

		//Admob.Instance ().removeBanner ("gameplay");
		SceneManager.LoadScene ("LevelSelection");
        AudioListener.pause = true;
        GameDistribution.Instance.ShowAd();
	}

	public void MainMenu()
	{
		mainclicked = true;
		//Admob.Instance ().removeBanner ("pause2");

		//Admob.Instance ().removeBanner ("fail1");

		//Admob.Instance ().removeBanner ("cmpl1");

		//Admob.Instance ().removeBanner ("gameplay");

		SceneManager.LoadScene ("MainMenu");
        AudioListener.pause = true;
        GameDistribution.Instance.ShowAd();

	
	}

	public void EnableSound(){

		if(PlayerPrefs.GetInt("GameVolume") == 0)
		{
			PlayerPrefs.SetInt("GameVolume", 1);
			AudioListener.volume = 0;
			SoundImage.sprite = soundOff;

		}
		else

		{
			PlayerPrefs.SetInt("GameVolume", 0);
			AudioListener.volume = 1;
			SoundImage.sprite = soundOn;

		}

	}
	public void Pause()
	{
		
		PausePanel.SetActive (true);
		Time.timeScale = 0;
        AudioListener.pause = true;
        GameDistribution.Instance.ShowAd();
		//Admob.Instance ().removeBanner ("gameplay");
		//Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT,0,"pause2" );

	if (adbool) {

		//if (Advertisement.IsReady ()) {
		//	Advertisement.Show ();
		//	adbool = false;
		//} else if (HZInterstitialAd.IsAvailable ()) {
		//	HZInterstitialAd.Show ();
		//	HZInterstitialAd.Fetch ();
		//	adbool = false;
		//} else {
		//	StartAppWrapper.showAd ();
		//	StartAppWrapper.loadAd ();
		//	adbool = false;
		//}
	}

	}


	public void Resume()
	{
		Time.timeScale = 1;
		//Admob.Instance ().showBannerRelative (AdSize.Banner, AdPosition.BOTTOM_CENTER,0,"gameplay" );
		//Admob.Instance ().removeBanner ("pause2");

		PausePanel.SetActive (false);
        AudioListener.pause = false;
	}
	public void OKClick()
	{
		instPanel.SetActive (false);
		Time.timeScale = 1;
		PlayerPrefs.SetString ("ReadInstruction", "readed");
	}
}