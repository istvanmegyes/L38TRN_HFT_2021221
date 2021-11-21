using L38TRN_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Repository
{
    public abstract class Repository<T> 
    {
        protected ProjectDbContext projectDbContext;
        public Repository(ProjectDbContext ProjectDbContext)
        {
            this.projectDbContext = ProjectDbContext;
        }

        public IQueryable<T> GetAll()
        {
            return projectDbContext.Set<T>(); // set => halmaz; != beállítás
        }

        public abstract T GetOne(int id);
    }
}
