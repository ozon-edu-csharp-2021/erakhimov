using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseApi.Models
{
    public class MerchResponse
    {
        public int EmployeerId { get; }

        public bool IsIssued { get; }

        public MerchResponse(int employeerId, bool isIssued)
        {
            EmployeerId = employeerId;
            IsIssued = isIssued;
        }
    }
}
