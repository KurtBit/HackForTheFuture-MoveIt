using System.Data.Entity;
using System.Linq;
using System;
using MoveIt.Contracts.Repositories;

namespace MoveIt.DAL.Repositories
{
    /// <summary>
    /// Base class implementation of Repository pattern.
    /// </summary>
    /// <typeparam name="T">Concrete implementation of Repository pattern.</typeparam>
    public class RepositoryBase<T> : IRepository<T> where T:class
    {
        private ApplicationDbContext _context;
        private DbSet<T> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public RepositoryBase(ApplicationDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }

            this._context = context;
            this._dbSet = context.Set<T>();
        }

        /// <summary>
        /// Removes an entity from the database.
        /// Sets the state of the entity to detached and removes it from the Database./>
        /// </summary>
        /// <param name="entity">The entity which will be removed.</param>
        public virtual void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Gets all corresponding entities from the Database.
        /// </summary>
        /// <returns>A <see cref="IQueryable{T}"/> of entities.</returns>
        public virtual IQueryable<T> GetAll()
        {
            return this._dbSet;
        }

        /// <summary>
        /// Gets an entity from the Database with the given primary id.
        /// If there is no such entity present in the database returns null.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>The entity with the coresponding id if found, else returns null.</returns>
        public virtual T GetById(object id)
        {
            return this._dbSet.Find(id);
        }

        /// <summary>
        /// Inserts an entity into the database.
        /// </summary>
        /// <param name="entity">The entity that will be inserted.</param>
        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Saves the current context changes.
        /// </summary>
        public virtual void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates an entity.
        /// Attaches the entity to the DbSet and changes the entity state to modified.
        /// </summary>
        /// <param name="entity">The entity that will be updated.</param>
        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
