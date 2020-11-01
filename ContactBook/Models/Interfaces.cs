using System;
using ContactBook.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
    public interface IFormated
    {
        string HtmlFormat();
    }

    public interface IDbRepository
    {
        ICollection<T> Get<T>() where T : class, IEntity;
        ICollection<T> Get<T>(Expression<Func<T, bool>> selector) where T : class, IEntity;
        void Add<T>(T newEntity) where T : class, IEntity;
        void AddRange<T>(ICollection<T> newEntities) where T : class, IEntity;
        void Remove<T>(T entity) where T : class, IEntity;
        //void Update<T>(T entity) where T : class, IEntity;
        int SaveChanges();
    }
}