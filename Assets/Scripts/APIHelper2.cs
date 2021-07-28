
using UnityEngine;
using System.IO;
using System.Net;

public class APIHelper2 
{
    public static string base_url = "http://192.168.50.10:5000/AR/23";
    //public static RunServer server;

    public LightJson getResponse(string json){
        //RunServer server = new RunServer();
        try{
            string url = base_url; 
            Debug.Log(url);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            
            //string jsonstring = JsonUtility.ToJson(json);
            Debug.Log("Json String: " + json);
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                Debug.Log(json);
                streamWriter.Write(json);
            }

            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonstr = reader.ReadToEnd();
            Debug.Log(jsonstr);
            
            return JsonUtility.FromJson<LightJson>(jsonstr);
            
        }
        catch(WebException ex){
            Debug.Log(ex.Message);
            return null; 
        }
        
    }
}
