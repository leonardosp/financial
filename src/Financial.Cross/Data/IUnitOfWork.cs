namespace Financial.Cross.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
