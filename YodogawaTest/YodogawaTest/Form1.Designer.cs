
namespace YodogawaTest
{
	partial class TestConsolForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl = new System.Windows.Forms.TabControl();
			this.gatePage = new System.Windows.Forms.TabPage();
			this.gateDataGridView = new System.Windows.Forms.DataGridView();
			this.gatePointName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gateValueStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.gateValueView = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gateValueUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gateValueChange = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.sekiPage = new System.Windows.Forms.TabPage();
			this.sekiDataGridView = new System.Windows.Forms.DataGridView();
			this.sekiPointName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sekiValueStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.sekiValueView = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sekiValueUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sekiValueChange = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.riverPage = new System.Windows.Forms.TabPage();
			this.riverDataGridView = new System.Windows.Forms.DataGridView();
			this.riverPointName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.riverValueStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.riverValueView = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.riverValueUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.riverValueChange = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.damPage = new System.Windows.Forms.TabPage();
			this.damDataGridView = new System.Windows.Forms.DataGridView();
			this.damPointName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.damValueStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.damValueView = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.damValueUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.damValueChange = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.rainPage = new System.Windows.Forms.TabPage();
			this.rainDataGridView = new System.Windows.Forms.DataGridView();
			this.rainPointName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rainValueStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.rainValueView = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rainValueUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rainValueChange = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.refreshButton = new System.Windows.Forms.CheckBox();
			this.updateButton = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.gatePage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gateDataGridView)).BeginInit();
			this.sekiPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sekiDataGridView)).BeginInit();
			this.riverPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.riverDataGridView)).BeginInit();
			this.damPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.damDataGridView)).BeginInit();
			this.rainPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rainDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.gatePage);
			this.tabControl.Controls.Add(this.sekiPage);
			this.tabControl.Controls.Add(this.riverPage);
			this.tabControl.Controls.Add(this.damPage);
			this.tabControl.Controls.Add(this.rainPage);
			this.tabControl.Location = new System.Drawing.Point(12, 12);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(786, 850);
			this.tabControl.TabIndex = 1;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
			// 
			// gatePage
			// 
			this.gatePage.Controls.Add(this.gateDataGridView);
			this.gatePage.Location = new System.Drawing.Point(4, 22);
			this.gatePage.Name = "gatePage";
			this.gatePage.Size = new System.Drawing.Size(778, 824);
			this.gatePage.TabIndex = 4;
			this.gatePage.Text = "ゲート";
			this.gatePage.UseVisualStyleBackColor = true;
			// 
			// gateDataGridView
			// 
			this.gateDataGridView.AllowUserToAddRows = false;
			this.gateDataGridView.AllowUserToDeleteRows = false;
			this.gateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gateDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gatePointName,
            this.gateValueStatus,
            this.gateValueView,
            this.gateValueUpdate,
            this.gateValueChange});
			this.gateDataGridView.Location = new System.Drawing.Point(0, 0);
			this.gateDataGridView.Name = "gateDataGridView";
			this.gateDataGridView.RowTemplate.Height = 21;
			this.gateDataGridView.Size = new System.Drawing.Size(785, 825);
			this.gateDataGridView.TabIndex = 0;
			this.gateDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gateDataGridView_CellEnter);
			// 
			// gatePointName
			// 
			this.gatePointName.HeaderText = "観測地点";
			this.gatePointName.Name = "gatePointName";
			this.gatePointName.Width = 180;
			// 
			// gateValueStatus
			// 
			this.gateValueStatus.HeaderText = "観測データ状態";
			this.gateValueStatus.Name = "gateValueStatus";
			// 
			// gateValueView
			// 
			this.gateValueView.HeaderText = "観測データ表示";
			this.gateValueView.Name = "gateValueView";
			this.gateValueView.Width = 120;
			// 
			// gateValueUpdate
			// 
			this.gateValueUpdate.HeaderText = "観測データ編集";
			this.gateValueUpdate.Name = "gateValueUpdate";
			this.gateValueUpdate.Width = 120;
			// 
			// gateValueChange
			// 
			this.gateValueChange.HeaderText = "観測データ変化";
			this.gateValueChange.Name = "gateValueChange";
			// 
			// sekiPage
			// 
			this.sekiPage.Controls.Add(this.sekiDataGridView);
			this.sekiPage.Location = new System.Drawing.Point(4, 22);
			this.sekiPage.Name = "sekiPage";
			this.sekiPage.Padding = new System.Windows.Forms.Padding(3);
			this.sekiPage.Size = new System.Drawing.Size(778, 824);
			this.sekiPage.TabIndex = 0;
			this.sekiPage.Text = "大堰周辺";
			this.sekiPage.UseVisualStyleBackColor = true;
			// 
			// sekiDataGridView
			// 
			this.sekiDataGridView.AllowUserToAddRows = false;
			this.sekiDataGridView.AllowUserToDeleteRows = false;
			this.sekiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.sekiDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sekiPointName,
            this.sekiValueStatus,
            this.sekiValueView,
            this.sekiValueUpdate,
            this.sekiValueChange});
			this.sekiDataGridView.Location = new System.Drawing.Point(-2, 0);
			this.sekiDataGridView.Name = "sekiDataGridView";
			this.sekiDataGridView.RowTemplate.Height = 21;
			this.sekiDataGridView.Size = new System.Drawing.Size(785, 825);
			this.sekiDataGridView.TabIndex = 1;
			this.sekiDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.sekiDataGridView_CellEnter);
			// 
			// sekiPointName
			// 
			this.sekiPointName.HeaderText = "観測地点";
			this.sekiPointName.Name = "sekiPointName";
			this.sekiPointName.Width = 180;
			// 
			// sekiValueStatus
			// 
			this.sekiValueStatus.HeaderText = "観測データ状態";
			this.sekiValueStatus.Name = "sekiValueStatus";
			// 
			// sekiValueView
			// 
			this.sekiValueView.HeaderText = "観測データ表示";
			this.sekiValueView.Name = "sekiValueView";
			this.sekiValueView.Width = 120;
			// 
			// sekiValueUpdate
			// 
			this.sekiValueUpdate.HeaderText = "観測データ編集";
			this.sekiValueUpdate.Name = "sekiValueUpdate";
			this.sekiValueUpdate.Width = 120;
			// 
			// sekiValueChange
			// 
			this.sekiValueChange.HeaderText = "観測データ変化";
			this.sekiValueChange.Name = "sekiValueChange";
			// 
			// riverPage
			// 
			this.riverPage.Controls.Add(this.riverDataGridView);
			this.riverPage.Location = new System.Drawing.Point(4, 22);
			this.riverPage.Name = "riverPage";
			this.riverPage.Padding = new System.Windows.Forms.Padding(3);
			this.riverPage.Size = new System.Drawing.Size(778, 824);
			this.riverPage.TabIndex = 1;
			this.riverPage.Text = "河川";
			this.riverPage.UseVisualStyleBackColor = true;
			// 
			// riverDataGridView
			// 
			this.riverDataGridView.AllowUserToAddRows = false;
			this.riverDataGridView.AllowUserToDeleteRows = false;
			this.riverDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.riverDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.riverPointName,
            this.riverValueStatus,
            this.riverValueView,
            this.riverValueUpdate,
            this.riverValueChange});
			this.riverDataGridView.Location = new System.Drawing.Point(-2, 0);
			this.riverDataGridView.Name = "riverDataGridView";
			this.riverDataGridView.RowTemplate.Height = 21;
			this.riverDataGridView.Size = new System.Drawing.Size(785, 825);
			this.riverDataGridView.TabIndex = 1;
			this.riverDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.riverDataGridView_CellEnter);
			// 
			// riverPointName
			// 
			this.riverPointName.HeaderText = "観測地点";
			this.riverPointName.Name = "riverPointName";
			this.riverPointName.Width = 150;
			// 
			// riverValueStatus
			// 
			this.riverValueStatus.HeaderText = "観測データ状態";
			this.riverValueStatus.Name = "riverValueStatus";
			// 
			// riverValueView
			// 
			this.riverValueView.HeaderText = "観測データ表示";
			this.riverValueView.Name = "riverValueView";
			this.riverValueView.Width = 120;
			// 
			// riverValueUpdate
			// 
			this.riverValueUpdate.HeaderText = "観測データ編集";
			this.riverValueUpdate.Name = "riverValueUpdate";
			this.riverValueUpdate.Width = 120;
			// 
			// riverValueChange
			// 
			this.riverValueChange.HeaderText = "観測データ変化";
			this.riverValueChange.Name = "riverValueChange";
			// 
			// damPage
			// 
			this.damPage.Controls.Add(this.damDataGridView);
			this.damPage.Location = new System.Drawing.Point(4, 22);
			this.damPage.Name = "damPage";
			this.damPage.Padding = new System.Windows.Forms.Padding(3);
			this.damPage.Size = new System.Drawing.Size(778, 824);
			this.damPage.TabIndex = 2;
			this.damPage.Text = "ダム";
			this.damPage.UseVisualStyleBackColor = true;
			// 
			// damDataGridView
			// 
			this.damDataGridView.AllowUserToAddRows = false;
			this.damDataGridView.AllowUserToDeleteRows = false;
			this.damDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.damDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.damPointName,
            this.damValueStatus,
            this.damValueView,
            this.damValueUpdate,
            this.damValueChange});
			this.damDataGridView.Location = new System.Drawing.Point(-2, 0);
			this.damDataGridView.Name = "damDataGridView";
			this.damDataGridView.RowTemplate.Height = 21;
			this.damDataGridView.Size = new System.Drawing.Size(785, 825);
			this.damDataGridView.TabIndex = 1;
			this.damDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.damDataGridView_CellEnter);
			// 
			// damPointName
			// 
			this.damPointName.HeaderText = "観測地点";
			this.damPointName.Name = "damPointName";
			this.damPointName.Width = 150;
			// 
			// damValueStatus
			// 
			this.damValueStatus.HeaderText = "観測データ状態";
			this.damValueStatus.Name = "damValueStatus";
			// 
			// damValueView
			// 
			this.damValueView.HeaderText = "観測データ表示";
			this.damValueView.Name = "damValueView";
			this.damValueView.Width = 120;
			// 
			// damValueUpdate
			// 
			this.damValueUpdate.HeaderText = "観測データ編集";
			this.damValueUpdate.Name = "damValueUpdate";
			this.damValueUpdate.Width = 120;
			// 
			// damValueChange
			// 
			this.damValueChange.HeaderText = "観測データ変化";
			this.damValueChange.Name = "damValueChange";
			// 
			// rainPage
			// 
			this.rainPage.Controls.Add(this.rainDataGridView);
			this.rainPage.Location = new System.Drawing.Point(4, 22);
			this.rainPage.Name = "rainPage";
			this.rainPage.Padding = new System.Windows.Forms.Padding(3);
			this.rainPage.Size = new System.Drawing.Size(778, 824);
			this.rainPage.TabIndex = 3;
			this.rainPage.Text = "雨量";
			this.rainPage.UseVisualStyleBackColor = true;
			// 
			// rainDataGridView
			// 
			this.rainDataGridView.AllowUserToAddRows = false;
			this.rainDataGridView.AllowUserToDeleteRows = false;
			this.rainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.rainDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rainPointName,
            this.rainValueStatus,
            this.rainValueView,
            this.rainValueUpdate,
            this.rainValueChange});
			this.rainDataGridView.Location = new System.Drawing.Point(-2, 0);
			this.rainDataGridView.Name = "rainDataGridView";
			this.rainDataGridView.RowTemplate.Height = 21;
			this.rainDataGridView.Size = new System.Drawing.Size(785, 825);
			this.rainDataGridView.TabIndex = 1;
			this.rainDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.rainDataGridView_CellEnter);
			// 
			// rainPointName
			// 
			this.rainPointName.HeaderText = "観測地点";
			this.rainPointName.Name = "rainPointName";
			this.rainPointName.Width = 150;
			// 
			// rainValueStatus
			// 
			this.rainValueStatus.HeaderText = "観測データ状態";
			this.rainValueStatus.Name = "rainValueStatus";
			// 
			// rainValueView
			// 
			this.rainValueView.HeaderText = "観測データ表示";
			this.rainValueView.Name = "rainValueView";
			this.rainValueView.Width = 120;
			// 
			// rainValueUpdate
			// 
			this.rainValueUpdate.HeaderText = "観測データ編集";
			this.rainValueUpdate.Name = "rainValueUpdate";
			this.rainValueUpdate.Width = 120;
			// 
			// rainValueChange
			// 
			this.rainValueChange.HeaderText = "観測データ変化";
			this.rainValueChange.Name = "rainValueChange";
			// 
			// refreshButton
			// 
			this.refreshButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.refreshButton.Location = new System.Drawing.Point(12, 866);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(104, 34);
			this.refreshButton.TabIndex = 2;
			this.refreshButton.Text = "最新データ表示";
			this.refreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.CheckedChanged += new System.EventHandler(this.refreshButton_CheckedChanged);
			// 
			// updateButton
			// 
			this.updateButton.Location = new System.Drawing.Point(700, 866);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(98, 33);
			this.updateButton.TabIndex = 3;
			this.updateButton.Text = "データ更新";
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// TestConsolForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(815, 911);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.refreshButton);
			this.Controls.Add(this.tabControl);
			this.Name = "TestConsolForm";
			this.Text = "淀川大堰テスト";
			this.Load += new System.EventHandler(this.TestConsolForm_Load);
			this.tabControl.ResumeLayout(false);
			this.gatePage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gateDataGridView)).EndInit();
			this.sekiPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sekiDataGridView)).EndInit();
			this.riverPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.riverDataGridView)).EndInit();
			this.damPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.damDataGridView)).EndInit();
			this.rainPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rainDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage sekiPage;
		private System.Windows.Forms.TabPage riverPage;
		private System.Windows.Forms.TabPage gatePage;
		private System.Windows.Forms.TabPage damPage;
		private System.Windows.Forms.TabPage rainPage;
		private System.Windows.Forms.DataGridView gateDataGridView;
		private System.Windows.Forms.DataGridView sekiDataGridView;
		private System.Windows.Forms.DataGridView riverDataGridView;
		private System.Windows.Forms.DataGridView damDataGridView;
		private System.Windows.Forms.DataGridView rainDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn riverPointName;
		private System.Windows.Forms.DataGridViewComboBoxColumn riverValueStatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn riverValueView;
		private System.Windows.Forms.DataGridViewTextBoxColumn riverValueUpdate;
		private System.Windows.Forms.DataGridViewComboBoxColumn riverValueChange;
		private System.Windows.Forms.DataGridViewTextBoxColumn damPointName;
		private System.Windows.Forms.DataGridViewComboBoxColumn damValueStatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn damValueView;
		private System.Windows.Forms.DataGridViewTextBoxColumn damValueUpdate;
		private System.Windows.Forms.DataGridViewComboBoxColumn damValueChange;
		private System.Windows.Forms.DataGridViewTextBoxColumn rainPointName;
		private System.Windows.Forms.DataGridViewComboBoxColumn rainValueStatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn rainValueView;
		private System.Windows.Forms.DataGridViewTextBoxColumn rainValueUpdate;
		private System.Windows.Forms.DataGridViewComboBoxColumn rainValueChange;
		private System.Windows.Forms.DataGridViewTextBoxColumn gatePointName;
		private System.Windows.Forms.DataGridViewComboBoxColumn gateValueStatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn gateValueView;
		private System.Windows.Forms.DataGridViewTextBoxColumn gateValueUpdate;
		private System.Windows.Forms.DataGridViewComboBoxColumn gateValueChange;
		private System.Windows.Forms.CheckBox refreshButton;
		private System.Windows.Forms.Button updateButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn sekiPointName;
		private System.Windows.Forms.DataGridViewComboBoxColumn sekiValueStatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn sekiValueView;
		private System.Windows.Forms.DataGridViewTextBoxColumn sekiValueUpdate;
		private System.Windows.Forms.DataGridViewComboBoxColumn sekiValueChange;
	}
}

