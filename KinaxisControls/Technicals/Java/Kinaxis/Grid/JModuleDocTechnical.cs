using System.Reflection;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;
using Tricentis.Automation.Engines.Technicals.References;

namespace Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid {
    [SupportedTechnicalTypeName("com.kinaxis.web.ui.grid.JModuleDoc")]
    public class JModuleDocTechnical : JavaObjectTechnical {

        #region Constructors and Destructors

        public JModuleDocTechnical(ISwingObjectManager remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        #region Public Properties

        public IObjectReference DataManager => RemoteObjectManager.GetFieldAsReference(this, "dataManager");

        [TechnicalMember("getDisplayColumnCount")]
        public int DisplayColumnCount => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        public IObjectReference EditManager => RemoteObjectManager.GetFieldAsReference(this, "editManager");

        [TechnicalMember("getHeaderRow")]
        public int HeaderRow => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getHeaderRowCount")]
        public int HeaderRowCount => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getHiddenGroupByCount")]
        public int HiddenGroupByCount => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getLastGroupByColumnId")]
        public string LastGroupByColumnId => GetTechnicalProperty<string>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getQbeRow")]
        public int QbeRow => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getQueryColumnCount")]
        public int QueryColumnCount => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        #endregion

        #region Public Methods and Operators

        public bool DeleteRow() {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "DeleteRow");
        }

        public bool BeginEditGrid()
        {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "BeginEditGrid");
        }
        public bool BeginEditGrid(int rowIndex)
        {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "BeginEditGrid", rowIndex);
        }

        public IObjectReference GetCellInfo(CellLocationTechnical cellLocation)
            => RemoteObjectManager.InvokeMethodAsReference(this, "getCellInfo", cellLocation);

        public IObjectReference GetCellInfo(int column, int row)
            => RemoteObjectManager.InvokeMethodAsReference(this, "getCellInfo", column, row);

        public string GetCellValue(string columnId, int col, int row, bool formatted) {
            return RemoteObjectManager.InvokeMethodAsValue<string>(this, "getCellValue", columnId, col, row, formatted);
        }

        public IObjectReference GetColumnInfo(int columnIndex) {
            return RemoteObjectManager.InvokeMethodAsReference(this, "getColumnInfo", columnIndex);
        }

        public float GetColumnWidth(int displayColumn) {
            return RemoteObjectManager.InvokeMethodAsValue<float>(this, "GetColumnWidth", displayColumn);
        }

        public string GetCorrectColumnID(int column, int row) {
            return RemoteObjectManager.InvokeMethodAsValue<string>(this, "getCorrectColumnID", column, row);
        }

        public string GetDataValueByQueryColumn(int row, int column) {
            return RemoteObjectManager.InvokeMethodAsValue<string>(this, "getDataValueByQueryColumn", row, column);
        }

        public string GetEditValue(int row, int column) {
            return RemoteObjectManager.InvokeMethodAsValue<string>(this, "getEditValue", row, column);
        }

        public string GetExpandedHeader(int rowIndex) {
            return RemoteObjectManager.InvokeMethodAsValue<string>(this, "getExpandedHeader", rowIndex);
        }

        public IObjectReference GetPivotedColumnInfo(int columnIndex) {
            return RemoteObjectManager.InvokeMethodAsReference(this, "getPivotedColumnInfo", columnIndex);
        }

        public string GetRawStringValue(int row, int column) {
            return RemoteObjectManager.InvokeMethodAsValue<string>(this, "getRawStringValue", row, column);
        }

        public int GetRowCount() {
            return RemoteObjectManager.InvokeMethodAsValue<int>(this, "getRowCount");
        }

        public int GetRowSelectorColumn() {
            return RemoteObjectManager.InvokeMethodAsValue<int>(this, "getRowSelectorColumn");
        }

        public string GetValue(int column, int row) {
            return RemoteObjectManager.InvokeMethodAsValue<string>(this, "getValue", column, row);
        }

        public int GetQueryColumn(int displayColumn)
        {
            return RemoteObjectManager.InvokeMethodAsValue<int>(this, "getQueryColumn", displayColumn);
        }

        public string GetValueByQueryColumn(int row, int column) {
            return RemoteObjectManager.InvokeMethodAsValue<string>(this, "getValueByQueryColumn", row, column);
        }

        public int GetVisiblePivotedColumnCount() {
            return RemoteObjectManager.InvokeMethodAsValue<int>(this, "getVisiblePivotedColumnCount");
        }

        public bool HasDropList(int row, int column) {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "hasDropList", row, column);
        }

        public bool IsCellEditable(int displayColumn, int row) {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isCellEditable", displayColumn, row);
        }

        public bool IsHeaderRow(int rowIndex) {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isHeaderRow", rowIndex);
        }

        public bool IsLinkColumn(int columnIndex) {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isLinkColumn", columnIndex);
        }

        public bool IsQbeVisible() {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isQbeVisible");
        }

        public bool IsRowSelectorColumn(int columnIndex) {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isRowSelectorColumn", columnIndex);
        }

        public bool IsShowHeader() {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isShowHeader");
        }

        public bool IsSubtotalRow(int rowIndex) {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isSubtotalRow", rowIndex);
        }

        public bool IsReloadRequired()
        {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isReloadRequired");
        }

        public void SetCellValue(int displayColumn, int rowIndex, string newValue) {
            RemoteObjectManager.InvokeVoidMethodWithTimeout(this, "setCellValue", displayColumn, rowIndex, newValue);
        }

        // debugging
        //public void SetCellValueViaEditManager(int displayColumn, int rowIndex, string newValue)
        //{
        //    RemoteObjectManager.InvokeVoidMethodWithTimeout(this.EditManager.Get<JavaObjectTechnical>(), "setEditValue"
        //        , this.DataManager, displayColumn, rowIndex, newValue);
        //}

        public void Save()
        {
            RemoteObjectManager.InvokeVoidMethodWithTimeout(this, "Save");
        }

        #endregion
    }
}
