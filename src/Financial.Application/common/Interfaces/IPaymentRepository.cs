using Financial.Domain.Entities.Payments;

namespace Financial.Application.common.Interfaces;
public interface IPaymentRepository
{
    Task<Payment?> GetByIdAsync(Guid paymentId, CancellationToken cancellationToken);

    Task AddAsync(Payment payment, CancellationToken cancellationToken);

    Task UpdateAsync(Payment payment, CancellationToken cancellationToken);
}