using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BG.Express.API.Services; // IAddressService ve AddressService için
using BG.Express.API.Data.Entity;
using Beymen.IT.Package.EntityFrameworkCore; // Address entity için


namespace BG.Express.API.Data
{
    public class ExpressUnitOfWork : UnitOfWork
    {    
    public ExpressUnitOfWork(ExpressContext dbContext) : base(dbContext)
    {
    }

    }
}
