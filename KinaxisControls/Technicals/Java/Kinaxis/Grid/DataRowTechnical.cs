using System.Reflection;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java.Interfaces.Generic;
using Tricentis.Automation.Engines.Technicals.References;
using Tricentis.Automation.Engines.Technicals.Reflecting.Java;

namespace Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid {
    [SupportedTechnicalTypeName("com.kinaxis.web.ui.grid.DataRow")]
    public class DataRowTechnical : JavaObjectTechnical {
        #region Constructors and Destructors

        public DataRowTechnical(IJavaObjectManager<IJavaEntryPointTechnical> remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        #region Public Properties

        [TechnicalMember("getLabel")]
        public string Label => GetTechnicalProperty<string>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getType")]
        public int Type => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getPivotedColumnId")]
        public string PivotedColumnId => GetTechnicalProperty<string>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getPivotedColumnIndex")]
        public string PivotedColumnIndex => GetTechnicalProperty<string>(MethodBase.GetCurrentMethod());

        #endregion

        #region Public Methods and Operators

        public string GetFormattedValue(int columnIndex) =>
            RemoteObjectManager.InvokeMethodAsValue<string>(this, "getFormattedValue", columnIndex);

        public IObjectReference GetRawValue(int columnIndex) =>
            RemoteObjectManager.InvokeMethodAsReference(this, "getRawValue", columnIndex);

        public string GetRawValueAsString(int columnIndex) =>
            RemoteObjectManager.InvokeMethodAsValue<string>(this, "getRawValueAsString", columnIndex);

        public bool IsHideZeroValues(int columnIndex) =>
            RemoteObjectManager.InvokeMethodAsValue<bool>(this, "isHideZeroValues", columnIndex);

        #endregion
    }
}
