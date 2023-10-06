﻿using ETradeProject.Application.Repositories;
using ETradeProject.Domain.Entities;
using ETradeProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeProject.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ETradeProjectDbContext context) : base(context)
        {
        }
    }
}
