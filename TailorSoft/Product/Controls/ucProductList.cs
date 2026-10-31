using HFS.Product.Forms;
using TailorSoft.Product.Forms;
using TailorSoft_Business_Layer;
using WinFormsControlsLibrary;

namespace TailorSoft.Product.Controls
{
    public partial class ucProductList : UserControl
    {
        // Icon size & position
        int _IconSize = 32;
        int _Spacing = 10;
        int _Padding = 40; // Padding for icons in the actions column

        CustomDataGridView dgvProductsList = new CustomDataGridView();

        public event Action<int>? OnProductItemsCountChanged;
        public event Action? OnProductItemDeleted;
        public ucProductList()
        {
            InitializeComponent();
            InitializeCustomDataGridView();

        }

        #region Methods
        private void InitializeCustomDataGridView()
        {
            dgvProductsList.CellDoubleClick += DgvProductsList_CellDoubleClick;

            // General style
            dgvProductsList.BackgroundColor = Color.White;
            dgvProductsList.GridColor = Color.LightGray;
            dgvProductsList.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Header style
            dgvProductsList.EnableHeadersVisualStyles = false;
            dgvProductsList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224); // light warm gray
            dgvProductsList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvProductsList.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dgvProductsList.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvProductsList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvProductsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProductsList.ColumnHeadersHeight = 35;

            // Row style
            dgvProductsList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductsList.DefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            dgvProductsList.DefaultCellStyle.BackColor = Color.White;
            dgvProductsList.DefaultCellStyle.ForeColor = Color.Black;
            dgvProductsList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 165, 32); // goldenrod
            dgvProductsList.DefaultCellStyle.SelectionForeColor = Color.White;

