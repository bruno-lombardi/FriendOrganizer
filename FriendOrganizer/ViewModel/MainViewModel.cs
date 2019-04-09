using Autofac.Features.Indexed;
using FriendOrganizer.Event;
using FriendOrganizer.View.Services;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;

namespace FriendOrganizer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IIndex<string, IDetailViewModel> _detailViewModelCreator;
        private IMessageDialogService _messageDialogService;
        private IDetailViewModel _detailViewModel;

        private IEventAggregator _eventAggregator;

        public INavigationViewModel NavigationViewModel { get; }
        public DelegateCommand<Type> CreateNewDetailCommand { get; }
        public IDetailViewModel DetailViewModel
        {
            get { return _detailViewModel; }
            private set
            {
                _detailViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavigationViewModel navigationViewModel, 
            IIndex<string, IDetailViewModel> detailViewModelCreator,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService)
        {
            _detailViewModelCreator = detailViewModelCreator;
            _messageDialogService = messageDialogService;

            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenDetailViewEvent>()
                .Subscribe(OnOpenDetailView);
            _eventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            NavigationViewModel = navigationViewModel;
            CreateNewDetailCommand = new DelegateCommand<Type>(OnCreateNewDetailExecute);
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        private async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            if(DetailViewModel != null && DetailViewModel.HasChanges)
            {
                var result = _messageDialogService.ShowOkCancelDialog("All your changes will be lost.", "Are you sure?");
                if (result == MessageDialogResult.Cancel)
                    return;
            }

            DetailViewModel = _detailViewModelCreator[args.ViewModelName];
            await DetailViewModel.LoadAsync(args.Id);
        }

        private void OnCreateNewDetailExecute(Type viewModelType)
        {
            OnOpenDetailView(
                new OpenDetailViewEventArgs { ViewModelName = viewModelType.Name });
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            DetailViewModel = null;
        }

    }
}
