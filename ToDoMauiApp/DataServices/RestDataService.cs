namespace ToDoMauiApp.DataServices
{
    using System.Diagnostics;
    using System.Text.Json;
    using ToDoMauiApp.Models;

    public class RestDataService : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestDataService()
        {
            _httpClient = new HttpClient();
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5192" : "https://localhost:7192";
            _url = $"{_baseAddress}/api";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public Task AddToDoAsync(ToDo toDo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ToDo>> GetAllToDosAsync()
        {
            List<ToDo> toDos = new List<ToDo>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/todo");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    toDos = JsonSerializer.Deserialize<List<ToDo>>(content, _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("---> No Http 2xx response");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception: {e.Message}");
            }

            return toDos;
        }

        public Task UpdateToDoAsync(ToDo toDo)
        {
            throw new NotImplementedException();
        }
    }
}
