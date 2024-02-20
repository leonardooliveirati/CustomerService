using CustomerService.Domain.Entities;

namespace CustomerService.API.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string UF { get; set; }
        public string Cellphone { get; set; }
        public List<FinancingEntity> Financings { get; set; }
    }
}
