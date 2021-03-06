﻿using Azurite.Store.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azurite.Store.Workers.Contracts
{
    public interface IShoppingCartWorker
    {
        List<OrderedProductW> GetShoppingCart();
        void AddProduct(Guid id, int quantity);
        void RemoveProduct(Guid id);
        void ModifyProductQty(Guid productId, int quantity);
        OrderW GetCartSummary();
        OrderW GetOrder();
        bool SaveOrder(OrderW order);
        void DisplaceOrder();
    }
}