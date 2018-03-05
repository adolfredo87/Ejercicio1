using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquileresMVC.Helpers
{
    internal partial class HtmlTemplete
    {
        public class Mvc
        {
            public static String BeginSectionItem()
            {
                return "<div class='Item'>";
            }
            public static String EndSectionItem()
            {
                return "</div>";
            }
            public static String SectionItem(MvcHtmlString controlItem)
            {
                return SectionItem(controlItem.ToHtmlString());
            }
            public static String SectionItem(String controlItem)
            {
                return BeginSectionItem() + controlItem + EndSectionItem();
            }

            public static String BeginSectionItemHorizontal()
            {
                return "<div class='Item Horizontal'>";
            }
            public static String EndSectionItemHorizontal()
            {
                return "</div>";
            }

            public static String BeginSectionItemRow()
            {
                return "<div class='DataRow'>";
            }
            public static String EndSectionItemRow()
            {
                return "</div>";
            }

            public static String BeginSectionItemCell(int spanCells)
            {
                if (spanCells <= 1)
                {
                    return "<div class='DataCell'>";
                }
                else if (spanCells == 2)
                {
                    return "<div class='DataCell TwoCells'>";
                }
                else //if (spanCells >= 3)
                {
                    return "<div class='DataCell ThreeCells'>";
                }
            }

            public static String BeginSectionItemCell()
            {
                return BeginSectionItemCell(1);
            }
            public static String EndSectionItemCell()
            {
                return "</div>";
            }
            public static String SectionItemCell(MvcHtmlString controlItem)
            {
                return SectionItemCell(controlItem.ToHtmlString());
            }
            public static String SectionItemCell(String controlItem)
            {
                return BeginSectionItemCell() + controlItem + EndSectionItemCell();
            }

            public static String SectionItemCell(MvcHtmlString controlItem, int spanCells)
            {
                return SectionItemCell(controlItem.ToHtmlString(), spanCells);
            }
            public static String SectionItemCell(String controlItem, int spanCells)
            {
                return BeginSectionItemCell(spanCells) + controlItem + EndSectionItemCell();
            }

            public static String BeginSectionEditorLabel()
            {
                return "<div class='editor-label'>";
            }
            public static String EndSectionEditorLabel()
            {
                return "</div>";
            }
            public static String SectionEditorLabel(MvcHtmlString controlLabel)
            {
                return SectionEditorLabel(controlLabel.ToHtmlString());
            }
            public static String SectionEditorLabel(String controlLabel)
            {
                return BeginSectionEditorLabel() + controlLabel + EndSectionEditorLabel();
            }

            public static String BeginSectionDisplayLabel()
            {
                return "<div class='display-label'>";
            }
            public static String EndSectionDisplayLabel()
            {
                return "</div>";
            }
            public static String SectionDisplayLabel(MvcHtmlString controlLabel)
            {
                return SectionDisplayLabel(controlLabel.ToHtmlString());
            }
            public static String SectionDisplayLabel(String controlLabel)
            {
                return BeginSectionDisplayLabel() + controlLabel + EndSectionDisplayLabel();
            }

            public static String BeginSectionLabelTitle()
            {
                return "<div class='editor-label title Header'>";
            }
            public static String EndSectionLabelTitle()
            {
                return "</div>";
            }
            public static String SectionLabelTitle(MvcHtmlString controlLabel)
            {
                return SectionLabelTitle(controlLabel.ToHtmlString());
            }
            public static String SectionLabelTitle(String controlLabel)
            {
                return BeginSectionLabelTitle() + controlLabel + EndSectionLabelTitle();
            }

            public static String BeginSectionEditorData()
            {
                return "<div class='editor-field'>";
            }
            public static String EndSectionEditorData()
            {
                return "</div>";
            }
            public static String SectionEditorData(MvcHtmlString controlData)
            {
                return SectionEditorData(controlData.ToHtmlString());
            }
            public static String SectionEditorData(String controlData)
            {
                return BeginSectionEditorData() + controlData + EndSectionEditorData();
            }

            public static String BeginSectionDisplayData()
            {
                return "<div class='display-field'>";
            }
            public static String EndSectionDisplayData()
            {
                return "</div>";
            }
            public static String SectionDisplayData(MvcHtmlString controlData)
            {
                return SectionDisplayData(controlData.ToHtmlString());
            }
            public static String SectionDisplayData(String controlData)
            {
                return BeginSectionDisplayData() + controlData + EndSectionDisplayData();
            }

            public static String BeginSectionValidation()
            {
                return "<div class='editor-validation'>";
            }
            public static String EndSectionValidation()
            {
                return "</div>";
            }
            public static String SectionValidation(MvcHtmlString controlValidation)
            {
                return SectionValidation(controlValidation.ToHtmlString());
            }
            public static String SectionValidation(String controlValidation)
            {
                return BeginSectionValidation() + controlValidation + EndSectionValidation();
            }

            public static String BeginSectionWidget()
            {
                return "<div class='ui-widget'>";
            }
            public static String EndSectionWidget()
            {
                return "</div>";
            }
            public static String SectionWidget(MvcHtmlString controlLabel)
            {
                return SectionEditorLabel(controlLabel.ToHtmlString());
            }
            public static String SectionWidget(String controlLabel)
            {
                return BeginSectionWidget() + controlLabel + EndSectionWidget();
            }

            public static String BeginLabel()
            {
                return "<label>";
            }
            public static String BeginLabel(String labelFor)
            {
                return "<label for='" + labelFor + "'>";
            }

            public static String EndLabel()
            {
                return "</label>";
            }
            public static String Label(MvcHtmlString labelText)
            {
                return Label(labelText.ToHtmlString());
            }
            public static String Label(String labelText)
            {
                return BeginLabel() + labelText + EndLabel();
            }

            public static String Label(String labelFor, MvcHtmlString labelText)
            {
                return Label(labelFor, labelText.ToHtmlString());
            }
            public static String Label(String labelFor, String labelText)
            {
                return BeginLabel(labelFor) + labelText + EndLabel();
            }
        }
    }
}