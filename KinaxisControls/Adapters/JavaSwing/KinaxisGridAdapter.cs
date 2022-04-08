using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.Attributes;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Kinaxis.Grid;

namespace Tricentis.Automation.Engines.Adapters.JavaSwing {
    [SupportedTechnical(typeof(JGridTechnical))]
    public class KinaxisGridAdapter : SwingJComponentAdapterBase<JGridTechnical>, ITableAdapter {

        #region Constructors and Destructors

        public KinaxisGridAdapter(JGridTechnical technical, Validator validator)
            : base(technical, validator) { }

        #endregion

        #region Public Properties

        public override string DefaultName =>
            !string.IsNullOrEmpty(RuntimeWorksheet) ? RuntimeWorksheet : "Kinaxis JGrid";

        public LoadStrategy LoadStrategy => LoadStrategy.Default;

        public string RuntimeWorksheet => Technical.RuntimeWorksheet;

        #endregion
    }
}
