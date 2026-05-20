using projectWindowform.DAL;
using projectWindowform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using tieuluan.DAL;
using tieuluan.DTO;

namespace tieuluan.BLL
{
    public class OrderBLL
    {
        private OrderDAL _orderDAL = new OrderDAL();
        private BillDAL _billDAL = new BillDAL();
        private FoodDAL _foodDAL = new FoodDAL();

        public List<OrderItem> GetBill(string tableName)
        {
            return _orderDAL.GetOrders(tableName);
        }

        public void AddFood(string tableName, string foodName, int price, int quantity)
        {
            _orderDAL.EnsureTableExists(tableName);

            var currentBill = _orderDAL.GetOrders(tableName);
            bool isExists = false;

            foreach (var item in currentBill)
            {
                if (item.FoodName == foodName)
                {
                    _orderDAL.UpdateQuantity(tableName, foodName, quantity);
                    isExists = true;
                    break;
                }
            }

            if (!isExists)
            {
                OrderItem newItem = new OrderItem { FoodName = foodName, Price = price, Quantity = quantity };
                _orderDAL.InsertFood(tableName, newItem);
            }
        }

        public void RemoveFood(string tableName, string foodName)
        {
            _orderDAL.DeleteFood(tableName, foodName);
        }

        public void Checkout(string tableName, int tableId)
        {
            var currentBill = _orderDAL.GetOrders(tableName);
            decimal tongTien = currentBill.Sum(x => x.Price * x.Quantity);

            var bill = new Bill
            {
                TableId = tableId,
                ThoiGianMo = DateTime.Now,
                ThoiGianDong = DateTime.Now,
                TongTien = tongTien,
                TrangThai = true
            };

            var details = new List<BillDetail>();
            foreach (var item in currentBill)
            {
                int foodId = _foodDAL.GetFoodIdByName(item.FoodName);

                details.Add(new BillDetail
                {
                    FoodId = foodId,
                    SoLuong = item.Quantity,
                    DonGia = item.Price
                });
            }

            _billDAL.SaveBill(bill, details);
            _orderDAL.ClearTable(tableName);
        }

        public bool HasOrder(string tableName)
        {
            return _orderDAL.CheckOrderExists(tableName);
        }

        public int GetOccupiedTableCount()
        {
            return _orderDAL.GetOccupiedTableCount();
        }

        public int GetEmptyTableCount(int totalTables)
        {
            return totalTables - _orderDAL.GetOccupiedTableCount();
        }

        public void SwitchTable(string currentTableName, string targetTableName)
        {
            if (!HasOrder(targetTableName))
            {
                _orderDAL.SwitchTable(currentTableName, targetTableName);
            }
            else
            {
                var sourceOrders = _orderDAL.GetOrders(currentTableName);
                foreach (var item in sourceOrders)
                {
                    this.AddFood(targetTableName, item.FoodName, item.Price, item.Quantity);
                }
                _orderDAL.ClearTable(currentTableName);
            }
        }
    }
}