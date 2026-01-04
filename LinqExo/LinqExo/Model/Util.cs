using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExo.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }

    public static class OrderUtils
    {
        public static Dictionary<int, decimal> GetTotalAmountByCustomer(List<Order> orders)
        {
            if (orders == null) throw new ArgumentNullException(nameof(orders));

            if (!orders.Any()) return new Dictionary<int, decimal>();

            return orders
                .GroupBy(orders => orders.CustomerId)
                .Select(group => new
                {
                    CustomerId = group.Key,
                    TotalAmount = group.Sum(o => o.Amount),
                })
                .ToDictionary(x => x.CustomerId, x => x.TotalAmount);
        }
    }

    public static class EmailUtils
    {
        public static List<string> FindDuplicateEmails(List<string> emails)
        {
            if (emails == null) throw new ArgumentNullException(nameof(emails));

            if (!emails.Any()) return new List<string>();

            return emails
                .GroupBy(email => email)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                .ToList();
        }
    }
}
