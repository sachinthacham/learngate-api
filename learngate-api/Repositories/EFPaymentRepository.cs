using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;

namespace learngate_api.Repositories
{
    public class EFPaymentRepository:IPaymentRepository
    {
        private readonly LearnGateDbContext _context;
        public EFPaymentRepository(LearnGateDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> CreatePayment(Payment payment)
        {
            var Newpayment = new Payment
            {
                Amount = payment.Amount,
              
               
                PaymentName = payment.PaymentName,

            };

            await _context.Payments.AddAsync(Newpayment);
            await _context.SaveChangesAsync();
            return Newpayment;
        }
    }
}
