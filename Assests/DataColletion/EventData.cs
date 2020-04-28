using System.Collections.Generic;

namespace DataCollection {
    public class EventData {

        public EventData(int subject_id, int admin_id, int game_id) {
            this.subject_id = subject_id;
            this.admin_id = admin_id;
            this.game_id = game_id;
            event_data = new Dictionary<string, string>();
        }

        public int subject_id {get; set;}
        public int admin_id {get; set;}
        public int game_id {get; set;}
        public Dictionary<string, string> event_data {get; set;}

        public void Clear(){
            event_data.Clear();
        }
    }
}