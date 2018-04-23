Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace Series_3DFunnel
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create an empty chart.
			Dim funnelChart3D As New ChartControl()

			' Create a funnel series.
			Dim series1 As New Series("Funnel Series 1", ViewType.Funnel3D)

			' Populate the series with points.
			series1.Points.Add(New SeriesPoint("A", 28.5))
			series1.Points.Add(New SeriesPoint("B", 19.6))
			series1.Points.Add(New SeriesPoint("C", 17.1))
			series1.Points.Add(New SeriesPoint("D", 12.5))
			series1.Points.Add(New SeriesPoint("E", 9.6))

			' Add the series to the chart.
			funnelChart3D.Series.Add(series1)

			' Display a title for the series, 
			' and adjust another view-type-specific options of the series.
			Dim funnelView As Funnel3DSeriesView = CType(series1.View, Funnel3DSeriesView)
			funnelView.Titles.Add(New SeriesTitle())
			funnelView.Titles(0).Text = series1.Name
			funnelView.HeightToWidthRatio = 1
			funnelView.HoleRadiusPercent = 70
			funnelView.PointDistance = 5

			' Adjust the value numeric options of the series.
			series1.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent
			series1.PointOptions.ValueNumericOptions.Precision = 1

			' Access the view-type-specific series options.
			CType(series1.PointOptions, FunnelPointOptions).PercentOptions.ValueAsPercent = True

			' Position the series labels.
			CType(series1.Label, Funnel3DSeriesLabel).Position = FunnelSeriesLabelPosition.LeftColumn

			' Access the diagram's options.
			CType(funnelChart3D.Diagram, FunnelDiagram3D).RuntimeRotation = True
			CType(funnelChart3D.Diagram, FunnelDiagram3D).RotationType = RotationType.UseMouseStandard

			' Hide the chart's legend.
			funnelChart3D.Legend.Visible = False

			' Add the chart to the form.
			funnelChart3D.Dock = DockStyle.Fill
			Me.Controls.Add(funnelChart3D)
		End Sub

	End Class
End Namespace