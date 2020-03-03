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

        // Returns a response based on the input location.
        // Defaults to Json
        public object getRequest(String location)
        {
            var request = new RestRequest(location, DataFormat.Json);
            IRestResponse a = client.Get(request);
            return a.Content;
        }

        // Returns a response based on the input location in the format input
        public object getRequest(String location, DataFormat format)
        {
            var request = new RestRequest(location, format);
            IRestResponse a = client.Get(request);
            return a.Content;
        }

        // Post sends information the API
        // location is the location within client to POST
        // information gets converted to Json for POST.
        public void postRequest(string location, object information)
        {
            var request = new RestRequest(location, Method.POST);
            request.AddJsonBody(information);
            client.Post(request);
        }
    }
}
