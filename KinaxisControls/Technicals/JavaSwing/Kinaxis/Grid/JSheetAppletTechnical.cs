using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;

namespace Tricentis.Automation.Engines.Technicals.JavaSwing.Kinaxis.Grid {
    [SupportedTechnicalTypeName("com.kinaxis.web.ui.grid.JSheetApplet")]
    public class JSheetAppletTechnical : SwingJPanelTechnical {

        #region Constructors and Destructors

        public JSheetAppletTechnical(ISwingObjectManager remoteObjectManager, Validator validator)
            : base(remoteObjectManager, validator) { }

        #endregion

        #region Public Methods and Operators

        public bool BeginEdit() {
            return RemoteObjectManager.InvokeMethodAsValue<bool>(this, "beginEdit");
        }

        public void DoEditRange() {
            RemoteObjectManager.InvokeVoidMethod(this, "doEditRange");
        }

        public void Save() => RemoteObjectManager.InvokeVoidMethod(this, "save");

        public void ShowContextMenu(int row, int column) {
            RemoteObjectManager.InvokeVoidMethod(this, "showContextMenu", row, column);
        }

        public void ShowLinkMenu(int row, int column) {
            RemoteObjectManager.InvokeVoidMethod(this, "showLinkMenu", row, column);
        }

        public void ShowQBEMenu(int row, int column) {
            RemoteObjectManager.InvokeVoidMethod(this, "showQBEMenu", row, column);
        }

        #endregion
    }
}
