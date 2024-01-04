using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class TicketFollowUp : Entity
    {
        public string? Description { get; private set; }
        public int TicketId { get; private set; }
        public Ticket? Ticket { get; set; }
        public int TicketSubjectId { get; private set; }
        public TicketSubject? TicketSubject { get; set; }

        public TicketFollowUp(string description,
                              int ticketId,
                              int ticketSubjectId,
                              bool active)
        {
            ValidationDomain(description,
                             ticketId,
                             ticketSubjectId);
            Active = active;
        }
        public TicketFollowUp(int id,
                              string description,
                              int ticketId,
                              int ticketSubjectId,
                              bool active)
        {
            DomainExceptionValidation.When(id <= 0,
                                "Invalid Id, must be up to zero.");
            ValidationDomain(description,
                             ticketId,
                             ticketSubjectId);
            Id = id;
            Active = active;
        }
        public void Update(string description,
                           int ticketId,
                           int ticketSubjectId,
                           bool active)
        {
            ValidationDomain(description,
                             ticketId,
                             ticketSubjectId);
            Active = active;
        }
        private void ValidationDomain(string description,
                                      int ticketId,
                                      int ticketSubjectId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                                           "Invalid Description, must not be null or empty.");
            DomainExceptionValidation.When(description.Length < 5,
                                           "Invalid Description, too short, must be at least 5 characters long.");
            DomainExceptionValidation.When(description.Length > 250,
                                           "Invalid Description, too long, must be 250 characters or less.");
            DomainExceptionValidation.When(ticketId <= 0,
                                           "Invalid Ticket Id, must be up to zero.");
            DomainExceptionValidation.When(ticketSubjectId <= 0,
                                           "Invalid Ticket Subject Id, must be up to zero.");

            TicketId = ticketId;
            TicketSubjectId = ticketSubjectId;
            Description = description;
        }
    }
}