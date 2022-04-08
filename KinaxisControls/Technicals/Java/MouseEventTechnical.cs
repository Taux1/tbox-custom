using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java.Interfaces.Generic;
using Tricentis.Automation.Engines.Technicals.Reflecting.Java;

namespace Tricentis.Automation.Engines.Technicals.Java {
    [SupportedTechnicalTypeName("java.awt.event.MouseEvent")]
    public class MouseEventTechnical : JavaObjectTechnical {
        #region Constructors and Destructors

        public MouseEventTechnical(IJavaObjectManager<IJavaEntryPointTechnical> remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        #region Public Methods and Operators

       
        #endregion
    }
}
