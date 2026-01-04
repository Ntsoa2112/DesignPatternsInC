using LinqExo.Model;

var orders = new List<Order> {
    new Order { Id = 1, CustomerId = 1, Amount = 100 },
    new Order { Id = 2, CustomerId = 2, Amount = 200 },
    new Order { Id = 3, CustomerId = 1, Amount = 150 },
    new Order { Id = 4, CustomerId = 3, Amount = 300 },
    new Order { Id = 5, CustomerId = 2, Amount = 50 }
};

var result = OrderUtils.GetTotalAmountByCustomer(orders);
result.ToList().ForEach(x =>
    Console.WriteLine($"{x.Key} : {x.Value:C}")
);

var emails = new List<string> {
    "alice@test.com",
    "bob@test.com",
    "alice@test.com",
    "charlie@test.com",
    "bob@test.com",
    "bob@test.com"
};

var resultEmails = EmailUtils.FindDuplicateEmails(emails);
resultEmails.ForEach(email => Console.WriteLine(email));