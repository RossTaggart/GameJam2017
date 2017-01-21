using UnityEngine;
using LitJson;
using System;
using System.Collections;


//3f9a8089cd4e4a5a821220554172001

public class parseJSON
{
	public string windSpeedMiles;
	public string swellHeightM;

}


public class ParseJSONForWavesData : MonoBehaviour {

	public int windSpeedInMetresPerSecond;
	public int swellHeightInMetres;
	public int frequencyOfWaves;

	IEnumerator Start()
	{
		string url = "http://api.worldweatheronline.com/premium/v1/marine.ashx?key=3f9a8089cd4e4a5a821220554172001&format=json&q=60.155,-1.146&tp=24";
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null)
		{
			//Debug.Log (www.text);
			Processjson(www.text);

		}
		else
		{
			Debug.Log("Error: " + www.error);
		}
	}
	private void Processjson(string jsonString)
	{

		JsonData jsonvale = JsonMapper.ToObject (jsonString);
		parseJSON parseJSON;
		parseJSON = new parseJSON ();

		parseJSON.windSpeedMiles = jsonvale ["data"]["weather"][0]["hourly"][0][3].ToString ();
		parseJSON.swellHeightM = jsonvale ["data"]["weather"][0]["hourly"][0][26].ToString ();

		Debug.Log("wind speed: " + parseJSON.windSpeedMiles);
		Debug.Log ("swell height: " + parseJSON.swellHeightM);

		int tempWindSpeed = int.Parse (parseJSON.windSpeedMiles);
		tempWindSpeed = tempWindSpeed * 60 * 60;
		windSpeedInMetresPerSecond = tempWindSpeed;
		swellHeightInMetres = Mathf.RoundToInt(float.Parse((parseJSON.swellHeightM)));

		frequencyOfWaves = windSpeedInMetresPerSecond / swellHeightInMetres;

		UnityEngine.Random.InitState (frequencyOfWaves);

		frequencyOfWaves = UnityEngine.Random.Range(5,25);

		Debug.Log ("frequency: " + frequencyOfWaves.ToString());

		CameraShakeFromWaves cameraShakeFromWaves = GetComponent<CameraShakeFromWaves> ();
		cameraShakeFromWaves.onEnable (frequencyOfWaves);

	}

}
