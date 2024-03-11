
namespace iVertion.WebApi.Models
{
    public class AddtionalUserRoleModel
    {
        /// <summary>
        /// A role registered in the Identity roles.
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        /// An existing username on Identity.
        /// </summary>
        public string? UserName { get; set; }
    }
}