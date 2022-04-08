using System.Reflection;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java.Interfaces.Generic;
using Tricentis.Automation.Engines.Technicals.References;
using Tricentis.Automation.Engines.Technicals.Reflecting.Java;

namespace Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid {
    [SupportedTechnicalTypeName("com.kinaxis.web.ui.grid.WorksheetSelectionModel")]
    public class WorksheetSelectionModelTechnical : JavaObjectTechnical {
        #region Constructors and Destructors

        public WorksheetSelectionModelTechnical(IJavaObjectManager<IJavaEntryPointTechnical> remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        #region Public Properties

        public IObjectReference Anchor =>
            RemoteObjectManager.GetPropertyAsReference(this, "getAnchor");

        [TechnicalMember("getBottomRight")]
        public IObjectReference BottomRight => GetTechnicalProperty<IObjectReference>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getTopLeft")]
        public IObjectReference TopLeft => GetTechnicalProperty<IObjectReference>(MethodBase.GetCurrentMethod());

        #endregion

        #region Public Methods and Operators

        public bool IsColumnSelected(int columnIndex) =>
            RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isColumnSelected", columnIndex);

        public bool IsRowSelected(int rowIndex) =>
            RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isRowSelected", rowIndex);

        public bool IsSingleCellSelected() =>
            RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isSingleCellSelected");

        public bool UpdateSelection(int column, int row, bool arg2) =>
            RemoteObjectManager.InvokeMethodAsValue<bool>(this, "updateSelection", column, row, arg2);
        
        #endregion
    }
}
