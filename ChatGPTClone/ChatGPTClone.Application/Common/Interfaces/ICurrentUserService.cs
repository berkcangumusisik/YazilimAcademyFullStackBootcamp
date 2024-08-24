namespace ChatGPTClone.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; } //Bir kere set edilir ve değiştirilemez. Sadece get edilebilir. 
    }
}
