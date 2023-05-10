namespace BancoAPI.Data.Models.ModelViews
{
    public class DashboardViewModel : BaseViewModel
    {
        public decimal balance { get; set; }
        public decimal income { get; set; }
        public decimal expense { get; set; }
        public string userId { get; set; }
        public string username { get; set; }
        public List<TransactionDTO> timeframedTransactions { get; set; }
        public List<TransactionDTO> lastTransactions { get; set; }
    }
}
