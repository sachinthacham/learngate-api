/*using learngate_api.Contracts;
using learngate_api.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepository;
    public PaymentController(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    [HttpPost("TestPaymentGateway")]
    public async Task<IActionResult> TestPaymentGateway([FromBody] Payment payment)
    {
        
        
        
        // Simulate product data for testing
        //var productName = "Test Product";
        //var productPrice = 5000; // $50.00 in cents

        // Create Stripe session options
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        UnitAmount = payment.Amount,
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = payment.PaymentName,
                        },
                    },
                    Quantity = 1,
                },
            },
            Mode = "payment",
            SuccessUrl = "http://localhost:5000/success",
            CancelUrl = "http://localhost:5000/cancel",
        };
         await _paymentRepository.CreatePayement(payment);
        // Create Stripe session
        var service = new SessionService();
        Session session = service.Create(options);

        // Return the session URL for manual testing
        return Ok(new { PaymentUrl = session.Url });
    }


}*/

using learngate_api.Contracts;
using learngate_api.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;


[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentController(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    [HttpPost("PaymentGateway")]
    public async Task<IActionResult> TestPaymentGateway([FromBody] Payment payment)
    {
        if (payment == null || payment.Amount <= 0 || string.IsNullOrEmpty(payment.PaymentName))
        {
            return BadRequest("Invalid payment data.");
        }

        // Create Stripe session options
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        UnitAmount = payment.Amount, // Amount is in cents
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = payment.PaymentName,
                        },
                    },
                    Quantity = 1,
                },
            },
            Mode = "payment",
            SuccessUrl = "http://localhost:3000/dashboard/paymentSuccess",
            CancelUrl = "http://localhost:3000/dashboard/paymentFailed",
        };

        // Create Stripe session
        var service = new SessionService();
        Session session = service.Create(options);

        // Return the session URL to the frontend
        return Ok(new { PaymentUrl = session.Url });
    }

    [HttpPost("HandlePaymentSuccess")]
    public async Task<IActionResult> HandlePaymentSuccess([FromBody] Payment payment)
    {
        if (payment == null)
        {
            return BadRequest("Invalid payment data.");
        }

        // Save payment to the database
        var newPayment = new Payment
        {
            Amount = payment.Amount,
            PaymentName = payment.PaymentName,
    
        };

        var savedPayment = await _paymentRepository.CreatePayment(newPayment);
        return Ok(savedPayment);
    }
}
