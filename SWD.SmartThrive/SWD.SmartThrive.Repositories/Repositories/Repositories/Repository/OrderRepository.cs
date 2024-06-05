﻿using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Table;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Model;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly STDbContext context;

        public OrderRepository(STDbContext context_) : base(context_)
        {
            context = context_;
        }

        public async Task<bool> AddOrder(Order order)
        {
            var s = await Add(order);
            return s;
        }
        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            var a = await GetAll();
            return a;
        }

        public async Task<IEnumerable<OrderByStudent>> GetAllOrdersByStudent(Guid id)
        {
            var a = from c in context.Orders
                    join t in context.Packages on c.PackageId equals t.Id
                    join s in context.Students on t.StudentId equals s.Id
                    select new OrderByStudent
                    {
                        Id = c.Id,
                        PackageId = c.Id,
                        PackageName = t.PackageName,
                        PaymentMethod = c.PaymentMethod,
                        Amount = c.Amount,
                        TotalPrice = c.TotalPrice,
                        Description = c.Description,
                        Status = c.Status,
                        CreateBy = c.CreateBy,
                        CreateDate = c.CreateDate,
                        LastUpdatedDate = c.LastUpdatedDate,
                        LastUpdatedBy = c.LastUpdatedBy,
                        IsDeleted = c.IsDeleted
                    };
            return await a.Where(x => x.StudentId == id).ToListAsync();
        }

        public async Task<Order> GetOrder(Guid id)
        {
            var g = await GetById(id);
            return g;
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            var u = await Update(order);
            return u;
        }
    }
}