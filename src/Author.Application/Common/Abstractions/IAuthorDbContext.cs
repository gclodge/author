using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Author.Application.Common.Abstractions;

/// <summary>
/// An interface representing the database context for the Author application.
/// </summary>
public interface IAuthorDbContext
{
    /// <summary>
    /// Provides access to the <see cref="User"/> entities in the database.
    /// </summary>
    public DbSet<User> Users { get; }

    /// <summary>
    /// Provides access to the <see cref="UserGroup"/> entities in the database.
    /// </summary>
    public DbSet<UserGroup> Groups { get; }

    /// <summary>
    /// Provides access to the <see cref="UserGroupAssignment"/> entities in the database.
    /// </summary>
    public DbSet<UserGroupAssignment> GroupAssignments { get; }

    /// <summary>
    /// Provides access to the <see cref="UserPermission"/> entities in the database.
    /// </summary>
    public DbSet<UserPermission> Permissions { get; }

    /// <summary>
    /// Provides access to the underlying <see cref="DatabaseFacade"/> for transactions and other database operations.
    /// </summary>
    public DatabaseFacade Database { get; }

    /// <summary>
    /// Persist the currently tracked/stages changes to the backing database.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
