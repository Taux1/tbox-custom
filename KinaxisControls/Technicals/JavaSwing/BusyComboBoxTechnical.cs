using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;

namespace Tricentis.Automation.Engines.Technicals.JavaSwing.Kinaxis {
    [SupportedTechnicalTypeName("com.kinaxis.web.ui.BusyComboBox")]
    public class BusyComboBoxTechnical : ComboBoxTechnical {
        #region Constructors and Destructors

        public BusyComboBoxTechnical(ISwingObjectManager remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion
    }
}
