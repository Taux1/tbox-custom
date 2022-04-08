using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;

namespace Tricentis.Automation.Engines.Technicals.JavaSwing.Kinaxis {
    // based on com.jidesoft.combobox.ListExComboBox which extens regular JComboBox
    [SupportedTechnicalTypeName("com.kinaxis.web.ui.ComboBox")]
    public class ComboBoxTechnical : SwingJComboBoxTechnical {
        #region Constructors and Destructors

        public ComboBoxTechnical(ISwingObjectManager remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion
    }
}
