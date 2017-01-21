using UnityEngine;
using LitJson;
using System;
using System.Collections;


//3f9a8089cd4e4a5a821220554172001

public class parseJSON
{
	public string windSpeedMiles;
	public string swellHeightM;

	public ArrayList weather_windSpeed;
	public ArrayList swell_height;

}


public class ParseJSONForWavesData : MonoBehaviour {

	IEnumerator Start()
	{
		string url = "http://api.worldweatheronline.com/premium/v1/marine.ashx?key=3f9a8089cd4e4a5a821220554172001&format=json&q=45,-2&tp=24";
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

		parseJSON.weather_windSpeed = new ArrayList ();
		parseJSON.swell_height = new ArrayList ();

		//for (int i = 0; i < jsonvale ["data"].Count; i++) {

			//parseJSON.weather_windSpeed.Add(jsonvale ["data"][i]["weather"]["hourly"]["windspeedMiles"].ToString ());
			//parseJSON.swell_height.Add(jsonvale ["data"][i]["weather"]["hourly"] ["swellHeight_m"].ToString ());
		parseJSON.windSpeedMiles = jsonvale ["data"]["weather"][0]["hourly"][0][3].ToString ();
		parseJSON.swellHeightM = jsonvale ["data"]["weather"][0]["hourly"][0][26].ToString ();
		//}
		Debug.Log("wind speed: " + parseJSON.windSpeedMiles);
		Debug.Log ("swell height: " + parseJSON.swellHeightM);
		//Debug.Log("wind speed: " + parseJSON.swellHeightM
	}

}
