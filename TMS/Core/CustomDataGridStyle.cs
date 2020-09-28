using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace TMS.Core
{
    /// <summary>
    /// CustomDataGridStyle
    /// </summary>
    /// <seealso cref="Syncfusion.SfDataGrid.XForms.DataGridStyle" />
    public class CustomDataGridStyle : DataGridStyle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomDataGridStyle"/> class.
        /// </summary>
        public CustomDataGridStyle()
        {
        }

        /// <summary>
        /// Gets the header's background color.
        /// </summary>
        /// <returns>
        /// The header's background color.
        /// </returns>
        public override Color GetHeaderBackgroundColor()
        {
            return Color.FromHex("#f4f4f4");
        }
        /// <summary>
        /// Gets the AlternatingRow's background color.
        /// </summary>
        /// <returns>
        /// The AlternatingRow's background color.
        /// </returns>
        public override Color GetAlternatingRowBackgroundColor()
        {
            return Color.FromHex("#fafbfc");
        }

        /// <summary>
        /// Gets the <see cref="T:Xamarin.Forms.FontAttributes" /> for the TableSummaryRows .
        /// </summary>
        /// <returns>
        /// Returns the <see cref="T:Xamarin.Forms.FontAttributes" />.
        /// </returns>
        public override FontAttributes GetTableSummaryFontAttribute()
        {
            return FontAttributes.None;
        }

        /// <summary>
        /// Gets the record's background color.
        /// </summary>
        /// <returns>
        /// The record's background color.
        /// </returns>
        public override Color GetRecordBackgroundColor()
        {
            return Color.FromHex("#f4f4f4");
        }

        /// <summary>
        /// Gets the type of the borders to be drawn in <see cref="T:Syncfusion.SfDataGrid.XForms.SfDataGrid" />.
        /// </summary>
        /// <returns>
        /// The <see cref="T:Syncfusion.SfDataGrid.XForms.GridLinesVisibility" /> for <see cref="T:Syncfusion.SfDataGrid.XForms.SfDataGrid" />.
        /// </returns>
        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.None;
        }


    }
}

