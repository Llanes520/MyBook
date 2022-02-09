using Infraestructure.Entity.Models;
using MyVet.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IRolServices
    {
        List<RolEntity> GetAll();
    }
}
