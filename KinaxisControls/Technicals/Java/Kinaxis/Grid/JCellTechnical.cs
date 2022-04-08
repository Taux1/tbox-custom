using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java.Interfaces.Generic;
using Tricentis.Automation.Engines.Technicals.Reflecting.Java;

namespace Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid {
    [SupportedTechnicalTypeName("com.kinaxis.web.ui.grid.JCell")]
    public class JCellTechnical : JavaObjectTechnical {
        #region Constructors and Destructors

        public JCellTechnical(IJavaObjectManager<IJavaEntryPointTechnical> remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        #region Public Properties

        public bool Editable => RemoteObjectManager.GetFieldAsValue<bool>(this, "bEditable");

        public bool HideDuplicates => RemoteObjectManager.GetFieldAsValue<bool>(this, "bHideDuplicates");

        public bool ConditionallyFormatted => RemoteObjectManager.GetFieldAsValue<bool>(this, "bConditionallyFormatted");

        public bool IsLink => RemoteObjectManager.GetFieldAsValue<bool>(this, "bIsLink");

        public int CellType => RemoteObjectManager.GetFieldAsValue<int>(this, "iCellType");

        public string ImageToolTip => RemoteObjectManager.GetFieldAsValue<string>(this, "imageToolTip");

        public string Value => RemoteObjectManager.GetFieldAsValue<string>(this, "sValue");

        public bool IsResourceLink => RemoteObjectManager.GetFieldAsValue<bool>(this, "isResourceLink");

        #endregion

        public bool IsEmptyCellValue(double dbl) => RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isEmptyCellValue", dbl);
    }
}
