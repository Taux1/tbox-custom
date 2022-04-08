using System.Reflection;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;

namespace Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid {
    [SupportedTechnicalTypeName("com.kinaxis.web.ui.grid.ColumnInfo")]
    public class ColumnInfoTechnical : JavaObjectTechnical {

        #region Constructors and Destructors

        public ColumnInfoTechnical(ISwingObjectManager remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        #region Public Properties

        [TechnicalMember("isCharted")]
        public bool Charted => GetTechnicalProperty<bool>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getColumnIndex")]
        public int ColumnIndex => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getColumnType")]
        public int ColumnType => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getDisplayCurrency")]
        public string DisplayCurrency => GetTechnicalProperty<string>(MethodBase.GetCurrentMethod());

        public string ExpandedHeader => RemoteObjectManager.GetPropertyAsValue<string>(this, "getExpandedHeader");

        [TechnicalMember("getFormattingString")]
        public string FormattingString => GetTechnicalProperty<string>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getHeader")]
        public string Header => GetTechnicalProperty<string>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getId")]
        public string Id => GetTechnicalProperty<string>(MethodBase.GetCurrentMethod());

        [TechnicalMember("isCurrency")]
        public bool IsCurrency => GetTechnicalProperty<bool>(MethodBase.GetCurrentMethod());

        [TechnicalMember("isDynamicHierarchyColumn")]
        public bool IsDynamicHierarchyColumn => GetTechnicalProperty<bool>(MethodBase.GetCurrentMethod());

        [TechnicalMember("isMultiLineEditor")]
        public bool IsMultiLineEditor => GetTechnicalProperty<bool>(MethodBase.GetCurrentMethod());

        [TechnicalMember("isPivoted")]
        public bool Pivoted => GetTechnicalProperty<bool>(MethodBase.GetCurrentMethod());

        [TechnicalMember("getSortedIndex")]
        public int SortedIndex => GetTechnicalProperty<int>(MethodBase.GetCurrentMethod());

        #endregion

        #region Public Methods and Operators



        #endregion
    }
}
