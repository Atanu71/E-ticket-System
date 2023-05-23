using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, int, bool>
    {
        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(int id)
        {
            return db.Tokens.Find(id);
        }

        public bool Create(Token obj)
        {

            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0) ;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Tokens.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public bool Update(Token obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            //if () ;
            return db.SaveChanges() > 0;
        }
    }
}
