using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

namespace Github_Cloud_Build.Scripts.Auth
{
    public class GitHubAuthService : MonoBehaviour
    {
        private const string clientID = "YOUR_CLIENT_ID";
        private const string redirectUri = "http://localhost:8080/";
        string authUrl = $"https://github.com/login/oauth/authorize?client_id={clientID}&redirect_uri={redirectUri}&scope=repo";

        private HttpListener listener;

        public async void StartLogin()
        {
        
        
           
            listener = new HttpListener();
            listener.Prefixes.Add(redirectUri);
            listener.Start();
        
            Application.OpenURL(authUrl);
            Debug.Log("Waiting for browser authorization...");

            HttpListenerContext context = await listener.GetContextAsync();
            HttpListenerRequest request = context.Request;

            string code = request.QueryString.Get("code");

            string responseString = "<html><body><h1>Authentication Successful!</h1><p>You can close this window and return to Unity.</p></body></html>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            context.Response.ContentLength64 = buffer.Length;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            context.Response.Close();
        
            listener.Stop();

            if (!string.IsNullOrEmpty(code))
            {
                //StartCoroutine(ExchangeCodeForToken(code));
            }
        }

        
    }
}