            // Alternating row style
            dgvProductsList.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 240); // light beige

            // Remove row headers if not needed
            dgvProductsList.RowHeadersVisible = false;

            dgvProductsList.Dock = DockStyle.Fill;
            dgvProductsList.RightToLeft = RightToLeft.Yes;
            dgvProductsList.ColumnHeadersHeight = 40;
            dgvProductsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProductsList.Columns.AddRange(GetProductColumns());
            dgvProductsList.AllowUserToAddRows = false;
            dgvProductsList.AllowUserToDeleteRows = false;
            dgvProductsList.AllowUserToResizeRows = false;
            dgvProductsList.AllowUserToResizeColumns = true;
            dgvProductsList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductsList.MultiSelect = false;
            dgvProductsList.ReadOnly = true;
            dgvProductsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductsList.BorderStyle = BorderStyle.None;
            dgvProductsList.RowTemplate.Height = 140;
            dgvProductsList.CellPainting += CustomDataGridView_CellPainting;
            dgvProductsList.CellClick += CustomDataGridView_CellClick;
            this.Controls.Add(dgvProductsList);
        }

        private DataGridViewColumn[] GetProductColumns()
        {
            DataGridViewColumn[] columns = new DataGridViewColumn[10];

            columns[0] = new DataGridViewTextBoxColumn
            {
                Name = "clmnID",
                HeaderText = "الرقم",
                DataPropertyName = "Id",
                ReadOnly = true
            };

            columns[1] = new DataGridViewImageColumn
            {
                Name = "clmnImage",
                HeaderText = "الصورة",
                DataPropertyName = "ImagePath",
                ImageLayout = DataGridViewImageCellLayout.Zoom,

            };

            columns[2] = new DataGridViewTextBoxColumn
            {
                Name = "clmnType",
                HeaderText = "النوع",
                DataPropertyName = "ProductType"
            };

            columns[3] = new DataGridViewTextBoxColumn
            {
                Name = "clmnCategory",
                HeaderText = "الفئة",
                DataPropertyName = "Category"
            };

            columns[4] = new DataGridViewTextBoxColumn
            {
                Name = "clmnColor",
                HeaderText = "اللون",
                DataPropertyName = "Color"
            };
            columns[5] = new DataGridViewTextBoxColumn
            {
                Name = "clmnInitialLength",
                HeaderText = "الطول الأولي",
                DataPropertyName = "InitialLength"
            };

            columns[6] = new DataGridViewTextBoxColumn
            {
                Name = "clmnStockLength",
                HeaderText = "الكمية المتاحة",
                DataPropertyName = "StockLength"
            };

            columns[7] = new DataGridViewTextBoxColumn
            {
                Name = "clmnPrice",
                HeaderText = "السعر",
                DataPropertyName = "Price"
            };



            columns[8] = new DataGridViewTextBoxColumn
            {
                Name = "clmnCreatedDate",
                HeaderText = "تاريخ الإضافة",
                DataPropertyName = "CreatedDate",
                ReadOnly = true
            };

            columns[9] = new DataGridViewTextBoxColumn
            {
                Name = "clmnActions",
                HeaderText = "الإجراءات",
                ReadOnly = true
            };

            return columns;
        }
        public async Task SetProductsAsync(Task<List<clsProduct>> products)
        {
            dgvProductsList.Rows.Clear();

            // Fetch products asynchronously
            var Products = await products;

            foreach (var product in Products)
            {
                dgvProductsList.Rows.Add(
                    product.Id,
                    await clsImageHelper.GetImageAsync(product?.ImagePath ?? ""),
                    product?.ProductType?.Name,
                    product?.Category,
                    product?.Color,

                    (product?.InitialLength % 1 == 0 ?
                    product?.InitialLength?.ToString("F0") : product?.InitialLength?.ToString("F1")) + " متر",

                    (product?.StockLength % 1 == 0 ?
                    product?.StockLength?.ToString("F0") : product?.StockLength?.ToString("F1")) + " متر",

                    (product?.Price % 1 == 0 ?
                    product?.Price?.ToString("F0") : product?.Price?.ToString("F1")) + " درهم",

                    product?.CreatedDate?.ToString("dd-MM-yyyy"),
                    ""); // Actions column will be handled in CellPainting
            }
            this.OnProductItemsCountChanged?.Invoke(dgvProductsList.Rows.Count);
        }
        public async Task SetProductsAsync(Task<List<clsProduct>> productsTask, CancellationToken token)
        {
            dgvProductsList.Rows.Clear();

            // Fetch products asynchronously
            var products = await productsTask;
            token.ThrowIfCancellationRequested();

            foreach (var product in products)
            {
                token.ThrowIfCancellationRequested();

                var image = await clsImageHelper.GetImageAsync(product?.ImagePath ?? "");
                token.ThrowIfCancellationRequested();

                dgvProductsList.Rows.Add(
                    product?.Id,
                    await clsImageHelper.GetImageAsync(product?.ImagePath ?? ""),
                    product?.ProductType?.Name,
                    product?.Category,
                    product?.Color,
                    (product?.InitialLength % 1 == 0 ? product?.InitialLength?.ToString("F0") : product?.InitialLength?.ToString("F1")) + " متر",
                    (product?.StockLength % 1 == 0 ? product?.StockLength?.ToString("F0") : product?.StockLength?.ToString("F1")) + " متر",
                    (product?.Price % 1 == 0 ? product?.Price?.ToString("F0") : product?.Price?.ToString("F1")) + " درهم",
                    product?.CreatedDate?.ToString("dd-MM-yyyy"),
                    ""); // Actions column will be handled in CellPainting
            }

            this.OnProductItemsCountChanged?.Invoke(dgvProductsList.Rows.Count);
        }

        public void SetProduct(clsProduct? product)
        {
            dgvProductsList.Rows.Clear();
            if (product == null)
                return;
            dgvProductsList.Rows.Add(
                    product.Id,
                    clsImageHelper.GetImage(product?.ImagePath ?? ""),
                    product?.ProductType?.Name,
                    product?.Category,
                    product?.Color,
                    product?.InitialLength,
                    product?.StockLength,
                    product?.Price,
                    product?.CreatedDate?.ToString("dd-MM-yyyy"),
                    ""); // Actions column will be handled in CellPainting
            this.OnProductItemsCountChanged?.Invoke(dgvProductsList.Rows.Count);
        }
        public void ClearProducts()
        {
            dgvProductsList.Rows.Clear();
        }

        #endregion

        private void CustomDataGridView_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvProductsList?.Columns[e.ColumnIndex].Name != "clmnActions")
                return;

            e.PaintBackground(e.ClipBounds, true);
            e.Handled = true;



            int x1 = e.CellBounds.Left + _Padding;
            int x2 = x1 + _IconSize + _Spacing;
            int x3 = x2 + _IconSize + _Spacing;
            int y = e.CellBounds.Top + (e.CellBounds.Height - _IconSize) / 2;

            Rectangle editIconRect = new Rectangle(x2, y, _IconSize, _IconSize);
            Rectangle deleteIconRect = new Rectangle(x1, y, _IconSize, _IconSize);
            Rectangle SaleIconRec = new Rectangle(x3, y, _IconSize, _IconSize);

            e?.Graphics?.DrawImage(Properties.Resources.edit_icon_blue_32, editIconRect);
            e?.Graphics?.DrawImage(Properties.Resources.delete_icon_red_32, deleteIconRect);
            e?.Graphics?.DrawImage(Properties.Resources.Buy_Product_icon_32, SaleIconRec);
        }
        private void CustomDataGridView_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductsList == null || e.RowIndex < 0 || dgvProductsList?.Columns[e.ColumnIndex].Name != "clmnActions")
                return;

            Rectangle cellRect = dgvProductsList.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            Point mouse = dgvProductsList.PointToClient(Cursor.Position);

            int x1 = cellRect.Left + _Padding;
            int x2 = x1 + _IconSize + _Spacing;
            int x3 = x2 + _IconSize + _Spacing;
            int y = cellRect.Top + (cellRect.Height - _IconSize) / 2;

            Rectangle editRect = new Rectangle(x2, y, _IconSize, _IconSize);
            Rectangle deleteRect = new Rectangle(x1, y, _IconSize, _IconSize);
            Rectangle saleRect = new Rectangle(x3, y, _IconSize, _IconSize);

            if (editRect.Contains(mouse))
            {
                if (int.TryParse(dgvProductsList.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int productID))
                {
                    clsProduct? product = clsProduct.Find(productID);
                    if (product == null)
                    {
                        MessageBox.Show("المنتج غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    using (var editForm = new frmAddUpdateProduct(product))
                    {
                        editForm.OnProductSavedSuccessfully += (product) =>
                        {
                            if (product != null)
                            {
                                // Update the product in the DataGridView
                                dgvProductsList.Rows[e.RowIndex].Cells["clmnImage"].Value = clsImageHelper.GetImage(product.ImagePath ?? "");
                                dgvProductsList.Rows[e.RowIndex].Cells["clmnType"].Value = product.ProductType?.Name;
                                dgvProductsList.Rows[e.RowIndex].Cells["clmnCategory"].Value = product.Category;
                                dgvProductsList.Rows[e.RowIndex].Cells["clmnColor"].Value = product.Color;

                                dgvProductsList.Rows[e.RowIndex].Cells["clmnInitialLength"].Value =
                                (product?.InitialLength % 1 == 0 ?
                                product?.InitialLength?.ToString("F0") : product?.InitialLength?.ToString("F1")) + " متر";

                                dgvProductsList.Rows[e.RowIndex].Cells["clmnStockLength"].Value =
                                (product?.StockLength % 1 == 0 ?
                                product?.StockLength?.ToString("F0") : product?.StockLength?.ToString("F1")) + " متر";

                                dgvProductsList.Rows[e.RowIndex].Cells["clmnPrice"].Value =
                                (product?.Price % 1 == 0 ?
                                product?.Price?.ToString("F0") : product?.Price?.ToString("F1")) + " درهم";

                            }
                        };
                        editForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("خطأ في قراءة رقم المنتج.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (deleteRect.Contains(mouse))
            {
                if (dgvProductsList.Rows.Count == 0 || e.RowIndex < 0)
                {
                    MessageBox.Show("لا يوجد منتجات لحذفهم.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("هل أنت متأكد من حذف هذا المنتج؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (int.TryParse(dgvProductsList.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int productID))
                {
                    if (productID >= 1)
                    {
                        try
                        {
                            if (clsProduct.Delete(productID))
                            {
                                dgvProductsList.Rows.RemoveAt(e.RowIndex);
                                this.OnProductItemsCountChanged?.Invoke(dgvProductsList.Rows.Count);
                                this.OnProductItemDeleted?.Invoke();
                            }
                            else
                            {
                                MessageBox.Show("خطأ في حذف المنتج.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"حدث خطأ أثناء حذف المنتج: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("رقم المنتج غير صالح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("خطأ في قراءة رقم المنتج.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (saleRect.Contains(mouse))
            {
                if (int.TryParse(dgvProductsList.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int productId))
                {
                    // Open sale form or perform sale action
                    clsProduct? product = clsProduct.Find(productId);
                    if (product == null)
                    {
                        MessageBox.Show("المنتج غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    using (frmSetSellingLength saleForm = new frmSetSellingLength(product))
                    {
                        saleForm.OnSellingCompletedSuccessfully += (product) =>
                        {
                            if (product != null)
                            {
                                // Update the product in the DataGridView

                                dgvProductsList.Rows[e.RowIndex].Cells["clmnStockLength"].Value = (product?.StockLength % 1 == 0 ?
                                product?.StockLength?.ToString("F0") : product?.StockLength?.ToString("F1")) + " متر";
                            }
                        };
                        saleForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("خطأ في قراءة رقم المنتج.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DgvProductsList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Open the edit form for the product
            if (int.TryParse(dgvProductsList.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int productId))
            {
                clsProduct? product = clsProduct.Find(productId);
                if (product == null)
                {
                    MessageBox.Show("المنتج غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (var editForm = new frmProductCard(product))
                {
                    editForm.OnProductSavedSuccessfully += (product) =>
                    {
                        if (product != null)
                        {
                            // Update the product in the DataGridView
                            dgvProductsList.Rows[e.RowIndex].Cells["clmnID"].Value = product.Id;
                            dgvProductsList.Rows[e.RowIndex].Cells["clmnImage"].Value = clsImageHelper.GetImage(product.ImagePath ?? "");
                            dgvProductsList.Rows[e.RowIndex].Cells["clmnType"].Value = product.ProductType?.Name;
                            dgvProductsList.Rows[e.RowIndex].Cells["clmnCategory"].Value = product.Category;
                            dgvProductsList.Rows[e.RowIndex].Cells["clmnColor"].Value = product.Color;
                            dgvProductsList.Rows[e.RowIndex].Cells["clmnInitialLength"].Value = product?.InitialLength;
                            dgvProductsList.Rows[e.RowIndex].Cells["clmnStockLength"].Value = product?.StockLength;
                            dgvProductsList.Rows[e.RowIndex].Cells["clmnPrice"].Value = product?.Price;
                            dgvProductsList.Rows[e.RowIndex].Cells["clmnCreatedDate"].Value = product?.CreatedDate?.ToString("yyyy-MM-dd");
                        }
                    };
                    editForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("خطأ في قراءة رقم المنتج.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ucProductList_SizeChanged(object sender, EventArgs e)
        {
            // Minimum width to ensure proper display

            // Adjust padding based on the width of the control
            if (dgvProductsList != null)
            {
                _Padding = ((this.Width) - 1859 + 40) < 0 ? 0 : ((this.Width) - 1859 + 40); // Adjust padding based on control width
            }
        }
    }
}
