using System;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Customization;

namespace DXPivotGrid.Controllers
{
    public static class InsightExtensionSettings
    {
        public static PivotGridSettings PivotGridGeneralSettings(string name, Action<PivotGridSettings> setupSettings = null,
            PivotGridSettings settings = null)
        {
            if (settings == null)
            {
                settings = new PivotGridSettings
                {
                    Name = name,
                    Width = Unit.Percentage(100), //default width to 100%
                    OptionsView =
                    {
                        VerticalScrollBarMode = ScrollBarMode.Auto,
                        HorizontalScrollBarMode = ScrollBarMode.Visible
                    },
                    OptionsCustomization =
                    {
                        CustomizationFormStyle = CustomizationFormStyle.Excel2007,
                        CustomizationFormLayout = CustomizationFormLayout.StackedSideBySide,
                        DeferredUpdates = true
                    },
                };

                settings.OptionsView.DataHeadersPopupMinCount = 2;
                settings.OptionsView.DataHeadersDisplayMode = PivotDataHeadersDisplayMode.Popup;

                // client event
                settings.ClientSideEvents.BeginCallback = "OnPivotGridBeginCallback";
                settings.ClientSideEvents.EndCallback = "OnPivotGridEndCallback";
            }

            if (setupSettings != null)
            {
                setupSettings(settings);
            }

            // default to Adomd when connect to analysis server
            settings.OLAPDataProvider = OLAPDataProvider.Adomd;
            return settings;
        }
    }
}