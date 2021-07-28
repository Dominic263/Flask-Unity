using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;
 
public class RunServer : MonoBehaviour
{
    [SerializeField] private Slider mainslider; 
    [SerializeField] private Text txt;
    [SerializeField] private InputField field; 
    //[SerializeField] public Button btn; 
    
    public class DataJson 
    {
        public int speed; 
        public int state; 
        public int button; 
    }

    ///string link = "https://192.168.50.10:5000/AR/" ;
    
    public static bool start ; 
    public static Esp esplink;
    public static APIHelper2 req;

    public void Start(){
        Debug.Log("Start Program");
        esplink = new Esp();
    }

    //Definition of the IENumerator 
    public void sendRequest(string json){
        LightJson light = new LightJson();
        req = new APIHelper2();
        light =  req.getResponse(json);
        Debug.Log("Response: "+ light);  
    }
    
    // Update is called once per frame
    void Update()
    {
        txt.text = "" + (mainslider.value); 
        esplink.esp = field.text; 
    }

    //Called when the State button is clicked
    public void OnStateClicked(){
        if(start == true){
            Debug.Log("State button clicked");
            DataJson data = new DataJson();
            data.speed = 7 ;
            data.state = 0; 
            data.button = 0;
            string jsonstr = JsonUtility.ToJson(data);
            Debug.Log(jsonstr);
            sendRequest(jsonstr);
        }else{
            Debug.Log("Start is set to false");
        }
        
    }

//Fucntion call on the run event 
    public void OnRunClicked(){
        if(start == true){
            Debug.Log("Run button clicked");
            DataJson data = new DataJson();
            data.speed = 9 ;
            data.state = 0; 
            data.button = 0;
            Debug.Log(data);
            string jsonstr = JsonUtility.ToJson(data);
            Debug.Log("Json: " + jsonstr);
            sendRequest(jsonstr);
        }else{
            Debug.Log("Start is set to false");
        }
    }

//Function call on start event 
    public void ONStart(){
        Debug.Log("Start Button Clicked");
        start = true;
        esplink.esp = field.text;
    }
    
}
