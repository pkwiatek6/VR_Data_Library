using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using DataCollection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.CSharp;

namespace DataCollection
{
    public class DataCollectionServer : MonoBehaviour
    {
        private static readonly string location = "http://127.0.0.1/api"; //http://ec2-54-208-235-237.compute-1.amazonaws.com/api";
        //static event log
        private static DataCollection.EventData event_log { get; set; }
        private static ConnectionWrapper con;

        private int subject_id, admin_id, game_id;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void StartDataLog()
        {
            event_log = new EventData(subject_id, admin_id, game_id);
            Debug.Log(" subject: "+subject_id+" admin: "+admin_id+" game: "+game_id);
        }

        public void PushDataLog()
        {
            Debug.Log("Pushed event_log to Server via API call");
            Debug.Log(event_log);
            con = new ConnectionWrapper(location);
            con.postRequest("/events", event_log);
            event_log.Clear();
        }

        public Dictionary<string, int> getPatientData()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            con = new ConnectionWrapper(location);
            object response = con.getRequest("/users");
            JArray responseEntities = JArray.Parse(response.ToString());
            JArray patientList = JArray.Parse(responseEntities[0].ToString());
            foreach (JObject patient in patientList)
            {
                int id = 0;
                string name = null;
                JToken value;
                if (patient.TryGetValue("Id", out value))
                {
                    id = value.ToObject<int>();
                }
                if (patient.TryGetValue("Name", out value))
                {
                    name = value.ToObject<string>();
                }
                result.Add(name, id);
            }
            Debug.Log(result.ToString());
            return result;
        }

        public Dictionary<string, int> getTestAdminData()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            con = new ConnectionWrapper(location);
            object response = con.getRequest("/admins");
            JArray responseEntities = JArray.Parse(response.ToString());
            JArray patientList = JArray.Parse(responseEntities[0].ToString());
            foreach (JObject patient in patientList)
            {
                int id = 0;
                string name = null;
                JToken value;
                if (patient.TryGetValue("Id", out value))
                {
                    id = value.ToObject<int>();
                }
                if (patient.TryGetValue("Name", out value))
                {
                    name = value.ToObject<string>();
                }
                result.Add(name, id);
            }
            Debug.Log(result.ToString());
            return result;
        }

        public void SetGameId(int game_id)
        {
            this.game_id = game_id;
        }

        public void SetAdminId( int admin_id)
        {
            this.admin_id = admin_id;
        }

        public void SetUserId( int user_id)
        {
            this.subject_id = user_id;
        }
    }
}