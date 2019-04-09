using FriendOrganizer.Event;
using Prism.Commands;
using Prism.Events;
using System.Windows.Input;

namespace FriendOrganizer.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;
        private string _detailViewModelName;

        public int Id { get; }

        public string DisplayMember
        {
            get => _displayMember;
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        public NavigationItemViewModel(
            int id,
            string displayMember,
            string detailViewModelName,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _detailViewModelName = detailViewModelName;
            Id = id;
            DisplayMember = displayMember;
            OpenDetailViewCommand = new DelegateCommand(OnOpenDetailViewExecute);
        }

        public ICommand OpenDetailViewCommand { get; }

        private IEventAggregator _eventAggregator;

        private void OnOpenDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenDetailViewEvent>()
                        .Publish(new OpenDetailViewEventArgs {
                            Id = Id, ViewModelName = _detailViewModelName });
        }

    }
}
