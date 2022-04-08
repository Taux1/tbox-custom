using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java.Interfaces.Generic;
using Tricentis.Automation.Engines.Technicals.Reflecting.Java;

namespace Tricentis.Automation.Engines.Technicals.Java {
    [SupportedTechnicalTypeName("java.lang.Integer")]
    public class JavaIntegerTechnical : JavaObjectTechnicalBase<IJavaEntryPointTechnical> {
        #region Constructors and Destructors

        public JavaIntegerTechnical(IJavaObjectManager<IJavaEntryPointTechnical> remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        #region Public Methods and Operators

        public int IntValue => RemoteObjectManager.GetPropertyAsValue<int>(this, "intValue");

        #endregion
    }
}
