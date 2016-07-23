using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;


public class UnityAdsExample : MonoBehaviour
{

	void Start()
	{
		StartCoroutine (ShowAd ());
	}
	IEnumerator ShowAd() {
		while (!Advertisement.IsReady()) {
			yield return null;
		}
		Advertisement.Show();
	}
}