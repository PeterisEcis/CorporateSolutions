namespace CorporateSolutions.Models
{
    public class Audit
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
    }

}
