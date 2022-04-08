using System.Drawing;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.Attributes;
using Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid;
using Tricentis.Automation.Engines.Technicals.JavaAwt;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Kinaxis.Grid;

namespace Tricentis.Automation.Engines.Adapters.JavaSwing {
    [SupportedTechnical(typeof(JGridTechnical))]
    public class KinaxisGridCellAdapter : SwingJComponentAdapterBase<JGridTechnical>, ITableCellAdapter {
        #region Fields

        private string cellType;

        private DataRowTechnical dataRow;

        #endregion

        #region Constructors and Destructors

        public KinaxisGridCellAdapter(JGridTechnical technical, int rowIndex, int columnIndex, Validator validator)
            : base(technical, validator) {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }

        #endregion

        #region Public Properties

        public string CellType {
            get {
                if (string.IsNullOrEmpty(cellType)) {
                    cellType = Technical.GetCellType(RowIndex, ColumnIndex).ToLower();
                }
                return cellType;
            }
        }

        public int ColSpan => 1;

        public int ColumnIndex { get; }

        public DataRowTechnical DataRow {
            get {
                if(dataRow == null) {
                    var dataManager = WorkSheetModel.DataManager.Get<DataManagerTechnical>();
                    dataRow = dataManager.GetRow(RowIndex).Get<DataRowTechnical>();
                }
                return dataRow;
            }
        }

        public JSheetAppletTechnical JSheetApplet => Technical.Sheet?.Get<JSheetAppletTechnical>();

        public string RawValue => DataRow.GetRawValueAsString(RowIndex);

        public int RowIndex { get; }

        public int RowSpan => 1;

        // TODO: THIS SEEMS TO COVER EMBEDDED CONTROLS AND MIGHT REQUIRE SERIOUS REWORK - NEED TO BE SPECIFIC ON CURRENT SUPPORTED EMBEDDED CONTROLS
        public string Text {
            get {
                if (RowIndex == -1) {
                    return WorkSheetModel.GetDataValueByQueryColumn(RowIndex, ColumnIndex);                    
                }
                
                string formattedValue = DataRow.GetFormattedValue(ColumnIndex);
                bool hideZeroValue = DataRow.IsHideZeroValues(ColumnIndex);

                if(hideZeroValue && formattedValue == "0") {
                    return "";
                }
                return formattedValue;
            }
        }

        public override bool Visible {
            get {
                return ColumnIndex >= Technical.FirstVisibleColumn &&
                    ColumnIndex <= Technical.LastVisibleColumn &&
                    RowIndex >= Technical.FirstVisibleRow &&
                    RowIndex <= Technical.LastVisibleRow;
            }
        }

        public JModuleDocTechnical WorkSheetModel => Technical.WorkSheetModel?.Get<JModuleDocTechnical>();

        #endregion

        #region Public Methods and Operators

        public override void ScrollToVisible() {
            Technical.SelectCellRange(RowIndex, ColumnIndex, RowIndex, ColumnIndex);
            Technical.EnsureSelectionVisible();

            var selectionModel = Technical.SelectionModel.Get<WorksheetSelectionModelTechnical>();
            if (selectionModel != null) {
                selectionModel.UpdateSelection(ColumnIndex, RowIndex, true);
            }

            Technical.UpdateHorizontalScrollbar();
            Technical.UpdateVerticalScrollbar();
        }


        public override RectangleF GetControlArea(bool refresh) {
            var cellBounds = Technical.GetCellBounds(ColumnIndex, RowIndex).Get<AwtRectangleTechnical>();
            if(cellBounds == null) {
                return new RectangleF();
            }
            var gridLocation = Technical.LocationOnScreen.Get<AwtPointTechnical>();
            float screenY = gridLocation.Y + cellBounds.Y;
            float screenX = gridLocation.X + cellBounds.X;

            return new RectangleF(screenX, screenY, cellBounds.Width, cellBounds.Height);
        }

        #endregion

        #region Private Methods

        protected override RectangleF GetRefreshedControlArea(bool refreshContext) {
            return base.GetRefreshedControlArea(refreshContext);
        }

        #endregion
    }
}
