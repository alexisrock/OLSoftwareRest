using DataAccess.Interface;
using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RepositoryUsuario : IRepositoryUsuario
    {

        private readonly OLSoftwareDBContext _Context;

        public RepositoryUsuario(OLSoftwareDBContext _Contextt)
        {
            this._Context = _Contextt;
        }

   

        public async Task<Usuario?> GetByParam(string username)
        {
            return await _Context.Usuario.Where( x => x.Username.Equals(username)).FirstOrDefaultAsync();           
        }
    }
}
