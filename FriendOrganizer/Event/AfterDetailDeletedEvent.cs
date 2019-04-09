using Prism.Events;

namespace FriendOrganizer.Event
{
    public class AfterDetailDeletedEventArgs
    {
        public int? Id { get; set; }
        public string ViewModelName { get; set; }
    }

    public class AfterDetailDeletedEvent : PubSubEvent<AfterDetailDeletedEventArgs>
    {
    }
}
