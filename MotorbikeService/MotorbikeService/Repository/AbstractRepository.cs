using MotorbikeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotorbikeService.Repository
{
    public class AbstractRepository <T> where T: class
    {
        public virtual void Create(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }
    }
}