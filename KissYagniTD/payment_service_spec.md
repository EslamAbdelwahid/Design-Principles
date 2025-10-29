# Objectives

Processing payment for clients

---

## Scope

The Payment Service will support two main payment methods:

1. **CASH** payments: Apply a 5% discount.  
2. **DEBIT** payments: Apply a 2% processing fee.

When the payment is successfully completed, the system will generate a receipt with:

1. **Id**: A unique id for the payment (string).  
2. **Amount**: The final amount after discount.  
3. **PaymentMethod**: The payment method used.

---

## Future Considerations

Additional payment methods (such as credit cards or digital payments) may be added in the future to support more options for customers.
