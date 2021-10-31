namespace OzonEdu.MerchandiseApi.Models
{
    public sealed class MerchResponse
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
