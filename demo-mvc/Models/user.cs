using System;
using System.Collections.Generic;

namespace demo_mvc.Models
{
    public partial class user
    {
        public string user_id { get; set; } = null!;
        public bool is_enable { get; set; }
        public DateTime date_create { get; set; }
        public DateTime? date_update { get; set; }
        public string username { get; set; } = null!;
        public string pwd { get; set; } = null!;
        public string first_name { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public string? phone_number { get; set; }
        public string role_id { get; set; } = null!;
    }
}
