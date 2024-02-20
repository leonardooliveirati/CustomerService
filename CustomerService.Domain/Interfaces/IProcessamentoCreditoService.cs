using CustomerService.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Domain.Interfaces
{
    public interface IProcessamentoCreditoService
    {
        Task<ResultadoProcessamentoDto> ProcessarCredito(CreditoDto credito);
    }
}
