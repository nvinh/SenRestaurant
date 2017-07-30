using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.Data.SqlClient;

namespace Todo
{
    public class TodoItemRepository : ITodoItemRepository
    {
        readonly SQLiteAsyncConnection connection;

        public TodoItemRepository(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<TodoItem>().Wait();
        }

        public Task<List<TodoItem>> GetAllItemsAsync()
        {
            return connection.Table<TodoItem>().ToListAsync();
        }

        public Task<TodoItem> GetItemAsync(int id)
        {
            return connection.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveAnalyticTextAsync(string analyticText)
        {
            TodoItem t= new TodoItem();
            t.ID = 0;
            t.Name = analyticText;
            t.Done = true;
            return SaveItemAsync(t);
            //return 1;
        }

        public Task<int> SaveItemAsync(TodoItem item)
        {
            if (item.ID != 0)
            {
                return connection.UpdateAsync(item);
            }
            else
            {
                return connection.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(TodoItem item)
        {
            return connection.DeleteAsync(item);
        }
    }
}

