using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TesteEveris.Repository.Repositores
{
    /// <summary>
    /// Classe Pai de Repositório
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> : IDisposable where T : class
    {

        protected RepositoryContext _db;

        public RepositoryBase()
        {
            this._db = new RepositoryContext();
        }
        public void Dispose()
        {
            _db.Dispose();
            _db = null;
        }

        #region Operações CRUD
        public virtual List<T> RetornarTodos()
        {
            return _db.Set<T>().ToList();
        }

        public virtual List<T> RetornarPor(Expression<Func<T, bool>> predicativo)
        {
            return _db.Set<T>().Where(predicativo).ToList();
        }

        public virtual T Adicionar(T value)
        {
            _db.Set<T>().Add(value);
            return value;
        }

        public virtual void Alterar(T value)
        {
           _db.Entry(value).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Excluir(T value)
        {
            _db.Set<T>().Remove(value);
        }

        public void Salvar()
        {
            _db.SaveChanges();
        }
        #endregion

    }
}
