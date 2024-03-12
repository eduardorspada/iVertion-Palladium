using iVertion.Domain.Entities;
using iVertion.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace iVertion.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        // Users Profiles
        public DbSet<UserProfile>? UserProfiles { get; set; }
        public DbSet<RoleProfile>? RoleProfiles { get; set; }
        public DbSet<AdditionalUserRole>? AdditionalUserRoles { get; set; }
        // Blogs
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Article>? Articles { get; set; }
        public DbSet<ArticleHistory>? ArticleHistories { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<ContactForm>? ContactForms { get; set; }
        public DbSet<Menu>? Menus { get; set; }
        public DbSet<Page>? Pages { get; set; }

        // Ticket Panel
        public DbSet<ClientType>? ClientTypes { get; set; }
        public DbSet<Counter>? Counters { get; set; }
        public DbSet<Merchandising>? Merchandisings { get; set; }
        public DbSet<Panel>? Panels { get; set; }
        public DbSet<PanelMerchandising>? PanelMerchandisings { get; set; }
        public DbSet<PreferenceType>? PreferenceTypes { get; set; }
        public DbSet<ServiceType>? ServiceTypes { get; set; }
        public DbSet<Ticket>? Tickets { get; set; }
        public DbSet<TicketFollowUp>? TicketFollowUps { get; set; }
        public DbSet<TicketSubject>? TicketSubjects { get; set; }
        public DbSet<Totem>? Totems { get; set; }
        public DbSet<TotemPanel>? TotemPanels { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}