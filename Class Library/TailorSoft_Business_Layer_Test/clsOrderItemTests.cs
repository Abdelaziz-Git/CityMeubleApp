using Moq;
using TailorSoft_Business_Layer;
using TailorSoft_Models;

namespace TailorSoft_Business_Layer_Test
{
    public class clsOrderItemTests
    {
        [Fact]
        public void Constructor_Default_InitializesProperties()
        {
            var item = new clsOrderItem();
            Assert.Equal(-1, item.Id);
            Assert.Equal(-1, item.OrderId);
            Assert.Null(item.ProductID);
            Assert.Equal(string.Empty, item.ProductName);
            Assert.Equal(0, item.Quantity);
            Assert.Equal(0, item.UnitPrice);
            Assert.Equal(string.Empty, item.Notes);
        }

        [Fact]
        public void TotalPrice_ReturnsCorrectValue()
        {
            var item = new clsOrderItem
            {
                Quantity = 2.5m,
                UnitPrice = 10m
            };
            Assert.Equal(25m, item.TotalPrice);
        }

        [Fact]
        public void Save_AddNew_ValidData_ReturnsTrueAndSetsId()
        {
            var dto = new clsOrderItemDTO(-1, 1, 54, "Product", 3, 4, "Note");
            var mockData = new Mock<IOrderItemData>();
            mockData.Setup(d => d.AddNew(It.IsAny<clsOrderItemDTO>())).Returns(5);

            clsOrderItemData.SetTestInstance(mockData.Object);

            var item = new clsOrderItem
            {
                OrderId = 1,
                ProductID = 54,
                ProductName = "Product",
                Quantity = 3,
                UnitPrice = 4,
                Notes = "Note"
            };

            var result = item.Save();

            Assert.True(result);
            Assert.Equal(5, item.Id);
        }

        [Fact]
        public void Save_Update_ValidData_ReturnsTrue()
        {
            var dto = new clsOrderItemDTO(5, 1, 54, "Product", 3, 4, "Note");
            var mockData = new Mock<IOrderItemData>();
            mockData.Setup(d => d.Update(It.IsAny<clsOrderItemDTO>())).Returns(true);

            clsOrderItemData.SetTestInstance(mockData.Object);

            var item = new clsOrderItem
            {
                Id = 5,
                OrderId = 1,
                ProductID = 54,
                ProductName = "Product",
                Quantity = 3,
                UnitPrice = 4,
                Notes = "Note"
            };
            // Set mode to Update via reflection (since it's private)
            typeof(clsOrderItem)
                ?.GetField("_Mode", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(item, Enum.Parse(typeof(clsOrderItem.enMode), "Update"));

            var result = item.Save();

            Assert.True(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Find_InvalidId_ReturnsNull(int id)
        {
            var result = clsOrderItem.Find(id);
            Assert.Null(result);
        }

        [Fact]
        public void GetItems_InvalidOrderId_ReturnsEmptyList()
        {
            var result = clsOrderItem.GetItems(0);
            Assert.Empty(result);
        }

        [Fact]
        public void Delete_InvalidId_ReturnsFalse()
        {
            var result = clsOrderItem.Delete(0);
            Assert.False(result);
        }

        [Fact]
        public void Validate_ThrowsOnInvalidOrderId()
        {
            var item = new clsOrderItem
            {
                OrderId = -1,
                ProductName = "Product",
                Quantity = 1,
                UnitPrice = 1
            };
            Assert.Throws<InvalidOperationException>(() => item.Save());
        }

        [Fact]
        public void Validate_ThrowsOnEmptyProductName()
        {
            var item = new clsOrderItem
            {
                OrderId = 1,
                ProductName = "",
                Quantity = 1,
                UnitPrice = 1
            };
            Assert.Throws<InvalidOperationException>(() => item.Save());
        }

        [Fact]
        public void Validate_ThrowsOnNegativeQuantity()
        {
            var item = new clsOrderItem
            {
                OrderId = 1,
                ProductName = "Product",
                Quantity = -1,
                UnitPrice = 1
            };
            Assert.Throws<InvalidOperationException>(() => item.Save());
        }

        [Fact]
        public void Validate_ThrowsOnNegativeUnitPrice()
        {
            var item = new clsOrderItem
            {
                OrderId = 1,
                ProductName = "Product",
                Quantity = 1,
                UnitPrice = -1
            };
            Assert.Throws<InvalidOperationException>(() => item.Save());
        }
    }

    // Test double for data layer
    public interface IOrderItemData
    {
        int? AddNew(clsOrderItemDTO dto);
        bool Update(clsOrderItemDTO dto);
    }

    public static class clsOrderItemData
    {
        private static IOrderItemData? _testInstance;

        public static void SetTestInstance(IOrderItemData instance) => _testInstance = instance;

        public static int? AddNew(clsOrderItemDTO dto) => _testInstance?.AddNew(dto);
        public static bool Update(clsOrderItemDTO dto) => _testInstance?.Update(dto) ?? false;
        public static clsOrderItemDTO? GetByID(int id) => null;
        public static List<clsOrderItemDTO> GetByOrderID(int orderId) => new();
        public static bool Delete(int id) => false;
    }
}