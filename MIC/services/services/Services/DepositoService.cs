using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IDepositoService
    {

    }

    public class DepositoService : IDepositoService
    {
        private DataContext _context;

        public DepositoService(DataContext context)
        {
            _context = context;
        }


    }
}