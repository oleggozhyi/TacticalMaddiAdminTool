namespace TacticalMaddiAdminTool.ViewModels
{
    public class MainViewModel
    {
        public ItemListViewModel Items { get; set; }
        public ConnectionViewModel Connection { get; set; }

        public MainViewModel(ItemListViewModel itemListViewModel, ConnectionViewModel connection)
        {
            Items = itemListViewModel;
            Connection = connection;
        }
    }
}