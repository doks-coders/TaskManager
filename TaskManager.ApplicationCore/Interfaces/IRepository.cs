using Ardalis.Specification;

namespace TaskManager.ApplicationCore.Interfaces;

/// <summary>
/// The repository will inherit the repository pattern from ardalis
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
