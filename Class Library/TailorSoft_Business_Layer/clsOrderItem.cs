using TailorSoft_Data_Layer;
using TailorSoft_Models;

namespace TailorSoft_Business_Layer
{
    public class clsOrderItem
    {
        #region Properties
        public enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;
        public int Id { get; private set; }
        public int OrderId { get; set; }
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
        public string? Notes { get; set; }
        #endregion

        #region Constructors
        public clsOrderItem()
        {
            Id = -1;
            OrderId = -1;
            ProductID = null;
            ProductName = string.Empty;
            Quantity = 0;
            UnitPrice = 0;
            Notes = string.Empty;
            _Mode = enMode.AddNew;
        }
        private clsOrderItem(clsOrderItemDTO orderItemDTO)
        {
            Id = orderItemDTO.Id;
            OrderId = orderItemDTO.OrderId;
            ProductID = orderItemDTO.ProductId;
            ProductName = orderItemDTO.ProductName;
            Quantity = orderItemDTO.Quantity;
            UnitPrice = orderItemDTO.UnitPrice;
            Notes = orderItemDTO.Note;
            _Mode = enMode.Update;
        }
        #endregion

        #region Public Methods
        public bool Save()
        {
            clsOrderItemDTO orderItemDTO = new clsOrderItemDTO
            (
                Id, OrderId, ProductID, ProductName, Quantity, UnitPrice, Notes
            );
            if (!_Validate())
                return false;

            if (_Mode == enMode.Update)
            {
                if (Id <= 0)
                    throw new InvalidOperationException("Cannot update an item with Id less than or equal to 0.");
                return _Update(orderItemDTO);
            }
            else if (_Mode == enMode.AddNew)
            {
                return _AddNew(orderItemDTO);
            }
            return false;
        }
        #endregion
        #region Static Methods
        public static clsOrderItem? Find(int orderItemId)
        {
            if (orderItemId <= 0)
                return null;
            return _MapDTObjToOrderItem(clsOrderItemData.GetByID(orderItemId));
        }
        public static List<clsOrderItem> GetItems(int orderId)
        {
            if (orderId <= 0)
                return new List<clsOrderItem>();
            return _MapDTObjListToOrderItemList(clsOrderItemData.GetByOrderID(orderId));
        }
        public static bool Delete(int orderItemId)
        {
            if (orderItemId <= 0)
                return false;
            return clsOrderItemData.Delete(orderItemId);
        }
        #endregion
        #region Private Methods
        private bool _Validate()
        {
            if (OrderId <= 0)
                throw new InvalidOperationException("OrderId must be greater than 0.");
            if (string.IsNullOrWhiteSpace(ProductName))
                throw new InvalidOperationException("ProductName cannot be null or empty.");
            if (Quantity < 0)
                throw new InvalidOperationException("Quantity cannot be negative.");
            if (UnitPrice < 0)
                throw new InvalidOperationException("UnitPrice cannot be negative.");
            return true;
        }
        private bool _Update(clsOrderItemDTO orderItemDTO)
        {
            if (_Mode == enMode.AddNew)
                throw new InvalidOperationException("Cannot update an item that is not in Update mode.");

            return clsOrderItemData.Update(orderItemDTO);
        }
        private bool _AddNew(clsOrderItemDTO orderItemDTO)
        {
            if (_Mode == enMode.Update)
                throw new InvalidOperationException("Cannot add a new item that is not in AddNew mode.");

            int? NewID = clsOrderItemData.AddNew(orderItemDTO);
            if (NewID.HasValue && NewID.Value > 0)
            {
                Id = NewID.Value;
                _Mode = enMode.Update;
                return true;
            }
            return false;
        }
        private static clsOrderItem? _MapDTObjToOrderItem(clsOrderItemDTO? orderItemDTO)
        {
            if (orderItemDTO == null || orderItemDTO.Id < 0)
                return null;

            return new clsOrderItem(orderItemDTO);
        }
        private static List<clsOrderItem> _MapDTObjListToOrderItemList(List<clsOrderItemDTO> orderItemDTOs)
        {
            if (orderItemDTOs == null || orderItemDTOs.Count == 0)
                return new List<clsOrderItem>();
            return orderItemDTOs.Select(_MapDTObjToOrderItem).OfType<clsOrderItem>().ToList();
        }
        #endregion

    }
}
