
namespace iVertion.WebApi.Models
{
    /// <summary>
    /// This model is the body of users' requests for additional roles.
    /// </summary>
    public class AdditionalUserRoleModel
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