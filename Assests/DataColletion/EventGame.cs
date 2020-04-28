namespace DataCollection {
    public interface EventGame {
        int GetGameId();

        /* Start game */
        void StartGame();
        /* End game */
        void EndGame();
        /* Push event string to Current Event Data Log */
        void PushEvent(string EventString);


    }
}