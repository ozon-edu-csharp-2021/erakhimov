namespace OzonEdu.MerchandiseApi.Models
{
    public class MerchRequest
    {
        public int EmployeerId { get; }

        public MerchRequest(int employeerId)
        {
            EmployeerId = employeerId;
        }
    }
}
