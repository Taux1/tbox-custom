using Tricentis.Automation.Engines.Adapters.JavaSwing.EmbeddedControls.Generic;
using Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid;
using Tricentis.Automation.Engines.Technicals.JavaAwt;

namespace Tricentis.Automation.Engines.Adapters.JavaSwing.EmbeddedControls {
    public class KinaxisEmbeddedCheckBoxAdapter : KinaxisEmbeddedControlAdapter, ICheckBoxAdapter {
        #region Constants

        private const string CHECKBOX_CHECKED_VALUE = "Y";

        #endregion

        #region Constructors and Destructors

        public KinaxisEmbeddedCheckBoxAdapter(KinaxisGridCellAdapter cellAdapter)
            : base(cellAdapter) { }

        #endregion

        #region Public Properties

        public string Label => "";

        /*
         * Code from PoC
         * 
         *            case "checkbox":
                        if (Technical.IsCellEditable(RowIndex, ColumnIndex))
                        {
                            WorkSheetModel.SetCellValue(RowIndex, ColumnIndex, value);
                            Technical.Refresh();
                            Thread.Sleep(1000);
                        }
                        break;
         * */

        public CheckState Selected {
            get => CheckState.From(CellAdapter.Text.ToUpper() == CHECKBOX_CHECKED_VALUE);
            set {
                if(!Technical.IsCellEditable(CellAdapter.RowIndex, CellAdapter.ColumnIndex)) {
                    return;
                }
                CellAdapter.ScrollToVisible();
                Technical.ClickCell(CellAdapter.RowIndex, CellAdapter.ColumnIndex);
                string valueToUse = "Y";
                if(!CheckState.ToBoolean(value)) {
                    valueToUse = "N";
                }
                CellAdapter.WorkSheetModel.BeginEditGrid(CellAdapter.RowIndex);
                CellAdapter.WorkSheetModel.SetCellValue(CellAdapter.ColumnIndex, CellAdapter.RowIndex, valueToUse);
                //Technical.StopEdit(valueToUse);
                Technical.ValidateDataRows();
                Technical.Refresh();
            }
        }

        public bool TriState => false;

        #endregion
    }
}
