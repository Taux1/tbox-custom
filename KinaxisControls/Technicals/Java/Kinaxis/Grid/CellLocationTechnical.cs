using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java.Interfaces.Generic;
using Tricentis.Automation.Engines.Technicals.Reflecting.Java;

namespace Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid {
    [SupportedTechnicalTypeName("com.kinaxis.web.ui.grid.CellLocation")]
    public class CellLocationTechnical : JavaObjectTechnical {
        #region Constructors and Destructors

        public CellLocationTechnical(IJavaObjectManager<IJavaEntryPointTechnical> remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        #region Public Properties

        public int Column => RemoteObjectManager.GetPropertyAsValue<int>(this, "getColumn");

        public int Row => RemoteObjectManager.GetPropertyAsValue<int>(this, "getRow");

        #endregion
    }
}
