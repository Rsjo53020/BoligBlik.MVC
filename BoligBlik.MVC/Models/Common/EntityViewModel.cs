namespace BoligBlik.MVC.Models.Common
{
    public abstract class EntityViewModel 
    {
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
