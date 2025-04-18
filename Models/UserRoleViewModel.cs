using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineStore.Models
{
    public class UserRoleViewModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public string[] SelectedRoles { get; set; }
    }
}
