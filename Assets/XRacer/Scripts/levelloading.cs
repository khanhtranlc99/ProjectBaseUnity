using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.Advertisements;
//using admob;


public class levelloading : MonoBehaviour {

	// Use this for initialization
	public GameObject loading, controlsPanel;
	public GameObject L2, L3, L4, L5, L6, L7, L8,L9, L10;
	public GameObject L2B, L3B, L4B, L5B, L6B, L7B, L8B,L9B, L10B;

	void Start(){
		Time.timeScale = 1;
		UpdateMenu ();

		//Advertisement.Initialize ("1630724");
		//Admob.Instance ().initAdmob ("ca-app-pub-7178974598002163/4397795969","ca-app-pub-7178974598002163/5655693856");
		//Admob.Instance ().loadInterstitial ();
		//Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "level");

	}


	void UpdateMenu(){
		if (PlayerPrefs.GetInt ("Race2") == 1) {
			L2.SetActive (false);
			L2B.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Race3") == 1) {
			L3.SetActive (false);
			L3B.SetActive (true);	
		}
		if (PlayerPrefs.GetInt ("Race4") == 1) {
			L4.SetActive (false);
			L4B.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Race5") == 1) 
		{
			L5.SetActive (false);
			L5B.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Race6") == 1) {
			L6.SetActive (false);
			L6B.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Race7") == 1) {
			L7.SetActive (false);
			L7B.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Race8") == 1) {
			L8.SetActive (false);
			L8B.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Race9") == 1) {
			L9.SetActive (false);
			L9B.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Race10") == 1) {
			L10.SetActive (false);
			L10B.SetActive (true);
		}
	}

	public void Touch()
	{
		PlayerPrefs.SetInt ("Touch", 1);
		PlayerPrefs.SetInt ("acc", 0);
		loadingPanel ();
		Invoke ("loadScene", 5f);
	}
	public void Accelerometer()
	{
		PlayerPrefs.SetInt ("acc", 1);
		PlayerPrefs.SetInt ("Touch", 0);
		loadingPanel ();
		Invoke ("loadScene", 5f);
	}

	public void BackButton()
	{
		
		//Admob.Instance ().removeBanner ("level");
		SceneManager.LoadScene ("Select");
	}

	public void level1()
	{
		PlayerPrefs.SetInt ("level1", 1);
		PlayerPrefs.SetString ("target", "1860");
		controlsPanel.SetActive (true);
	}

	public void level2()
	{
		PlayerPrefs.SetInt ("level1", 2);
		PlayerPrefs.SetString ("target", "2630");
		controlsPanel.SetActive (true);
	}

	public void level3()
	{
		PlayerPrefs.SetInt ("level1", 3);
		PlayerPrefs.SetString ("target", "3015");
		controlsPanel.SetActive (true);
	}
	public void level4()
	{
		PlayerPrefs.SetInt ("level1", 4);
		PlayerPrefs.SetString ("target", "3015");
		controlsPanel.SetActive (true);
	}
	public void level5()
	{
		PlayerPrefs.SetInt ("level1", 5);
		PlayerPrefs.SetString ("target", "3460");
		controlsPanel.SetActive (true);
	}

	public void level6()
	{
		PlayerPrefs.SetString ("target", "5255");
		PlayerPrefs.SetInt ("level1", 6);
		controlsPanel.SetActive (true);
	}

	public void level7()
	{
		PlayerPrefs.SetInt ("level1", 7);
		PlayerPrefs.SetString ("target", "6085");
		controlsPanel.SetActive (true);
	}
	public void level8()
	{
		PlayerPrefs.SetInt ("level1", 8);
		PlayerPrefs.SetString ("target", "8235");
		controlsPanel.SetActive (true);
	}
	public void level9()
	{
		PlayerPrefs.SetInt ("level1", 9);
		PlayerPrefs.SetString ("target", "8235");
		controlsPanel.SetActive (true);
	}
	public void level10()
	{
		PlayerPrefs.SetInt ("level1", 10);
		PlayerPrefs.SetString ("target", "9840");
		controlsPanel.SetActive (true);
	}

	public void loadingPanel()
	{
		

		//Admob.Instance ().removeBanner ("level");
		//if (Admob.Instance ().isInterstitialReady ()) {

		//	Admob.Instance ().showInterstitial ();
		//	Admob.Instance ().loadInterstitial ();
		//}
		//Admob.Instance ().showBannerRelative (AdSize.MediumRectangle, AdPosition.TOP_RIGHT, 0, "levelload");
		loading.SetActive (true);
	}

	public void loadScene()
	{
		SceneManager.LoadScene ("XRacer-Mobile");

		//Admob.Instance ().removeBanner ("levelload");
	}
}
