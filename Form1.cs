using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AspenTech.ADSA;
using AspenTech.ProcessData;
using AspenTech.Time;

namespace PDTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
      private System.Windows.Forms.ComboBox cboDatasources;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox txtTag;
      private System.Windows.Forms.Button btnGetAttrData;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label lblDsStatus;
      private System.Windows.Forms.Button btnConnect;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label lblDsError;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.ComboBox cboMaps;
      private System.Windows.Forms.Button btnSetMap;
      private System.Windows.Forms.Button btnAddTag;

      public DataSources m_dss;
      private System.Windows.Forms.ComboBox cboAttributes;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ComboBox cboTypes;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.DateTimePicker dtBegin;
      private System.Windows.Forms.DateTimePicker dtEnd;
      private System.Windows.Forms.Label label15;
      private System.Windows.Forms.CheckBox chkStepped;
      private System.Windows.Forms.ListBox lstHistory;
      private System.Windows.Forms.Label lblQueryStatus;
      private System.Windows.Forms.TextBox txtMaxPoints;
      private System.Windows.Forms.Button btnGetHistory;
      
      private bool m_bTagAdded;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

         m_dss = new DataSourcesClass();
         
         if ( m_dss == null )
            this.Close();

         // Add data sources to drop down list
         if ( m_dss.Count > 0 )
         {
            for ( int i = 1; i <= m_dss.Count; i++ )
            {
               DataSource ds = m_dss.Item( i );
               this.cboDatasources.Items.Add( ds.Name );
            }
            this.cboDatasources.SelectedIndex = 0;
         }

         // Add history types
         this.cboTypes.Items.Add( "apdActual" );
         this.cboTypes.Items.Add( "apdBestFit" );
         this.cboTypes.SelectedIndex = 0;

         // Set start and end times for history queries
         System.TimeSpan ts = new TimeSpan( 2, 0, 0 );        
         this.dtEnd.Value = System.DateTime.Now;
         this.dtBegin.Value = this.dtEnd.Value.Subtract(ts);

         this.lstHistory.Items.Clear();

         m_bTagAdded = false;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
            m_dss = null;
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
         this.btnGetAttrData = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.cboDatasources = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.txtTag = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.lblDsStatus = new System.Windows.Forms.Label();
         this.btnConnect = new System.Windows.Forms.Button();
         this.label6 = new System.Windows.Forms.Label();
         this.lblDsError = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.cboMaps = new System.Windows.Forms.ComboBox();
         this.btnSetMap = new System.Windows.Forms.Button();
         this.btnAddTag = new System.Windows.Forms.Button();
         this.cboAttributes = new System.Windows.Forms.ComboBox();
         this.label10 = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.cboTypes = new System.Windows.Forms.ComboBox();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label11 = new System.Windows.Forms.Label();
         this.lblQueryStatus = new System.Windows.Forms.Label();
         this.label13 = new System.Windows.Forms.Label();
         this.label14 = new System.Windows.Forms.Label();
         this.dtBegin = new System.Windows.Forms.DateTimePicker();
         this.dtEnd = new System.Windows.Forms.DateTimePicker();
         this.txtMaxPoints = new System.Windows.Forms.TextBox();
         this.label15 = new System.Windows.Forms.Label();
         this.chkStepped = new System.Windows.Forms.CheckBox();
         this.btnGetHistory = new System.Windows.Forms.Button();
         this.lstHistory = new System.Windows.Forms.ListBox();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnGetAttrData
         // 
         this.btnGetAttrData.Enabled = false;
         this.btnGetAttrData.Location = new System.Drawing.Point(152, 257);
         this.btnGetAttrData.Name = "btnGetAttrData";
         this.btnGetAttrData.Size = new System.Drawing.Size(56, 21);
         this.btnGetAttrData.TabIndex = 15;
         this.btnGetAttrData.Text = "Get";
         this.btnGetAttrData.Click += new System.EventHandler(this.btnGetAttrData_Click);
         // 
         // label1
         // 
         this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.label1.Location = new System.Drawing.Point(8, 304);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(142, 19);
         this.label1.TabIndex = 17;
         this.label1.Text = "Tag Data Output";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // cboDatasources
         // 
         this.cboDatasources.Location = new System.Drawing.Point(8, 24);
         this.cboDatasources.Name = "cboDatasources";
         this.cboDatasources.Size = new System.Drawing.Size(144, 21);
         this.cboDatasources.TabIndex = 1;
         this.cboDatasources.SelectedIndexChanged += new System.EventHandler(this.cboDatasources_SelectedIndexChanged);
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(8, 8);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(112, 16);
         this.label2.TabIndex = 0;
         this.label2.Text = "Datasources";
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(8, 142);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(112, 16);
         this.label3.TabIndex = 7;
         this.label3.Text = "Tag";
         // 
         // txtTag
         // 
         this.txtTag.Location = new System.Drawing.Point(8, 158);
         this.txtTag.Name = "txtTag";
         this.txtTag.Size = new System.Drawing.Size(144, 20);
         this.txtTag.TabIndex = 8;
         this.txtTag.Text = "ATCAI";
         // 
         // label5
         // 
         this.label5.Location = new System.Drawing.Point(8, 51);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(80, 16);
         this.label5.TabIndex = 3;
         this.label5.Text = "Status";
         // 
         // lblDsStatus
         // 
         this.lblDsStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblDsStatus.Location = new System.Drawing.Point(8, 66);
         this.lblDsStatus.Name = "lblDsStatus";
         this.lblDsStatus.Size = new System.Drawing.Size(160, 20);
         this.lblDsStatus.TabIndex = 4;
         // 
         // btnConnect
         // 
         this.btnConnect.Location = new System.Drawing.Point(152, 24);
         this.btnConnect.Name = "btnConnect";
         this.btnConnect.Size = new System.Drawing.Size(56, 21);
         this.btnConnect.TabIndex = 2;
         this.btnConnect.Text = "Connect";
         this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
         // 
         // label6
         // 
         this.label6.Location = new System.Drawing.Point(8, 96);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(96, 16);
         this.label6.TabIndex = 5;
         this.label6.Text = "Error";
         // 
         // lblDsError
         // 
         this.lblDsError.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblDsError.Location = new System.Drawing.Point(8, 111);
         this.lblDsError.Name = "lblDsError";
         this.lblDsError.Size = new System.Drawing.Size(160, 20);
         this.lblDsError.TabIndex = 6;
         // 
         // label9
         // 
         this.label9.Location = new System.Drawing.Point(8, 191);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(112, 16);
         this.label9.TabIndex = 10;
         this.label9.Text = "Map";
         // 
         // cboMaps
         // 
         this.cboMaps.Enabled = false;
         this.cboMaps.Location = new System.Drawing.Point(8, 207);
         this.cboMaps.Name = "cboMaps";
         this.cboMaps.Size = new System.Drawing.Size(144, 21);
         this.cboMaps.TabIndex = 11;
         // 
         // btnSetMap
         // 
         this.btnSetMap.Enabled = false;
         this.btnSetMap.Location = new System.Drawing.Point(152, 207);
         this.btnSetMap.Name = "btnSetMap";
         this.btnSetMap.Size = new System.Drawing.Size(56, 21);
         this.btnSetMap.TabIndex = 12;
         this.btnSetMap.Text = "Set";
         this.btnSetMap.Click += new System.EventHandler(this.btnSetMap_Click);
         // 
         // btnAddTag
         // 
         this.btnAddTag.Location = new System.Drawing.Point(152, 159);
         this.btnAddTag.Name = "btnAddTag";
         this.btnAddTag.Size = new System.Drawing.Size(56, 21);
         this.btnAddTag.TabIndex = 9;
         this.btnAddTag.Text = "Add";
         this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
         // 
         // cboAttributes
         // 
         this.cboAttributes.Enabled = false;
         this.cboAttributes.Location = new System.Drawing.Point(8, 256);
         this.cboAttributes.Name = "cboAttributes";
         this.cboAttributes.Size = new System.Drawing.Size(144, 21);
         this.cboAttributes.TabIndex = 14;
         // 
         // label10
         // 
         this.label10.Location = new System.Drawing.Point(8, 240);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(112, 16);
         this.label10.TabIndex = 13;
         this.label10.Text = "Attribute";
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.lstHistory);
         this.groupBox1.Controls.Add(this.btnGetHistory);
         this.groupBox1.Controls.Add(this.chkStepped);
         this.groupBox1.Controls.Add(this.txtMaxPoints);
         this.groupBox1.Controls.Add(this.label15);
         this.groupBox1.Controls.Add(this.dtEnd);
         this.groupBox1.Controls.Add(this.dtBegin);
         this.groupBox1.Controls.Add(this.label14);
         this.groupBox1.Controls.Add(this.label13);
         this.groupBox1.Controls.Add(this.label11);
         this.groupBox1.Controls.Add(this.lblQueryStatus);
         this.groupBox1.Controls.Add(this.cboTypes);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Enabled = false;
         this.groupBox1.Location = new System.Drawing.Point(221, 8);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(451, 320);
         this.groupBox1.TabIndex = 18;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "History";
         // 
         // cboTypes
         // 
         this.cboTypes.Location = new System.Drawing.Point(8, 32);
         this.cboTypes.Name = "cboTypes";
         this.cboTypes.Size = new System.Drawing.Size(144, 21);
         this.cboTypes.TabIndex = 20;
         // 
         // label7
         // 
         this.label7.Location = new System.Drawing.Point(8, 16);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(112, 16);
         this.label7.TabIndex = 19;
         this.label7.Text = "Request Type";
         // 
         // label8
         // 
         this.label8.Location = new System.Drawing.Point(8, 288);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(112, 16);
         this.label8.TabIndex = 16;
         this.label8.Text = "Output";
         // 
         // label11
         // 
         this.label11.Location = new System.Drawing.Point(8, 264);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(112, 16);
         this.label11.TabIndex = 29;
         this.label11.Text = "Query Status";
         // 
         // lblQueryStatus
         // 
         this.lblQueryStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblQueryStatus.Location = new System.Drawing.Point(8, 280);
         this.lblQueryStatus.Name = "lblQueryStatus";
         this.lblQueryStatus.Size = new System.Drawing.Size(142, 32);
         this.lblQueryStatus.TabIndex = 30;
         this.lblQueryStatus.Text = "Query Status Output";
         // 
         // label13
         // 
         this.label13.Location = new System.Drawing.Point(8, 64);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(112, 16);
         this.label13.TabIndex = 21;
         this.label13.Text = "Begin Time";
         // 
         // label14
         // 
         this.label14.Location = new System.Drawing.Point(8, 112);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(112, 16);
         this.label14.TabIndex = 23;
         this.label14.Text = "End Time";
         // 
         // dtBegin
         // 
         this.dtBegin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
         this.dtBegin.Location = new System.Drawing.Point(8, 80);
         this.dtBegin.Name = "dtBegin";
         this.dtBegin.Size = new System.Drawing.Size(144, 20);
         this.dtBegin.TabIndex = 22;
         // 
         // dtEnd
         // 
         this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
         this.dtEnd.Location = new System.Drawing.Point(8, 128);
         this.dtEnd.Name = "dtEnd";
         this.dtEnd.Size = new System.Drawing.Size(144, 20);
         this.dtEnd.TabIndex = 24;
         // 
         // txtMaxPoints
         // 
         this.txtMaxPoints.Location = new System.Drawing.Point(8, 176);
         this.txtMaxPoints.Name = "txtMaxPoints";
         this.txtMaxPoints.Size = new System.Drawing.Size(144, 20);
         this.txtMaxPoints.TabIndex = 26;
         this.txtMaxPoints.Text = "1000";
         // 
         // label15
         // 
         this.label15.Location = new System.Drawing.Point(8, 160);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(112, 16);
         this.label15.TabIndex = 25;
         this.label15.Text = "Max Points";
         // 
         // chkStepped
         // 
         this.chkStepped.Location = new System.Drawing.Point(8, 208);
         this.chkStepped.Name = "chkStepped";
         this.chkStepped.Size = new System.Drawing.Size(144, 16);
         this.chkStepped.TabIndex = 27;
         this.chkStepped.Text = "Stepped";
         // 
         // btnGetHistory
         // 
         this.btnGetHistory.Location = new System.Drawing.Point(8, 232);
         this.btnGetHistory.Name = "btnGetHistory";
         this.btnGetHistory.Size = new System.Drawing.Size(56, 21);
         this.btnGetHistory.TabIndex = 28;
         this.btnGetHistory.Text = "Get";
         this.btnGetHistory.Click += new System.EventHandler(this.btnGetHistory_Click);
         // 
         // lstHistory
         // 
         this.lstHistory.Location = new System.Drawing.Point(168, 16);
         this.lstHistory.Name = "lstHistory";
         this.lstHistory.Size = new System.Drawing.Size(272, 290);
         this.lstHistory.TabIndex = 31;
         // 
         // Form1
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(680, 334);
         this.Controls.Add(this.label8);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.label10);
         this.Controls.Add(this.cboAttributes);
         this.Controls.Add(this.btnAddTag);
         this.Controls.Add(this.btnSetMap);
         this.Controls.Add(this.cboMaps);
         this.Controls.Add(this.label9);
         this.Controls.Add(this.txtTag);
         this.Controls.Add(this.lblDsError);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.btnConnect);
         this.Controls.Add(this.lblDsStatus);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.cboDatasources);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.btnGetAttrData);
         this.Name = "Form1";
         this.Text = "Process Data Interop Test";
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);

      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

      private void btnAddTag_Click(object sender, System.EventArgs e)
      {
         try
         {
            object oIdx = this.cboDatasources.SelectedItem.ToString();
            
            if ( this.lblDsStatus.Text.Length <= 0 )
               this.btnConnect.PerformClick();

            DataSource ds = m_dss.Item(oIdx);
            if ( ds == null )
               return;

            if ( m_bTagAdded )
            {
               // Remove all tags from the selected datasource
               ds.Tags.RemoveAll();
               m_bTagAdded = false;
               txtTag.Enabled = true;
               btnAddTag.Text = "Add";

               // Clear the map and attribute list, disable history
               this.cboMaps.Items.Clear();
               this.cboMaps.Enabled = false;
               this.btnSetMap.Enabled = false;
               this.cboAttributes.Items.Clear();
               this.cboAttributes.Enabled = false;
               this.btnGetAttrData.Enabled = false;
               this.lstHistory.Items.Clear();
               this.groupBox1.Enabled = false;
            }
            else
            {
               // Add the tag to the selected datasource
               Tag t = ds.Tags.Add( txtTag.Text.ToString() );
               m_bTagAdded = true;
               txtTag.Enabled = false;
               btnAddTag.Text = "Remove";
               Maps m = t.GetMaps();  
               AvailableAttrs attrs = t.GetAvailableAttrs();

               // Get maps and add to drop down list
               if ( m.Count > 0 )
               {
                  this.cboMaps.Enabled = true;
                  this.btnSetMap.Enabled = true;
                  for ( int i = 1; i <= m.Count; i++ )
                  {
                     this.cboMaps.Items.Add( m.Item( i ) );
                  }
                  this.cboMaps.SelectedIndex = 0;
               }

               // Get available attributes
               if ( attrs.Count > 0 )
               {
                  this.cboAttributes.Enabled = true;
                  this.btnGetAttrData.Enabled = true;
                  for ( int i = 1; i <= attrs.Count; i++ )
                  {
                     this.cboAttributes.Items.Add ( attrs.Item( i ).Name );
                  }
                  this.cboAttributes.SelectedIndex = 0;
               }
               this.groupBox1.Enabled = true;
            }
         }
         catch(System.Exception ex)
         {
            MessageBox.Show( ex.Message, "Add Tag Error" );
         }
      }

      private void btnConnect_Click(object sender, System.EventArgs e)
      {
         try
         {
            // Connect to data source
            object oIdx = this.cboDatasources.SelectedItem.ToString();
            DataSource ds = m_dss.Item( oIdx );
            ds.Connect();
            lblDsStatus.Text = ds.StatusString;
            lblDsError.Text = ds.ErrorString;
         }
         catch( System.Exception ex)
         {
            MessageBox.Show( ex.Message, "DataSource Connect Error" );
         }
      }

      private void btnGetAttrData_Click(object sender, System.EventArgs e)
      {
         try
         {
            // Get selected data source and tag
            object oIdx = this.cboDatasources.SelectedItem.ToString();         
            DataSource ds = m_dss.Item(oIdx);
            if ( ds == null )
               return;            
            if ( ds.Tags.Count == 0 )
               return;

            oIdx = 1;
            Tag t = ds.Tags.Item(oIdx);
            if ( t == null )
               return;

            // Remove any previously added attribute
            if ( t.Attributes.Count > 0 )
            {
               t.Attributes.RemoveAll();
            }

            // Add selected attribute, VAL if nonne
            string strAttr = this.cboAttributes.SelectedItem.ToString();
            if ( strAttr.Length <= 0 )
            {
               strAttr = "VAL";
            }
            AspenTech.ProcessData.Attribute a = t.Attributes.Add( strAttr );
            if ( a == null )
               return;

            // Read attribute data, async = false
            t.Attributes.Read( false );

            label1.Text = a.ValueAsString;
         }
         catch( System.Exception ex)
         {
            MessageBox.Show( ex.Message, "Get Attribute Data Error" );
         }
      }

      private void btnGetHistory_Click(object sender, System.EventArgs e)
      {
         try
         {
            // Clear old results
            this.lstHistory.Items.Clear();

            // Get selected data source and tag
            object oIdx = this.cboDatasources.SelectedItem.ToString();         
            DataSource ds = m_dss.Item(oIdx);
            if ( ds == null )
               return;
            if ( ds.Tags.Count == 0 )
               return;

            oIdx = 1;
            Tag t = ds.Tags.Item(oIdx);
            if ( t == null )
               return;

            // Get history query object
            HistoryQuery q = t.History.Query;
            if ( q == null )
               return;

            // Get selected request type
            apdHistoryTypeEnum type = apdHistoryTypeEnum.apdActual;            
            if ( cboTypes.SelectedIndex > 0 )
               type = apdHistoryTypeEnum.apdBestFit;

            // Set history query properties
            q.Type = type;
            q.BeginTime = this.dtBegin.Value;
            q.EndTime = this.dtEnd.Value;
            q.MaxPoints = System.Convert.ToInt32(this.txtMaxPoints.Text);
            q.Stepped = this.chkStepped.Checked;
                        
            // Read history, async = false
            t.History.Read( false );

            // Output query status text
            this.lblQueryStatus.Text = t.History.QueryStatus.StatusText;

            // Do we have samples?
            if ( t.History.Samples.Count > 0 )
            {
               object oSample;
               // Populate list box with raw samples data
               for ( int i = 1; i <= t.History.Samples.Count; i++ )
               {
                  // Output Time - Value pair
                  oSample = System.Convert.ToString(t.History.Samples.Item( i ).Time);
                  oSample += " - ";
                  oSample += System.Convert.ToString(t.History.Samples.Item( i ).Value);
                  lstHistory.Items.Add ( oSample );
               }
               // Show samples data table (formatted with level and status)
               t.History.Samples.ShowDataTable( t.Name );
            }
         }
         catch( System.Exception ex)
         {
            MessageBox.Show( ex.Message, "Get History Error" );
         }
      }   

      private void btnSetMap_Click(object sender, System.EventArgs e)
      {
         try
         {
            if ( this.cboMaps.Items.Count <= 0 )
               return;

            // Get selected map and set it for the selected data source and tag
            string strMap = this.cboMaps.SelectedItem.ToString();
            if ( strMap.Length > 0 )
            {
               object oIdx = this.cboDatasources.SelectedItem.ToString();
               DataSource ds = m_dss.Item(oIdx);
               if ( ds == null )
                  return;
               Tag t = ds.Tags.Item( 1 );
               if ( t == null )
                  return;
               t.SetMap( strMap );
            }
         }
         catch( System.Exception ex)
         {
            MessageBox.Show( ex.Message, "Set Map Error" );
         }
      }   

      private void cboDatasources_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         try
         {
            lblDsStatus.Text = string.Empty;
            lblDsError.Text = string.Empty;
            if ( m_dss.Item( cboDatasources.SelectedItem ).Tags.Count > 0 )
            {
               m_bTagAdded = true;
               txtTag.Enabled = false;
               btnAddTag.Text = "Remove";
               this.cboMaps.Enabled = true;
               this.btnSetMap.Enabled = true;
               this.cboAttributes.Enabled = true;
               this.btnGetAttrData.Enabled = true;
               this.groupBox1.Enabled = true;
            }
            else
            {
               m_bTagAdded = false;
               txtTag.Enabled = true;
               btnAddTag.Text = "Add";
               this.cboMaps.Enabled = false;
               this.btnSetMap.Enabled = false;
               this.cboAttributes.Enabled = false;
               this.btnGetAttrData.Enabled = false;
               this.groupBox1.Enabled = false;
            }
         }
         catch( System.Exception ex)
         {
            MessageBox.Show( ex.Message, "DataSource Selection Error" );
         }
      }
	}
}
