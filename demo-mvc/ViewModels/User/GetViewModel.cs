namespace demo_mvc.ViewModels.User
{
    public class GetViewModel
    {
        public string user_id { get; set; } = null!;
        public string username { get; set; } = null!;
        public string first_name { get; set; } = null!;
        public string? last_name { get; set; }
        public string? phone_number { get; set; }
        public string role_id { get; set; } = null!;
    }
}
