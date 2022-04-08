using System.Collections.Generic;
using System.Linq;
using Tricentis.Automation.AutomationInstructions.TestActions;
using Tricentis.Automation.AutomationInstructions.TestActions.Associations;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.JavaSwing;
using Tricentis.Automation.Engines.Adapters.JavaSwing.EmbeddedControls;
using Tricentis.Automation.Engines.Representations.Attributes;
using Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid;
using Tricentis.Automation.Engines.Technicals.JavaSwing;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Kinaxis;

namespace Tricentis.Automation.Engines.Adapters.Controllers.JavaSwing {
    [SupportedAdapter(typeof(KinaxisGridCellAdapter))]
    public class KinaxisGridCellAdapterController : ContextAdapterController<KinaxisGridCellAdapter> {
        #region Fields

        private readonly string embeddedControlsAssociation = "EmbeddedControls";

        #endregion

        #region Constructors and Destructors

        public KinaxisGridCellAdapterController(KinaxisGridCellAdapter contextAdapter, ISearchQuery query, Validator validator)
            : base(contextAdapter, query, validator) { }

        #endregion

        #region Private Methods

        protected override IEnumerable<IAssociation> ResolveAssociation(ChildrenBusinessAssociation businessAssociation) {
            yield break;
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ParentBusinessAssociation businessAssociation) {
            yield return new TechnicalAssociation("Parent");
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(DescendantsBusinessAssociation businessAssociation) {
            yield return new AlgorithmicAssociation(embeddedControlsAssociation);
        }

        protected override IEnumerable<IAdapter> SearchAdapters(IAlgorithmicAssociation algorithmicAssociation) {
            if (algorithmicAssociation.AlgorithmName == embeddedControlsAssociation) {
                return GetEmbeddedControl();
            }
            return base.SearchAdapters(algorithmicAssociation);
        }

        private IEnumerable<IAdapter> GetEmbeddedControl() {
            List<IAdapter> embeddedControls = new List<IAdapter>();
            string cellType = ContextAdapter.CellType;

            if(cellType == "checkbox") {
                embeddedControls.Add(new KinaxisEmbeddedCheckBoxAdapter(ContextAdapter));
            }
            else if(cellType == "combobox") {
                //TODO not sure if the cellType is "combobox" or "dropdown", find the actual value!
                var comboBox = GetEditor().ComboBox.Get<BusyComboBoxTechnical>();
                if (comboBox != null) {
                    var comboBoxAdapter = AdapterFactory.CreateAdapters<IGuiAdapter>(comboBox, "Java").SingleOrDefault();
                    embeddedControls.Add(comboBoxAdapter);
                }
            }
            else {
                if(cellType == "link") {
                    embeddedControls.Add(new KinaxisEmbeddedLinkAdapter(ContextAdapter));
                }
                // a link can also be an editable textbox
                if (!ContextAdapter.Technical.IsCellEditable(ContextAdapter.RowIndex, ContextAdapter.ColumnIndex)) {
                    return embeddedControls;
                }
                embeddedControls.Add(new KinaxisEmbeddedTextBoxAdapter(ContextAdapter));
            }
            return embeddedControls;
        }

        private JEditorTechnical GetEditor() {
            ContextAdapter.ScrollToVisible();
            var editor = ContextAdapter.Technical.Editor.Get<JEditorTechnical>();
            editor.RequestFocus();
            return editor;
        }

        #endregion
    }
}
