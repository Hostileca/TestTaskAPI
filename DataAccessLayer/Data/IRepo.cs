namespace TestTaskAPI.Data
{
	public interface IRepo<T>
	{
		Task SaveChanges();
		Task<IEnumerable<T>> GetAllItems();
		Task<T?> GetItemById(int id);
		Task CreateItem(T item);
		void DeleteItem(T item);
	}
}
