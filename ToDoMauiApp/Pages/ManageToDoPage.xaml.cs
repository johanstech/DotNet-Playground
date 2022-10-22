namespace ToDoMauiApp.Pages
{
    using ToDoMauiApp.DataServices;
    using ToDoMauiApp.Models;

    [QueryProperty(nameof(ToDo), "ToDo")]
    public partial class ManageToDoPage : ContentPage
    {
        private readonly IRestDataService _dataService;
        private ToDo _toDo;
        private bool _isNew;

        public ToDo ToDo
        {
            get => _toDo;
            set
            {
                _isNew = IsNew(value);
                _toDo = value;
                OnPropertyChanged();
            }
        }

        public ManageToDoPage(IRestDataService dataService)
        {
            InitializeComponent();

            _dataService = dataService;
            BindingContext = this;
        }

        bool IsNew(ToDo toDo) => toDo.Id == 0;

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (_isNew)
            {
                await _dataService.AddToDoAsync(ToDo);
            }
            else
            {
                await _dataService.UpdateToDoAsync(ToDo);
            }

            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            await _dataService.DeleteToDoAsync(ToDo.Id);
            await Shell.Current.GoToAsync("..");
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}