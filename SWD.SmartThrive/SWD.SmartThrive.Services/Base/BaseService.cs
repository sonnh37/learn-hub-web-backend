using AutoMapper;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SmartThrive.Services.Base
{
    public abstract class BaseService
    {

    }
    public abstract class BaseService<TEntity> : BaseService
        where TEntity : BaseEntity
    {
        protected readonly IMapper _mapper;

        protected readonly IUnitOfWork _unitOfWork;

        protected BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
