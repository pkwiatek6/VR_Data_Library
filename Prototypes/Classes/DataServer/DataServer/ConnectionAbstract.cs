using System;
using RestSharp;
using RestSharp.Authenticators;


namespace DataServer
{
    public class ConnectionWrapper
    {
        RestClient client;

        // Wrappers, one that takes a String with an http address as a string,
        // and another that takes a RestClient - which is constructed the same as method 1
        public ConnectionWrapper(String connectionString)
        {
            client = new RestClient(connectionString);
        }
        public ConnectionWrapper(RestClient client)
        {
            this.client = client;
        }

        // Attaches authentication info to the Wrapper
        public void Authenticate(String user, String password)
        {
            client.Authenticator = new HttpBasicAuthenticator(user, password);
        }

        // Returns a response based on the input location in the format input
        public object Request(String location, DataFormat format)
        {
            return client.Get(new RestRequest(location, format));
        }
    }
}
