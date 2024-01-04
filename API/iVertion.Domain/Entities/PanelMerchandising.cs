using System.Collections.Generic;
using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class PanelMerchandising
    {
        public int MerchandisingId { get; private set; }
        public IEnumerable<Merchandising>? Merchandisings { get; set; }
        public int PanelId { get; private set; }
        public IEnumerable<Panel>? Panels { get; private set; }

        public PanelMerchandising(int merchandisingId,
                                  int panelId)
        {
            DomainExceptionValidation.When(merchandisingId <= 0,
                                           "Invalid Merchandising Id, must be up to zero.");
            DomainExceptionValidation.When(panelId <= 0,
                                           "Invalid Panel Id, must be up to zero.");
            MerchandisingId = merchandisingId;
            PanelId = panelId;                                           
        }
        public void Update(int merchandisingId,
                           int panelId)
        {
            DomainExceptionValidation.When(merchandisingId <= 0,
                                           "Invalid Merchandising Id, must be up to zero.");
            DomainExceptionValidation.When(panelId <= 0,
                                           "Invalid Panel Id, must be up to zero.");
            MerchandisingId = merchandisingId;
            PanelId = panelId;                                           
        }
    }
}