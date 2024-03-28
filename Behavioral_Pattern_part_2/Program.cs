using ChatRoom;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatRoom.ChatRoom chatRoom = new ChatRoom.ChatRoom();

            ChatParticipant participant1 = new ChatParticipant("Alice");
            ChatParticipant participant2 = new ChatParticipant("Bob");
            ChatParticipant participant3 = new ChatParticipant("Charlie");

            chatRoom.Attach(participant1);
            chatRoom.Attach(participant2);
            chatRoom.Attach(participant3);

            chatRoom.SendMessage("Hello, everyone!");

            chatRoom.Detach(participant2);

            chatRoom.SendMessage("Bob left the chat.");

            chatRoom.SendMessage("Charlie, did you hear that?");
        }
    }
}