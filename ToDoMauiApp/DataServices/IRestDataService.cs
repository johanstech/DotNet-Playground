namespace ToDoMauiApp.DataServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ToDoMauiApp.Models;

    public interface IRestDataService
    {
        Task<List<ToDo>> GetAllToDosAsync();

        Task AddToDoAsync(ToDo toDo);

        Task UpdateToDoAsync(ToDo toDo);

        Task DeleteToDoAsync(int id);
    }
}
