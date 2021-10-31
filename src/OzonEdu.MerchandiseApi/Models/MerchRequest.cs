namespace OzonEdu.MerchandiseApi.Models
{
    public sealed class MerchRequest
    {
        public int EmployeerId { get; }

        public MerchRequest(int employeerId)
        {
            EmployeerId = employeerId;
        }
    }
}
