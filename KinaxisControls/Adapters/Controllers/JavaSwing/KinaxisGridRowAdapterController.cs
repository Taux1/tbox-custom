using System.Collections.Generic;
using System.Linq;
using Tricentis.Automation.AutomationInstructions.TestActions;
using Tricentis.Automation.AutomationInstructions.TestActions.Associations;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.JavaSwing;
using Tricentis.Automation.Engines.Representations.Attributes;

namespace Tricentis.Automation.Engines.Adapters.Controllers.Java {
    [SupportedAdapter(typeof(KinaxisGridRowAdapter))]
    public class KinaxisGridRowAdapterController : TableRowContextAdapterController<KinaxisGridRowAdapter> {

        #region Fields

        private readonly string CellAssociation = "Cells";

        #endregion

        #region Constructors and Destructors

        public KinaxisGridRowAdapterController(KinaxisGridRowAdapter contextAdapter, 
                                         ISearchQuery query, 
                                         Validator validator) : 
            base(contextAdapter, query, validator) { }

        #endregion

        #region Private Methods

        protected override IEnumerable<IAssociation> ResolveAssociation(CellsBusinessAssociation businessAssociation) {
            yield return new AlgorithmicAssociation(CellAssociation);
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ChildrenBusinessAssociation businessAssociation) {
            yield return new TechnicalAssociation("Children"); 
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ParentBusinessAssociation businessAssociation) {
            yield return new TechnicalAssociation("Parent");
        }

        protected override IEnumerable<IAdapter> SearchAdapters(IAlgorithmicAssociation algorithmicAssociation) {
            if (algorithmicAssociation.AlgorithmName == CellAssociation) {
                return GetCells();
            }
            return base.SearchAdapters(algorithmicAssociation);
        }

        private IEnumerable<IAdapter> GetCells() {
            List<IAdapter> cells = new List<IAdapter>();
            int columnCount = ContextAdapter.Technical.ColumnCount - 1;

            for (int columnIdx = 0; columnIdx < columnCount; columnIdx++) {
                IAdapter cell;
                if (ContextAdapter.IsHeaderRow) {
                    cell = AdapterFactory
                        .CreateAdapters<KinaxisGridHeaderCellAdapter>(ContextAdapter.Technical, "Java", ContextAdapter.RowIndex, columnIdx, true)
                        .SingleOrDefault();
                }
                else {
                    cell = AdapterFactory
                        .CreateAdapters<KinaxisGridCellAdapter>(ContextAdapter.Technical, "Java", ContextAdapter.RowIndex, columnIdx)
                        .SingleOrDefault();
                }
                cells.Add(cell);
            }
            return cells;
        }

        #endregion
    }
}
