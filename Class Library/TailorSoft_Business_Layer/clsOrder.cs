using TailorSoft_Business_Layer;
using TailorSoft_Data_Layer;
using TailorSoft_Models;

public class clsOrder
{
    #region Properties
    public enum enStatus
    {
        Pending,
        //Measuring,
        //InProgress,
        //ReadyforDelivery,
        DeliveredAndNotPaid,
        DeliveredAndPartiallyPaid,
        DeliveredAndPaid,
        Cancelled
    }
    public enum enMode { AddNew, Update }
    private enMode _Mode = enMode.AddNew;

    public int Id { get; private set; }
    public List<clsOrderItem>? Items => clsOrderItem.GetItems(Id);
    public int CustomerID { get; set; }
    public clsCustomer? Customer
    {
        get
        {
            if (CustomerID <= 0)
                return null;
            return clsCustomer.Find(CustomerID);
        }
    }
    public int UserID { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime RequiredDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public byte Status { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal InitialAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? Notes { get; set; }
    #endregion

    #region Constructors
    public clsOrder()
    {
        Id = -1;
        CustomerID = -1;
        UserID = -1;
        OrderDate = DateTime.Now;
        RequiredDate = DateTime.Now;
        DeliveryDate = null;
        Status = 0;
        TotalAmount = 0;
        InitialAmount = 0;
        RemainingAmount = 0;
        PaymentDate = null;
        Notes = string.Empty;
        _Mode = enMode.AddNew;
    }
    private clsOrder(clsOrderDTO orderDTO)
    {
        Id = orderDTO.Id;
        CustomerID = orderDTO.CustomerID;
        UserID = orderDTO.UserID;
        OrderDate = orderDTO.OrderDate;
        RequiredDate = orderDTO.RequiredDate;
        DeliveryDate = orderDTO.DeliveryDate;
        Status = orderDTO.Status;
        TotalAmount = orderDTO.TotalAmount;
        InitialAmount = orderDTO.InitialAmount;
        RemainingAmount = orderDTO.RemainingAmount;
        PaymentDate = orderDTO.PaymentDate;
        Notes = orderDTO.Notes;
        _Mode = enMode.Update;
    }
    #endregion

    #region Public Methods
    public bool Save()
    {
        clsOrderDTO orderDTO = new clsOrderDTO(
            Id, CustomerID, UserID, OrderDate, RequiredDate, DeliveryDate, Status,
            TotalAmount, InitialAmount, RemainingAmount, PaymentDate, Notes
        );
        if (!_Validate())
            return false;
        if (_Mode == enMode.Update)
        {
            if (Id <= 0)
                throw new InvalidOperationException("Cannot update an order with Id less than or equal to 0.");
            return _Update(orderDTO);
        }
        else if (_Mode == enMode.AddNew)
        {
            return _AddNew(orderDTO);
        }
        return false;
    }
    public async Task< bool> SaveAsync()
    {
        clsOrderDTO orderDTO = new clsOrderDTO(
            Id, CustomerID, UserID, OrderDate, RequiredDate, DeliveryDate, Status,
            TotalAmount, InitialAmount, RemainingAmount, PaymentDate, Notes
        );
        if (!_Validate())
            return false;
        if (_Mode == enMode.Update)
        {
            if (Id <= 0)
                throw new InvalidOperationException("Cannot update an order with Id less than or equal to 0.");
            return await _UpdateAsync(orderDTO);
        }
        else if (_Mode == enMode.AddNew)
        {
            return await _AddNewAsync(orderDTO);
        }
        return false;
    }
    #endregion

    #region Static Methods
    public static clsOrder? Find(int orderId)
    {
        if (orderId <= 0)
            return null;
        return _MapDTObjToOrder(clsOrderData.GetByID(orderId));
    }
    public static async Task<clsOrder?> FindAsync(int orderId)
    {
        if (orderId <= 0)
            return null;
        return _MapDTObjToOrder(await Task.Run(() => clsOrderData.GetByID(orderId)));
    }
    public static List<clsOrder> GetByCustomerId(int customerId)
    {
        if (customerId <= 0)
            return new List<clsOrder>();
        return _MapDTObjListToOrderList(clsOrderData.GetByCustomerID(customerId));
    }
    public static bool Delete(int orderId)
    {
        if (orderId <= 0)
            return false;
        return clsOrderData.Delete(orderId);
    }
    public static bool AdjustPayment(int orderId, decimal originalAmount, decimal newAmount)
    {
        if (orderId <= 0 || originalAmount < 0 || newAmount < 0)
            return false;
        return clsOrderData.AdjustPayment(orderId, originalAmount, newAmount);
    }
    public static bool RecordPayment(int orderId, decimal amount)
    {
        if (orderId <= 0)
            return false;
        return clsOrderData.RecordPayment(orderId, amount, DateTime.Now);
    }
    public static List<clsOrder> GetAll()
    {
        return _MapDTObjListToOrderList(clsOrderData.GetAllOrders());
    }
    public static List<clsOrder> GetByOrderDate(DateTime orderDate)
    {
        return _MapDTObjListToOrderList(clsOrderData.GetByDate(orderDate));
    }
    public static List<clsOrder> GetByRequiredDate(DateTime orderDate)
    {
        return _MapDTObjListToOrderList(clsOrderData.GetByRequiredDate(orderDate));
    }
    public static List<clsOrder> GetByStatus(byte Status)
    {
        return _MapDTObjListToOrderList(clsOrderData.GetByStatus(Status));
    }
    public static List<clsOrder> GetByCustomerPhone(string CustomerPhone)
    {
        return _MapDTObjListToOrderList(clsOrderData.GetByCustomerPhone(CustomerPhone));
    }
    public static List<clsOrder> GetByCustomerName(string CustomerName)
    {
        return _MapDTObjListToOrderList(clsOrderData.GetByCustomerName(CustomerName));
    }
    public static List<clsOrderStatisticsDTO> GetOrdersStatisticsForEachMonthByYear(int year)
    {
        return clsOrderData.GetOrdersStatisticsForEachMonthByYear(year);
    }


    #endregion

    #region Private Methods
    private bool _Validate()
    {
        if (CustomerID <= 0)
            throw new InvalidOperationException("CustomerID must be greater than 0.");
        if (UserID < 0)
            throw new InvalidOperationException("UserID must be greater than 0.");
        if (TotalAmount < 0)
            throw new InvalidOperationException("TotalAmount cannot be negative.");
        if (InitialAmount < 0)
            throw new InvalidOperationException("InitialAmount cannot be negative.");
        //if (RemainingAmount < 0)
            //throw new InvalidOperationException("RemainingAmount cannot be negative.");
        return true;
    }
    private bool _Update(clsOrderDTO orderDTO)
    {
        if (_Mode != enMode.Update)
            throw new InvalidOperationException("Cannot update an order that is not in Update mode.");
        return clsOrderData.Update(orderDTO);
    }
    private async Task<bool> _UpdateAsync(clsOrderDTO orderDTO)
    {
        if (_Mode != enMode.Update)
            throw new InvalidOperationException("Cannot update an order that is not in Update mode.");
        return await Task.Run(() => clsOrderData.Update(orderDTO));
    }
    private bool _AddNew(clsOrderDTO orderDTO)
    {
        if (_Mode != enMode.AddNew)
            throw new InvalidOperationException("Cannot add a new order that is not in AddNew mode.");
        int? NewID = clsOrderData.AddNew(orderDTO);
        if (NewID.HasValue && NewID.Value > 0)
        {
            Id = NewID.Value;
            _Mode = enMode.Update;
            return true;
        }
        return false;
    }
    private async Task<bool>_AddNewAsync(clsOrderDTO orderDTO)
    {
        if (_Mode != enMode.AddNew)
            throw new InvalidOperationException("Cannot add a new order that is not in AddNew mode.");
        int? NewID = await Task.Run(() => clsOrderData.AddNew(orderDTO));
        if (NewID.HasValue && NewID.Value > 0)
        {
            Id = NewID.Value;
            _Mode = enMode.Update;
            return true;
        }
        return false;
    }
    private static clsOrder? _MapDTObjToOrder(clsOrderDTO? orderDTO)
    {
        if (orderDTO == null || orderDTO.Id < 0)
            return null;
        return new clsOrder(orderDTO);
    }
    private static List<clsOrder> _MapDTObjListToOrderList(List<clsOrderDTO> orderDTOs)
    {
        if (orderDTOs == null || orderDTOs.Count == 0)
            return new List<clsOrder>();
        return orderDTOs.Select(_MapDTObjToOrder).OfType<clsOrder>().ToList();
    }
    #endregion
}
