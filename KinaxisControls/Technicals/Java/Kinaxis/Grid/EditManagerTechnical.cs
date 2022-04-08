using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java.Interfaces.Generic;
using Tricentis.Automation.Engines.Technicals.References;
using Tricentis.Automation.Engines.Technicals.Reflecting.Java;

namespace Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid {
    [SupportedTechnicalTypeName("com.kinaxis.web.ui.grid.EditManager")]
    public class EditManagerTechnical : JavaObjectTechnical {
        #region Constructors and Destructors

        public EditManagerTechnical(IJavaObjectManager<IJavaEntryPointTechnical> remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        #region Public Properties

        // Field descriptor #239 Lcom/kinaxis/web/ui/grid/EditManager$EditedDataStruct;
        //private com.kinaxis.web.ui.grid.EditManager$EditedDataStruct editedData;

        #endregion

        #region Public Methods and Operators

        public IObjectReference ApplyDataChanges(JModuleDocTechnical worksheetModel, DataManagerTechnical dataManager) =>
            RemoteObjectManager.InvokeMethodAsReference(this, "applyDataChanges", worksheetModel, dataManager);

        public void CleanUp() => RemoteObjectManager.InvokeVoidMethod(this, "cleanUp");

        public IObjectReference GetEditedDate(int queryColumn, int rowIndex) =>
            RemoteObjectManager.InvokeMethodAsReference(this, "getEditedData", queryColumn, rowIndex);

        public void PerformDataRefresh() =>
            RemoteObjectManager.InvokeVoidMethod(this, "performDataRefresh");

        //public void SetEditValue(IDataManagerTechnical dataManager, int queryColumn, int rowIndex, string newValue)

        #endregion
    }
}
