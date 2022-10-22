namespace ToDoMauiApp
{
    using System.Diagnostics;
    using ToDoMauiApp.DataServices;
    using ToDoMauiApp.Models;
    using ToDoMauiApp.Pages;

    public partial class MainPage : ContentPage
    {
        private readonly IRestDataService _dataService;

        public MainPage(IRestDataService dataService)
        {
            InitializeComponent();

            _dataService = dataService;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await _dataService.GetAllToDosAsync();
        }

        async void OnAddToDoClicked(object sender, EventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(ToDo), new ToDo() }
            };

            await Shell.Current.GoToAsync(nameof(ManageToDoPage), navigationParameter);
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(ToDo), e.CurrentSelection.FirstOrDefault() as ToDo }
            };

            await Shell.Current.GoToAsync(nameof(ManageToDoPage), navigationParameter);
        }
    }
}