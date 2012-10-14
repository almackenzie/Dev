using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using Xunit;

namespace BeatportPowerCart.Spike.TestRunning
{
    public class ConnectorTests
    {
        [Fact]
        public void Connect()
        {

            string url = @"http://api.beatport.com/catalog/3/tracks?perPage=5&page=1";

            RestRequest request = new RestRequest(url, Method.GET);
            
            RestClient client = new RestClient();
            IRestResponse<BeatportResponse> response = client.Execute<BeatportResponse>(request);


        }


        [Fact]
        public void OauthJeh()
        {
            string baseUrl = @"https://api.beatport.com/";

            RestClient client = new RestClient(baseUrl){Authenticator = OAuth1Authenticator.ForRequestToken("a","a")};

            RestRequest request = new RestRequest("/identity/1/oauth/request-token");

            IRestResponse response = client.Execute(request);
        }


        public class BeatportResponse
        {
            public MetaData MetaData { get; set; }
            public List<TrackInfo> Results { get; set; }

        }

        public class MetaData
        {
            public int Count { get; set; }
            public string NextQuery { get; set; }
        }

        public class TrackInfo
        {
            public List<Artist> Artists { get; set; } 
            public double Bpm { get; set; }
            public string Title { get; set; }
        }

        public class Artist
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


    }
}
