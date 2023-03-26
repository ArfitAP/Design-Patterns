namespace Mediator
{
    public abstract class ChatRoom
    {
        public abstract void Register(TeamMember teamMember);
        public abstract void Send(string from, string message);
        public abstract void Send(string from, string to, string message);

        public abstract void SendTo<T>(string from, string message) where T : TeamMember;
    }

    public abstract class TeamMember
    {
        private ChatRoom? _chatRoom;

        public string Name { get; set; }

        protected TeamMember(string name)
        {
            Name = name;
        }

        internal void SetChatroom(ChatRoom chatRoom)
        {
            _chatRoom = chatRoom;
        }

        public void Send(string message) 
        {
            _chatRoom?.Send(Name, message);
        }

        public void Send(string to, string message)
        {
            _chatRoom?.Send(Name, to, message);
        }

        public void SendTo<T>(string message) where T : TeamMember
        {
            _chatRoom?.SendTo<T>(Name, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"Message {from} to {Name}: {message}");
        }
    }

    public class Lawyer :TeamMember
    {
        public Lawyer(string name) : base(name) { }

        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(Lawyer)} {Name} received: ");
            base.Receive(from, message);
        }
    }

    public class AccountManager : TeamMember
    {
        public AccountManager(string name) : base(name) { }

        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(AccountManager)} {Name} received: ");
            base.Receive(from, message);
        }
    }

    public class TeamChatRoom : ChatRoom
    {
        private readonly Dictionary<string, TeamMember> teamMembers = new();
        public override void Register(TeamMember teamMember)
        {
            teamMember.SetChatroom(this);
            if(!teamMembers.ContainsKey(teamMember.Name))
            {
                teamMembers.Add(teamMember.Name, teamMember);
            }
        }

        public override void Send(string from, string message)
        {
            foreach(var teamMember in teamMembers.Values) 
            {
                teamMember.Receive(from, message);
            }
        }

        public override void Send(string from, string to, string message)
        {
            var teamMember = teamMembers[to];
            teamMember?.Receive(from, message);           
        }

        public override void SendTo<T>(string from, string message)
        {
            foreach (var teamMember in teamMembers.Values.OfType<T>())
            {
                teamMember.Receive(from, message);
            }
        }
    }
}
 