using System.Reflection;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java.Interfaces.Generic;
using Tricentis.Automation.Engines.Technicals.References;
using Tricentis.Automation.Engines.Technicals.Reflecting.Java;

namespace Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid {
    [SupportedTechnicalTypeName("com.kinaxis.web.ui.grid.DataManager")]
    public class DataManagerTechnical : JavaObjectTechnical {
        #region Constructors and Destructors

        public DataManagerTechnical(IJavaObjectManager<IJavaEntryPointTechnical> remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        #region Public Properties

        [TechnicalMember("getRowCount")]
        public int RowCount => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        #endregion

        #region Public Methods and Operators

        public IObjectReference GetRow(int rowIndex) =>
            RemoteObjectManager.InvokeMethodAsReference(this, "getRow", rowIndex);
        
        #endregion
    }
}
