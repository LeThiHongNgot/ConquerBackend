using AutoMapper;
using ConquerBackend.Domain;
using ConquerBackend.Domain.Entities.ConquerBackend;
using ConquerBackend.Domain.Respositories.ConquerBackend;
using ConquerBackend.Persistence.Context;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Persistence.Repositories.ConquerBackend
{
    public class ActionsRepository(ConquerBackendContext context, IMapper mapper) : Repository<ActionsModel, Guid>(context, mapper), IActionRepository, IScopedDependency
    {

    }
}
