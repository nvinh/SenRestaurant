using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Todo
{
    public partial class App : Application
    {
        static ITodoItemRepository todoItemRepository;

        public static ITodoItemRepository TodoManager
        {
            get
            {
                if (todoItemRepository == null)
                {
                    todoItemRepository = new TodoItemRepository(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return todoItemRepository;
            }
        }

        public static readonly BindableProperty TodoItemProperty =
            BindableProperty.Create("TodoItem", typeof(TodoItem), typeof(App), null);

        public TodoItem TodoItem
        {
            get { return (TodoItem)GetValue(TodoItemProperty); }
            set { SetValue(TodoItemProperty, value); }
        }

    }
}
