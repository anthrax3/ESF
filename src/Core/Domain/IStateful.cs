namespace Enterprise.Domain
{
    public interface IStateful
    {
        int Status { get; set; }
    }
}