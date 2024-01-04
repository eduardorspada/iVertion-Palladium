using System.Collections.Generic;
using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class TotemPanel
    {
        public int TotemId { get; set; }
        public IEnumerable<Totem>? Totems { get; set; }
        public int PanelId { get; set; }
        public IEnumerable<Panel>? Panels { get; private set; }

        public TotemPanel(int totemId,
                          int panelId)
        {
            DomainExceptionValidation.When(totemId <= 0,
                                           "Invalid Totem Id, must be up to zero.");
            DomainExceptionValidation.When(panelId <= 0,
                                           "Invalid Panel Id, must be up to zero.");
            TotemId = totemId;
            PanelId = panelId;                                           
        }
        public void Update(int totemId,
                           int panelId)
        {
            DomainExceptionValidation.When(totemId <= 0,
                                           "Invalid Totem Id, must be up to zero.");
            DomainExceptionValidation.When(panelId <= 0,
                                           "Invalid Panel Id, must be up to zero.");
            TotemId = totemId;
            PanelId = panelId;                                           
        }
    }
}