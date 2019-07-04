Public Class XtraReport1
    Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.xrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        ' 
        ' Detail
        ' 
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable2})
        Me.Detail.HeightF = 24.20832F
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0F)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        ' 
        ' xrTable2
        ' 
        Me.xrTable2.Borders = (CType(((((DevExpress.XtraPrinting.BorderSide.Left Or
            DevExpress.XtraPrinting.BorderSide.Top) Or
            DevExpress.XtraPrinting.BorderSide.Right) Or
            DevExpress.XtraPrinting.BorderSide.Bottom)),
            DevExpress.XtraPrinting.BorderSide))
        Me.xrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0F, 0F)
        Me.xrTable2.Name = "xrTable2"
        Me.xrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow2})
        Me.xrTable2.SizeF = New System.Drawing.SizeF(512.0834F, 23.99998F)
        Me.xrTable2.StylePriority.UseBorders = False
        Me.xrTable2.StylePriority.UseTextAlignment = False
        Me.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        ' 
        ' xrTableRow2
        ' 
        Me.xrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {
            Me.xrTableCell4,
            Me.xrTableCell5,
            Me.xrTableCell7,
            Me.xrTableCell6,
            Me.xrTableCell8})
        Me.xrTableRow2.Name = "xrTableRow2"
        Me.xrTableRow2.Weight = 1D
        ' 
        ' xrTableCell4
        ' 
        Me.xrTableCell4.Name = "xrTableCell4"
        Me.xrTableCell4.Text = "[From]"
        Me.xrTableCell4.Weight = 1D
        ' 
        ' xrTableCell5
        ' 
        Me.xrTableCell5.Name = "xrTableCell5"
        Me.xrTableCell5.Text = "[Subject]"
        Me.xrTableCell5.Weight = 1D
        ' 
        ' xrTableCell7
        ' 
        Me.xrTableCell7.Name = "xrTableCell7"
        Me.xrTableCell7.Text = "[Sent]"
        Me.xrTableCell7.Weight = 1.0000001360040369D
        ' 
        ' xrTableCell6
        ' 
        Me.xrTableCell6.Name = "xrTableCell6"
        Me.xrTableCell6.Text = "[Size]"
        Me.xrTableCell6.Weight = 0.773958924860853D
        ' 
        ' xrTableCell8
        ' 
        Me.xrTableCell8.Name = "xrTableCell8"
        Me.xrTableCell8.Text = "[HasAttachment]"
        Me.xrTableCell8.Weight = 1.3468743159726309D
        ' 
        ' PageHeader
        ' 
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable1})
        Me.PageHeader.HeightF = 25.0F
        Me.PageHeader.Name = "PageHeader"
        Me.PageHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0F)
        Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        ' 
        ' xrTable1
        ' 
        Me.xrTable1.BorderColor = System.Drawing.Color.Black
        Me.xrTable1.Borders = (CType(((((DevExpress.XtraPrinting.BorderSide.Left Or
            DevExpress.XtraPrinting.BorderSide.Top) Or
            DevExpress.XtraPrinting.BorderSide.Right) Or
            DevExpress.XtraPrinting.BorderSide.Bottom)),
            DevExpress.XtraPrinting.BorderSide))
        Me.xrTable1.ForeColor = System.Drawing.Color.Blue
        Me.xrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0F, 0F)
        Me.xrTable1.Name = "xrTable1"
        Me.xrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow1})
        Me.xrTable1.SizeF = New System.Drawing.SizeF(512.0834F, 23.99998F)
        Me.xrTable1.StylePriority.UseBorderColor = False
        Me.xrTable1.StylePriority.UseBorders = False
        Me.xrTable1.StylePriority.UseForeColor = False
        ' 
        ' xrTableRow1
        ' 
        Me.xrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {
            Me.xrTableCell1,
            Me.xrTableCell2,
            Me.xrTableCell3,
            Me.xrTableCell9,
            Me.xrTableCell10})
        Me.xrTableRow1.Name = "xrTableRow1"
        Me.xrTableRow1.StylePriority.UseTextAlignment = False
        Me.xrTableRow1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrTableRow1.Weight = 1D
        ' 
        ' xrTableCell1
        ' 
        Me.xrTableCell1.Name = "xrTableCell1"
        Me.xrTableCell1.Text = "From"
        Me.xrTableCell1.Weight = 1D
        ' 
        ' xrTableCell2
        ' 
        Me.xrTableCell2.Name = "xrTableCell2"
        Me.xrTableCell2.Text = "Subject"
        Me.xrTableCell2.Weight = 1D
        ' 
        ' xrTableCell3
        ' 
        Me.xrTableCell3.Name = "xrTableCell3"
        Me.xrTableCell3.Text = "Sent"
        Me.xrTableCell3.Weight = 1.0000001360040369D
        ' 
        ' xrTableCell9
        ' 
        Me.xrTableCell9.BorderColor = System.Drawing.Color.Black
        Me.xrTableCell9.Name = "xrTableCell9"
        Me.xrTableCell9.StylePriority.UseBorderColor = False
        Me.xrTableCell9.Text = "Size"
        Me.xrTableCell9.Weight = 0.773958924860853D
        ' 
        ' xrTableCell10
        ' 
        Me.xrTableCell10.Name = "xrTableCell10"
        Me.xrTableCell10.Text = "Attachment?"
        Me.xrTableCell10.Weight = 1.3468743159726309D
        ' 
        ' PageFooter
        ' 
        Me.PageFooter.HeightF = 147.9167F
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0F)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        ' 
        ' TopMargin
        ' 
        Me.TopMargin.Name = "TopMargin"
        ' 
        ' BottomMargin
        ' 
        Me.BottomMargin.Name = "BottomMargin"
        ' 
        ' XtraReport1
        ' 
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {
            Me.Detail,
            Me.PageHeader,
            Me.PageFooter,
            Me.TopMargin,
            Me.BottomMargin})
        Me.Version = "18.2"
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub
    Private PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Private PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Private TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Private BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Private Detail As DevExpress.XtraReports.UI.DetailBand
    Private xrTable2 As DevExpress.XtraReports.UI.XRTable
    Private xrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Private xrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Private xrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Private xrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Private xrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Private xrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Private xrTable1 As DevExpress.XtraReports.UI.XRTable
    Private xrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Private xrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Private xrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Private xrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Private xrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Private xrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
#End Region

End Class