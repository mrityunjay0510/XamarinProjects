using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using AgencyProfile.Model;
using Org.Json;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AgencyProfile.Services
{
    class FetchDataFromService
    {

        public  string loadHistoryDataFromWebApi(string url)
        {
            var request = HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";
            string jsonDoc =null;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    //jsonDoc = await Task.Run(() => JsonValue.Load(reader));
                    jsonDoc =  reader.ReadToEnd();
                   
                    if (string.IsNullOrWhiteSpace(jsonDoc))
                    {
                        Console.Out.WriteLine("Response contained empty body...");
                    }
                    else
                    {
                        Console.Out.WriteLine("Response Body: \r\n {0}", jsonDoc);
                    }
                }
            }
            return jsonDoc;
        }

        public  List<Proposals> getProposalHistoryList(int agentId)
        {
            //List<Proposals> _proposalList = new List<Proposals>();
            //JSONObject jsonObject =  LoadJSONHistoryData();
            //if (jsonObject != null)
            //{
            //    _proposalList = ParseJson(jsonObject);
            //}
            //return _proposalList;

            string url = "http://10.0.2.2:9810/api/history/1";
            string jsonString = loadHistoryDataFromWebApi(url);
            List<Proposals> _proposalList = JsonConvert.DeserializeObject<List<Proposals>>(jsonString);
            return _proposalList;
        }

        public List<Proposals> LoadJSONHistoryData()
        {
            string url = "http://10.0.2.2:9810/api/history/1";
            string jsonString =  loadHistoryDataFromWebApi(url);
           List<Proposals> _proposalList  = JsonConvert.DeserializeObject<List<Proposals>>(jsonString);

            return _proposalList;
            //try
            //{
            //    return new JSONObject(jsonString);
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
        }

        List<Proposals> ParseJson(JSONObject json)
        {
            List<Proposals> result = new List<Proposals>();
            try
            {
                JSONArray items = json.GetJSONArray("ProposalHistoryList");
                for (int i = 0; i < items.Length(); i++)
                {
                    JSONObject item = items.GetJSONObject(i);
                    Proposals p = new Proposals();
                    p.sender = item.GetString("Sender");
                    p.quotes = item.GetString("Quote");
                    p.createdDate = item.GetString("CreatedDate");
                    p.viewedDate = item.GetString("CustomerViewed");
                    p.proposalId = item.GetString("proposalId");
                    p.firstName = item.GetString("FirstName");
                    p.lastname = item.GetString("LastName");
                    result.Add(p);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public AgentDetails getAgentProfileData()
        {
            AgentDetails agentDetail = new AgentDetails();
            string url = "http://10.0.2.2:9810/api/agent/1";
            string jsonString = loadHistoryDataFromWebApi(url);
            ParseAgentData(jsonString, agentDetail);
            return agentDetail;
        }

        private void ParseAgentData(string jsonString, AgentDetails agentDetail)
        {

           // JSONObject json = new JSONObject(jsonString);
           // JsonValue value = JsonValue.Parse(jsonString);
            JSONObject obj =  new JSONObject(jsonString);

            JSONObject items = obj.GetJSONObject("Address");
           
           // JSONObject item = items.GetJSONObject(0);
            AddressModel address = new AddressModel();
          
        }
    }
}