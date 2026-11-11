using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
 
public class AuthManager : MonoBehaviour
{
    public string apiKey;
    public TMP_Text uidText;
    public static string Uid = "";
    public static string IdToken = "";
    public static string Name = "";
 
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(SignIn());
    }
 
    IEnumerator SignIn()
    {
        string url = "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=" + apiKey;
        UnityWebRequest req = UnityWebRequest.Post(url, "{\"returnSecureToken\":true}", "application/json");
        yield return req.SendWebRequest();
        if (req.result != UnityWebRequest.Result.Success) { uidText.text = req.error; yield break; }
        AuthResponse res = JsonUtility.FromJson<AuthResponse>(req.downloadHandler.text);
        Uid = res.localId; IdToken = res.idToken; Name = "Guest " + Uid.Substring(0, 6);
        uidText.text = Name;
    }
}

[System.Serializable]
public class AuthResponse
{
    public string idToken;
    public string localId;
}