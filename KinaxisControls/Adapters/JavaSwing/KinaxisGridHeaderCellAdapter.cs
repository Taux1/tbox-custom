using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.Attributes;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Kinaxis.Grid;

namespace Tricentis.Automation.Engines.Adapters.JavaSwing {
    [SupportedTechnical(typeof(JGridTechnical))]
    public class KinaxisGridHeaderCellAdapter : SwingJComponentAdapterBase<JGridTechnical>, ITableCellAdapter {

        #region Constructors and Destructors

        public KinaxisGridHeaderCellAdapter(JGridTechnical technical, int rowIndex,  int columnIndex, bool isHeaderRow, Validator validator)
            : base(technical, validator) {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            IsHeaderRow = isHeaderRow;
        }

        #endregion

        #region Public Properties

        public int ColSpan => 1;

        public int RowSpan => 1;

        public int RowIndex { get; }

        public int ColumnIndex { get; }

        public bool IsHeaderRow { get; }

        public string Text {
            get {
                string headerText = Technical.GetHeaderData(RowIndex, ColumnIndex);
                return headerText == string.Empty ? " " : headerText;
            }
        }

        #endregion
    }
}
