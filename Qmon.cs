using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Media;

namespace UVapQmonitor
{

	public class Qmon : System.Windows.Forms.Form
	{
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private UVapQmonitor.DataSet1 UVqDataset;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Windows.Forms.Timer RefreshTimer;
		private System.Windows.Forms.DataGrid ViewGrid;
		private System.Windows.Forms.CheckBox cboxComplete;
		private System.Windows.Forms.CheckBox cboxErrs;
		private System.Data.DataView UVqDataView;
		private System.Windows.Forms.Label lblEnqueued;
		private System.Windows.Forms.Label lblErrors;
		private System.ComponentModel.IContainer components;
		private string PrevEnqueueCount = "0";
		private System.Windows.Forms.Label lblSQLerr;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		private UVapQmonitor.dsMWqLen dsMWqLen1;
		private string PrevErrorCount = "0";
		private string ThisQcount = "";
        private string ThisLcount = "";
		private string PrevQueCount = "0";
		private int CycleCounter = 0;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
        private System.Data.SqlClient.SqlCommand sqlCommand2b;
        private dsLatencyRows dsLatencyRows1;
        private Timer AlertTimer;
		private string HasAlert = "";

		public Qmon()
		{
	
			InitializeComponent();

		}


		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Qmon));
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.UVqDataset = new UVapQmonitor.DataSet1();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.ViewGrid = new System.Windows.Forms.DataGrid();
            this.UVqDataView = new System.Data.DataView();
            this.cboxComplete = new System.Windows.Forms.CheckBox();
            this.cboxErrs = new System.Windows.Forms.CheckBox();
            this.lblEnqueued = new System.Windows.Forms.Label();
            this.lblErrors = new System.Windows.Forms.Label();
            this.lblSQLerr = new System.Windows.Forms.Label();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
            this.dsMWqLen1 = new UVapQmonitor.dsMWqLen();
            this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand2b = new System.Data.SqlClient.SqlCommand();
            this.dsLatencyRows1 = new UVapQmonitor.dsLatencyRows();
            this.AlertTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UVqDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UVqDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMWqLen1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLatencyRows1)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "workstation id=W286;packet size=4096;user id=sa;data source=\"HUMMER\\PRODUCTION\";p" +
    "ersist security info=True;initial catalog=Automation;password=tstar3";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlDataAdapter1
            // 
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "BarCode_MW_WO_Parms", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("WorkOrderNum", "WorkOrderNum"),
                        new System.Data.Common.DataColumnMapping("TranxTargetID", "TranxTargetID"),
                        new System.Data.Common.DataColumnMapping("TranxSeq", "TranxSeq"),
                        new System.Data.Common.DataColumnMapping("BusinessObject", "BusinessObject"),
                        new System.Data.Common.DataColumnMapping("DateTimeOfRequest", "DateTimeOfRequest"),
                        new System.Data.Common.DataColumnMapping("Requestor", "Requestor"),
                        new System.Data.Common.DataColumnMapping("TimeoutSeconds", "TimeoutSeconds"),
                        new System.Data.Common.DataColumnMapping("ProcessStatus", "ProcessStatus"),
                        new System.Data.Common.DataColumnMapping("EnqueuedDateTime", "EnqueuedDateTime"),
                        new System.Data.Common.DataColumnMapping("ErrSeverity", "ErrSeverity"),
                        new System.Data.Common.DataColumnMapping("ErrReason", "ErrReason"),
                        new System.Data.Common.DataColumnMapping("ParameterName", "ParameterName"),
                        new System.Data.Common.DataColumnMapping("ParameterValue", "ParameterValue")})});
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = resources.GetString("sqlInsertCommand1.CommandText");
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@WorkOrderNum", System.Data.SqlDbType.VarChar, 255, "WorkOrderNum"),
            new System.Data.SqlClient.SqlParameter("@TranxTargetID", System.Data.SqlDbType.Int, 4, "TranxTargetID"),
            new System.Data.SqlClient.SqlParameter("@TranxSeq", System.Data.SqlDbType.Int, 4, "TranxSeq"),
            new System.Data.SqlClient.SqlParameter("@BusinessObject", System.Data.SqlDbType.VarChar, 255, "BusinessObject"),
            new System.Data.SqlClient.SqlParameter("@DateTimeOfRequest", System.Data.SqlDbType.DateTime, 8, "DateTimeOfRequest"),
            new System.Data.SqlClient.SqlParameter("@Requestor", System.Data.SqlDbType.VarChar, 40, "Requestor"),
            new System.Data.SqlClient.SqlParameter("@TimeoutSeconds", System.Data.SqlDbType.Int, 4, "TimeoutSeconds"),
            new System.Data.SqlClient.SqlParameter("@ProcessStatus", System.Data.SqlDbType.VarChar, 10, "ProcessStatus"),
            new System.Data.SqlClient.SqlParameter("@EnqueuedDateTime", System.Data.SqlDbType.DateTime, 8, "EnqueuedDateTime"),
            new System.Data.SqlClient.SqlParameter("@ErrSeverity", System.Data.SqlDbType.SmallInt, 2, "ErrSeverity"),
            new System.Data.SqlClient.SqlParameter("@ErrReason", System.Data.SqlDbType.VarChar, 600, "ErrReason"),
            new System.Data.SqlClient.SqlParameter("@ParameterName", System.Data.SqlDbType.VarChar, 40, "ParameterName"),
            new System.Data.SqlClient.SqlParameter("@ParameterValue", System.Data.SqlDbType.VarChar, 255, "ParameterValue")});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // UVqDataset
            // 
            this.UVqDataset.DataSetName = "UVqQuery";
            this.UVqDataset.Locale = new System.Globalization.CultureInfo("en-US");
            this.UVqDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Enabled = true;
            this.RefreshTimer.Interval = 45000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // ViewGrid
            // 
            this.ViewGrid.DataMember = "";
            this.ViewGrid.DataSource = this.UVqDataView;
            this.ViewGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ViewGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.ViewGrid.Location = new System.Drawing.Point(0, 35);
            this.ViewGrid.Name = "ViewGrid";
            this.ViewGrid.Size = new System.Drawing.Size(536, 264);
            this.ViewGrid.TabIndex = 0;
            // 
            // UVqDataView
            // 
            this.UVqDataView.Table = this.UVqDataset.BarCode_MW_WO_Parms;
            // 
            // cboxComplete
            // 
            this.cboxComplete.Checked = true;
            this.cboxComplete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxComplete.Location = new System.Drawing.Point(256, 8);
            this.cboxComplete.Name = "cboxComplete";
            this.cboxComplete.Size = new System.Drawing.Size(112, 16);
            this.cboxComplete.TabIndex = 1;
            this.cboxComplete.Text = "Show Complete";
            // 
            // cboxErrs
            // 
            this.cboxErrs.Location = new System.Drawing.Point(384, 8);
            this.cboxErrs.Name = "cboxErrs";
            this.cboxErrs.Size = new System.Drawing.Size(80, 16);
            this.cboxErrs.TabIndex = 2;
            this.cboxErrs.Text = "Errors Only";
            // 
            // lblEnqueued
            // 
            this.lblEnqueued.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnqueued.Location = new System.Drawing.Point(16, 8);
            this.lblEnqueued.Name = "lblEnqueued";
            this.lblEnqueued.Size = new System.Drawing.Size(96, 16);
            this.lblEnqueued.TabIndex = 3;
            this.lblEnqueued.Text = "0 Enqueued";
            // 
            // lblErrors
            // 
            this.lblErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrors.Location = new System.Drawing.Point(120, 8);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(72, 16);
            this.lblErrors.TabIndex = 4;
            this.lblErrors.Text = "0 Errors";
            // 
            // lblSQLerr
            // 
            this.lblSQLerr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSQLerr.Location = new System.Drawing.Point(8, 8);
            this.lblSQLerr.Name = "lblSQLerr";
            this.lblSQLerr.Size = new System.Drawing.Size(192, 16);
            this.lblSQLerr.TabIndex = 5;
            this.lblSQLerr.Text = "Unavailable . . .";
            this.lblSQLerr.Visible = false;
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "SELECT HowMany FROM BarCode_MW_Q_Length";
            this.sqlSelectCommand2.Connection = this.sqlConnection1;
            // 
            // sqlInsertCommand2
            // 
            this.sqlInsertCommand2.CommandText = "INSERT INTO BarCode_MW_Q_Length(HowMany) VALUES (@HowMany); SELECT HowMany FROM B" +
    "arCode_MW_Q_Length";
            this.sqlInsertCommand2.Connection = this.sqlConnection1;
            this.sqlInsertCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@HowMany", System.Data.SqlDbType.Int, 4, "HowMany")});
            // 
            // sqlDataAdapter2
            // 
            this.sqlDataAdapter2.InsertCommand = this.sqlInsertCommand2;
            this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
            this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "BarCode_MW_Q_Length", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("HowMany", "HowMany")})});
            // 
            // dsMWqLen1
            // 
            this.dsMWqLen1.DataSetName = "dsMWqLen";
            this.dsMWqLen1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsMWqLen1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sqlDataAdapter3
            // 
            this.sqlDataAdapter3.SelectCommand = this.sqlCommand2b;
            this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Column1", "Column1")})});
            // 
            // sqlCommand2b
            // 
            this.sqlCommand2b.CommandText = "SELECT count([TranxTargetID])\r\n  FROM [Automation].[dbo].[BarCode_MW_Latency_Chec" +
    "k]";
            this.sqlCommand2b.Connection = this.sqlConnection1;
            // 
            // dsLatencyRows1
            // 
            this.dsLatencyRows1.DataSetName = "dsLatencyRows";
            this.dsLatencyRows1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AlertTimer
            // 
            this.AlertTimer.Interval = 60000;
            this.AlertTimer.Tick += new System.EventHandler(this.AlertTimer_Tick);
            // 
            // Qmon
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(536, 299);
            this.Controls.Add(this.lblSQLerr);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.lblEnqueued);
            this.Controls.Add(this.cboxErrs);
            this.Controls.Add(this.cboxComplete);
            this.Controls.Add(this.ViewGrid);
            this.MinimizeBox = false;
            this.Name = "Qmon";
            this.ShowInTaskbar = false;
            this.Text = "UV Async Q Monitor";
            this.Resize += new System.EventHandler(this.Qmon_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.UVqDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UVqDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMWqLen1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLatencyRows1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		[STAThread]
		static void Main() 
		{
			Application.Run(new Qmon());
		}

		private void RefreshTimer_Tick(object sender, System.EventArgs e)
		{
			if (this.Height < 64)
			{
                JustShowTotals();
				return;
			}

			this.Text = "UV Async Q Monitor";
			this.UVqDataset.Clear();
			string rf1 = "";
			string rf2 = "";
			if (this.cboxComplete.Checked == false)
				{rf1 = "ProcessStatus <> 'COMPLETED'";}
			else
				{rf1 = "";}
			if (this.cboxErrs.Checked == true)
				{rf2 = "ErrReason IS NOT NULL";}
			else
				{rf2 = "";}
			if ((rf1 != "") && (rf2 != ""))
				{this.UVqDataView.RowFilter = rf1 + " AND " + rf2;}
			else
				{this.UVqDataView.RowFilter = rf1 + rf2;}
			try
			{
				this.sqlDataAdapter1.Fill(this.UVqDataset);
				this.lblSQLerr.Visible = false;
			}
			catch
			    { this.lblSQLerr.Visible = true; }
            ShowSummaryTotals();
			this.Refresh();
		}

        private void ShowSummaryTotals()
        {
            string EnqueueCount = this.UVqDataset.Tables[0].Compute("Count(ProcessStatus)", "ProcessStatus = 'READY'").ToString();
            string ErrorCount = this.UVqDataset.Tables[0].Compute("Count(ProcessStatus)", "ErrSeverity = 2").ToString();
            this.lblEnqueued.Text = EnqueueCount + " Enqueued";
            this.lblErrors.Text = ErrorCount + " Errors";
            if ((EnqueueCount == "0") || (Convert.ToInt32(EnqueueCount) <= Convert.ToInt32(PrevEnqueueCount)))
            { this.lblEnqueued.Font = new Font(this.lblEnqueued.Font, FontStyle.Regular); }
            else
            {
                this.lblEnqueued.Font = new Font(this.lblEnqueued.Font, FontStyle.Bold);
                PrevEnqueueCount = EnqueueCount;
            }
            if ((ErrorCount == "0") || (Convert.ToInt32(ErrorCount) <= Convert.ToInt32(PrevErrorCount)))
            { this.lblErrors.Font = new Font(this.lblEnqueued.Font, FontStyle.Regular); }
            else
            {
                this.lblErrors.Font = new Font(this.lblEnqueued.Font, FontStyle.Bold);
                PrevErrorCount = ErrorCount;
            }
        }

        private void JustShowTotals()
        {
            this.dsMWqLen1.Clear();
            this.dsLatencyRows1.Clear();
            this.sqlDataAdapter2.Fill(this.dsMWqLen1);
            this.sqlDataAdapter3.Fill(this.dsLatencyRows1);
            CycleCounter++;

            ThisQcount = this.dsMWqLen1.Tables[0].Rows[0].ItemArray[0].ToString();
            ThisLcount = this.dsLatencyRows1.Tables[0].Rows[0].ItemArray[0].ToString();

            if (ThisQcount == "0")
            {
                HasAlert = "";
                this.RefreshTimer.Interval = 180000;
            }
            else { this.RefreshTimer.Interval = 45000; }
            if (Convert.ToInt32(ThisQcount) < Convert.ToInt32(PrevQueCount))
                 { HasAlert = ""; }
            this.Text = HasAlert + ThisQcount + "  " + ThisLcount;

            if (HasAlert == "")
                { this.AlertTimer.Enabled = false; }

            if (Convert.ToInt32(ThisQcount) > Convert.ToInt32(PrevQueCount))
                { PrevQueCount = ThisQcount; }

            if (CycleCounter == 3)
            {
                if (Convert.ToInt32(ThisQcount) >= Convert.ToInt32(PrevQueCount) && (Convert.ToInt32(ThisQcount) > 0)
                    && (Convert.ToInt32(PrevQueCount) > 0))
                        { HasAlert = "** ";
                        this.AlertTimer.Enabled = true;
                        this.Text = HasAlert + ThisQcount + "  " + ThisLcount;
                }
                else { HasAlert = ""; }
                
                CycleCounter = 0;
                PrevQueCount = ThisQcount;
            }
        }

		private void Qmon_Resize(object sender, System.EventArgs e)
		{
			this.ViewGrid.Height = this.Height - 65;
		}

        private void AlertTimer_Tick(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\jchapman\Documents\Visual Studio 2013\Projects\UVapQmonitor\airplane_chime_x.wav");
            simpleSound.Play();  
        }
	}
}
