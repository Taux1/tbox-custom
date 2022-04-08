using System.Reflection;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;
using Tricentis.Automation.Engines.Technicals.References;

namespace Tricentis.Automation.Engines.Technicals.JavaSwing.Kinaxis.Grid {
    [SupportedTechnicalTypeName("com.kinaxis.web.ui.grid.JGrid")]
    public class JGridTechnical : SwingJComponentTechnical {

        #region Constructors and Destructors

        public JGridTechnical(ISwingObjectManager remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        #region Public Properties

        [TechnicalMember("getColumnCount")]
        public int ColumnCount => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        [TechnicalMember("columnPositions")]
        public IObjectListReference ColumnPositions => RemoteObjectManager.GetFieldAsList(this, "columnPositions");

        public int FirstVisibleColumn {
            get => RemoteObjectManager.GetPropertyAsValue<int>(this, "getFirstVisibleColumn");
            set {
                RemoteObjectManager.SetProperty(this, "setFirstVisibleColumn", value);
            }
        }

        public int FirstVisibleRow => RemoteObjectManager.GetFieldAsValue<int>(this, "firstVisibleRow");

        public IObjectReference Editor => RemoteObjectManager.GetFieldAsReference(this, "editor");

        public int LastVisibleColumn => RemoteObjectManager.GetFieldAsValue<int>(this, "lastVisibleColumn");

        public int LastVisibleRow => RemoteObjectManager.GetFieldAsValue<int>(this, "lastVisibleRow");

        public IObjectReference HeadingBounds => RemoteObjectManager.GetFieldAsReference(this, "headingBounds");

        [TechnicalMember("getHeaderRowCount")]
        public int HeaderRowCount => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getHeaderRowHeight")]
        public int HeaderRowHeight => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getRowCount")]
        public int RowCount => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getRowHeight")]
        public int RowHeight => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        public string SelectionData => RemoteObjectManager.GetPropertyAsValue<string>(this, "getSelectionData");

        [TechnicalMember("getRuntimeWorksheet")]
        public string RuntimeWorksheet => GetTechnicalProperty<string>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getScale")]
        public float Scale => GetTechnicalProperty<float>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getSelectionModel")]
        public IObjectReference SelectionModel => GetTechnicalProperty<IObjectReference>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getSheet")]
        public IObjectReference Sheet => GetTechnicalProperty<IObjectReference>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getWorksheetModel")]
        public IObjectReference WorkSheetModel => GetTechnicalProperty<IObjectReference>(MethodBase.GetCurrentMethod());

        #endregion

        #region Public Methods and Operators

        public void ClickCell(int row, int column) {
            RemoteObjectManager.InvokeVoidMethod(this, "clickCell", row, column);
        }

        public IObjectReference ClickCellToOpenUserPopup(int row, int column) {
            return RemoteObjectManager.InvokeMethodAsReference(this, "clickCellToOpenUserPopup", row, column);
        }

        public int DoHScrollRgn(int lFromCol)
        {
            return RemoteObjectManager.InvokeMethodAsValue<int>(this, "DoHScrollRgn", lFromCol);
        }

        public void StopEdit(string overrideText)
        {
            RemoteObjectManager.InvokeVoidMethod(this, "stopEdit", overrideText, null);
        }

        public bool ValidateDataRows()
        {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "ValidateDataRows");
        }

        public int DoHScrollThumbPosition(int nPos)
        {
            return RemoteObjectManager.InvokeMethodAsValue<int>(this, "DoHScrollThumbPosition", nPos);
        }

        public void EnsureSelectionVisible() =>
            RemoteObjectManager.InvokeVoidMethod(this, "ensureSelectionVisible");

        public IObjectReference GetCellBounds(int lCol, int lRec) =>
            RemoteObjectManager.InvokeMethodAsReference(this, "getCellBounds", lCol, lRec);

        public string GetCellData(int row, int column) {
            return RemoteObjectManager.InvokeMethodAsValue<string>(this, "getCellData", row, column);
        }

        public string GetCellType(int row, int column) {
            return RemoteObjectManager.InvokeMethodAsValue<string>(this, "getCellType",row, column);
        }

        public int GetHeaderColSpan(int row, int column) {
            return RemoteObjectManager.InvokeMethodAsValue<int>(this, "getHeaderColSpan", row, column);
        }

        public string GetHeaderData(int row, int column) {
            return RemoteObjectManager.InvokeMethodAsValue<string>(this, "getHeaderData", row, column);
        }

        public bool IsCellEditable(int row, int column) {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isCellEditable", row, column);
        }

        public bool IsCellValueHidden(int column, int row, JCellTechnical cell) {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isCellValueHidden", column, row, cell);
        }

        public bool IsCellVisible(int row, int column) {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isCellVisible", row, column);
        }

        public bool IsCellColumnVisible(int column) {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isCellColumnVisible", column);
        }
        
        public void OpenResourceLink(int row, int column) {
            RemoteObjectManager.InvokeVoidMethod(this, "openResourceLink", row, column);
        }

        public void SetHScrollBarFocusToBucket() {
            RemoteObjectManager.InvokeVoidMethod(this, "setHScrollBarFocusToBucket");
        }

        public void SelectCellRange(int startRow, int startCol, int endRow, int endCol) =>
            RemoteObjectManager.InvokeVoidMethod(this, "selectCellRange", startRow, startCol, endRow, endCol);

        public void SetCellValue(int row, int column, string value) {
            RemoteObjectManager.InvokeVoidMethod(this, "setCellValue", row, column, value);
        }
        
        public void SetFirstVisibleColumn(int newFirstVisibleColumn)
        {
            RemoteObjectManager.InvokeVoidMethod(this, "newFirstVisibleColumn", newFirstVisibleColumn);
        }

        public void UpdateHorizontalScrollbar() => RemoteObjectManager.InvokeVoidMethod(this, "updateHorizontalScrollbar");

        public void UpdateVerticalScrollbar() => RemoteObjectManager.InvokeVoidMethod(this, "updateVerticalScrollbar");

        


        #endregion
    }
}
