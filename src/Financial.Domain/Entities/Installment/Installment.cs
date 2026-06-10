using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Domain.Entities.Installment;

    // Representa cada cuota del préstamo.
    // It represents each installment of the loan.
    public class Installment
    {
        public long Id { get; private set; }
        public long LoanId { get; private set; }
        public int InstallmentNumber { get; private set; }
        public DateOnly DueDate { get; private set; }
        public decimal PrincipalAmount { get; private set; }
        public decimal InterestAmount { get; private set; }
        public decimal PenaltyAmount { get; private set; }
        public decimal TotalAmount => PrincipalAmount + InterestAmount + PenaltyAmount;
        public decimal PaidAmount { get; private set; }
        public decimal RemainingAmount => TotalAmount - PaidAmount;
        public InstallmentStatus Status { get; private set; }
        public DateTime? PaidAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdateAt { get; private set; }
    }
