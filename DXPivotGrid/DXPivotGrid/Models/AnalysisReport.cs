using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DXPivotGrid.Models
{
    [Serializable]
    public class AnalysisReport
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // 0: Data warehouse, 1: Cube
        public TenantServiceType DataSourceType { get; set; }

        public string DataSource { get; set; }

        public string Layout { get; set; }

        public string CollapseState { get; set; }

        public InsightContentType ReportType { get; set; }
        public string ReportTag { get; set; }
        public string CubeConnectionString { get; set; }
        public string ReportServerUrl { get; set; }
        public DataSet ReportDataSet { get; set; }
        public string ReportPath { get; set; }
        public Dictionary<string, ReportFieldMetadata> ReportFields { get; set; }
    }

    public enum TenantServiceType
    {
        Warehouse = 0,
        Cube = 1,
        ReportService = 2,
        Translation = 3,
        Lading = 4,
        Staging = 5
    }

    public enum InsightContentType
    {
        NotDefined = 0,
        AnalysisReportDefinition = 1,
        CustomReportDefinition = 2,
        QuickReport = 3,
        DataRelationship = 4,
        Dataset = 5,
        KpiDefinition = 6,
        KpiManualAmountDefinition = 7,
        KpiDashboardDefinition = 9,
        InformationTile = 10,
        PowerBiReport = 100
    }

    [Serializable]
    public class ReportFieldMetadata
    {
        public string Caption { get; set; }
        public string FormatString { get; set; }
    }
}