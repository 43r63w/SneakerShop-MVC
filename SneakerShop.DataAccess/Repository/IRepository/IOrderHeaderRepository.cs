﻿using SneakerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerShop.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader obj);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
        void UpdateStripePayment(int id, string sessionId, string paymentIntentId);
    }
}
