namespace ToDoMauiApp.Models
{
    using System.ComponentModel;

    public class ToDo : INotifyPropertyChanged
    {
        int _id;

        string _name;

        public int Id
        {
            get => _id;
            set
            {
                if (_id == value) return;

                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;

                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
