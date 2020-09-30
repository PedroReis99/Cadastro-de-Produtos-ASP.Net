using AppMVC.Data;
using AppMVC.Models;
using AppMVC.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppMVC.UnitOfWork
{
    public class UnitOfWorkApp : DbContext
    {
        ContextApp context = new ContextApp();
        Repository.Repository<Product> productRepository;

        public Repository<Product> ProductRepository
        {
            get
            {
                if(productRepository == null)//Vai validar se já foi instanciado
                {
                    this.productRepository = new Repository<Product>(context);
                }
                return productRepository;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}