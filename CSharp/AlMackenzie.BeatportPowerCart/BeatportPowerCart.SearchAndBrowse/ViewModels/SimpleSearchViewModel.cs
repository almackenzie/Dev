using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;
using RestSharp;

namespace BeatportPowerCart.SearchAndBrowse.ViewModels
{
    public class SimpleSearchViewModel : NotificationObject
    {

        public SimpleSearchViewModel()
        {
            PropertyChanged += HandlePropertyChanged;
        }

        private void HandlePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SearchTerm")
            {
                HandleNewSearchTerm(SearchTerm);
            }
        }

        private void HandleNewSearchTerm(string searchTerm)
        {

            //GET /catalog/3/search?query=believe+2004

            string url = @"http://api.beatport.com/catalog/3/search?query=" + searchTerm;

            RestRequest request = new RestRequest(url, Method.GET);

            RestClient client = new RestClient();
            IRestResponse<BeatportResponse> response = client.Execute<BeatportResponse>(request);
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get
            {
                return _searchTerm;
            }
            set
            {
                if (_searchTerm != value)
                {
                    _searchTerm = value;
                    RaisePropertyChanged(() => SearchTerm);
                }
            }
        }



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
