namespace demo_mvc.ViewModels.User
{
    public class InsertOrUpdateParam
    {
        public string user_id { get; set; }
        public string username { get; set; } = null!;
        public string first_name { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public string? phone_number { get; set; }
        public bool is_active { get; set; }
        public string role_id { get; set; } = null!;
    }

    public class InsertOrUpdateViewModel
    {
    }
}
