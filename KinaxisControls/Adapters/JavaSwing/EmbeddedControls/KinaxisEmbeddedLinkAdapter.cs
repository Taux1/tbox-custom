using Tricentis.Automation.Engines.Adapters.JavaSwing.EmbeddedControls.Generic;
using Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid;

namespace Tricentis.Automation.Engines.Adapters.JavaSwing.EmbeddedControls {
    public class KinaxisEmbeddedLinkAdapter : KinaxisEmbeddedControlAdapter, ILinkAdapter {
        #region Constructors and Destructors

        public KinaxisEmbeddedLinkAdapter(KinaxisGridCellAdapter cellAdapter)
            : base(cellAdapter) { }

        #endregion

        #region Public Properties

        public string Label => CellAdapter.Text;

        public string Url => "";

        #endregion

        #region Public Methods and Operators

        public void Follow() {
            JCellTechnical cell = CellAdapter.WorkSheetModel
                .GetCellInfo(CellAdapter.ColumnIndex, CellAdapter.RowIndex)
                .Get<JCellTechnical>();
            if(!cell.IsLink) {
                return;
            }

            Technical.ClickCell(CellAdapter.RowIndex, CellAdapter.ColumnIndex);
        }

        #endregion
    }
}
