using System;
using System.Windows.Forms;
using DevExpress.XtraCharts;
// ...

namespace Series_3DFunnel {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create an empty chart.
            ChartControl funnelChart3D = new ChartControl();

            // Create a funnel series.
            Series series1 = new Series("Funnel Series 1", ViewType.Funnel3D);

            // Populate the series with points.
            series1.Points.Add(new SeriesPoint("A", 28.5));
            series1.Points.Add(new SeriesPoint("B", 19.6));
            series1.Points.Add(new SeriesPoint("C", 17.1));
            series1.Points.Add(new SeriesPoint("D", 12.5));
            series1.Points.Add(new SeriesPoint("E", 9.6));

            // Add the series to the chart.
            funnelChart3D.Series.Add(series1);

            // Display a title for the series, 
            // and adjust another view-type-specific options of the series.
            Funnel3DSeriesView funnelView = (Funnel3DSeriesView)series1.View;
            funnelView.Titles.Add(new SeriesTitle());
            funnelView.Titles[0].Text = series1.Name;
            funnelView.HeightToWidthRatio = 1;
            funnelView.HoleRadiusPercent = 70;
            funnelView.PointDistance = 5;

            // Adjust the value numeric options of the series.
            series1.Label.TextPattern = "{VP:p1}";

            // Position the series labels.
            ((Funnel3DSeriesLabel)series1.Label).Position =
                FunnelSeriesLabelPosition.LeftColumn;

            // Access the diagram's options.
            ((FunnelDiagram3D)funnelChart3D.Diagram).RuntimeRotation = true;
            ((FunnelDiagram3D)funnelChart3D.Diagram).RotationType =
                RotationType.UseMouseStandard;

            // Hide the chart's legend.
            funnelChart3D.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Add the chart to the form.
            funnelChart3D.Dock = DockStyle.Fill;
            this.Controls.Add(funnelChart3D);
        }

    }
}