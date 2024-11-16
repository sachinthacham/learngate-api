using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IPaymentRepository
    {
        Task<Payment> CreatePayment(Payment payment);
    }
}
