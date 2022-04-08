using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Kinaxis.Grid;

namespace Tricentis.Automation.Engines.Adapters.JavaSwing.EmbeddedControls.Generic {
    public class KinaxisEmbeddedControlAdapter : SwingJComponentAdapterBase<JGridTechnical> {
        #region Constructors and Destructors

        public KinaxisEmbeddedControlAdapter(KinaxisGridCellAdapter cellAdapter)
            : base(cellAdapter.Technical, Validator.Default()) {
            CellAdapter = cellAdapter;
        }

        #endregion

        #region Public Properties

        public KinaxisGridCellAdapter CellAdapter { get; protected set; }

        public override bool Visible => CellAdapter.Visible;

        #endregion

        #region Public Methods and Operators

        public override void ScrollToVisible() {
            CellAdapter.ScrollToVisible();
        }

        #endregion
    }
}
