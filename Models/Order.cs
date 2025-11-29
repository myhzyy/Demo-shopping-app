public class Order
{
    public int Id {get;set;}
    public int CustomerId {get;set;}
    public DateTime OrderDate {get;set;} = DateTime.UtcNow;

    
    public Customer Customer {get;set;} = null!;
    public List<OrderLineItem> LineItems {get;set;} = new();

}