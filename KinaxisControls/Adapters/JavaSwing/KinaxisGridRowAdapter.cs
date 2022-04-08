using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.Attributes;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Kinaxis.Grid;

namespace Tricentis.Automation.Engines.Adapters.JavaSwing {
    [SupportedTechnical(typeof(JGridTechnical))]
    public class KinaxisGridRowAdapter : SwingJComponentAdapterBase<JGridTechnical>, ITableRowAdapter {

        #region Constructors and Destructors

        public KinaxisGridRowAdapter(JGridTechnical technical, int rowIndex, bool isHeaderRow, Validator validator)
            : base(technical, validator) {
            RowIndex = rowIndex;
            IsHeaderRow = isHeaderRow;
        }

        #endregion

        #region Public Properties

        public bool IsHeaderRow { get; }

        public int RowIndex { get; }

        #endregion
    }
}
