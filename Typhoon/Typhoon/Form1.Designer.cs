namespace Typhoon
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.数据刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新台风中心数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.台风生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.台风级别升降ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登陆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.离开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.总结查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.雨量分布ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.行政单元雨量分布ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前时间降水等值线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自由查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择查询时间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前台风中心位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.前24h雨量最大的10个测站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.台风中心附件30km雨量最大的10个测站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性查询ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.台风属性查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测站点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测站点显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.eagleMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mainMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rainMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eagleMapControl)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rainMapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 876);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1838, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据刷新ToolStripMenuItem,
            this.属性查询ToolStripMenuItem,
            this.总结查询ToolStripMenuItem,
            this.自由查询ToolStripMenuItem,
            this.属性查询ToolStripMenuItem1,
            this.测站点ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1838, 41);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 数据刷新ToolStripMenuItem
            // 
            this.数据刷新ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新台风中心数据ToolStripMenuItem,
            this.导出图像ToolStripMenuItem});
            this.数据刷新ToolStripMenuItem.Name = "数据刷新ToolStripMenuItem";
            this.数据刷新ToolStripMenuItem.Size = new System.Drawing.Size(130, 35);
            this.数据刷新ToolStripMenuItem.Text = "数据刷新";
            // 
            // 更新台风中心数据ToolStripMenuItem
            // 
            this.更新台风中心数据ToolStripMenuItem.Name = "更新台风中心数据ToolStripMenuItem";
            this.更新台风中心数据ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.更新台风中心数据ToolStripMenuItem.Text = "更新台风中心数据";
            this.更新台风中心数据ToolStripMenuItem.Click += new System.EventHandler(this.更新台风中心数据ToolStripMenuItem_Click);
            // 
            // 导出图像ToolStripMenuItem
            // 
            this.导出图像ToolStripMenuItem.Name = "导出图像ToolStripMenuItem";
            this.导出图像ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.导出图像ToolStripMenuItem.Text = "导出图像";
            this.导出图像ToolStripMenuItem.Click += new System.EventHandler(this.导出图像ToolStripMenuItem_Click);
            // 
            // 属性查询ToolStripMenuItem
            // 
            this.属性查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.台风生成ToolStripMenuItem,
            this.台风级别升降ToolStripMenuItem,
            this.登陆ToolStripMenuItem,
            this.离开ToolStripMenuItem,
            this.清空ToolStripMenuItem});
            this.属性查询ToolStripMenuItem.Name = "属性查询ToolStripMenuItem";
            this.属性查询ToolStripMenuItem.Size = new System.Drawing.Size(226, 35);
            this.属性查询ToolStripMenuItem.Text = "台风关键节点查询";
            // 
            // 台风生成ToolStripMenuItem
            // 
            this.台风生成ToolStripMenuItem.Name = "台风生成ToolStripMenuItem";
            this.台风生成ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.台风生成ToolStripMenuItem.Text = "台风生成";
            this.台风生成ToolStripMenuItem.Click += new System.EventHandler(this.台风生成ToolStripMenuItem_Click);
            // 
            // 台风级别升降ToolStripMenuItem
            // 
            this.台风级别升降ToolStripMenuItem.Name = "台风级别升降ToolStripMenuItem";
            this.台风级别升降ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.台风级别升降ToolStripMenuItem.Text = "台风级别升降";
            this.台风级别升降ToolStripMenuItem.Click += new System.EventHandler(this.台风级别升降ToolStripMenuItem_Click);
            // 
            // 登陆ToolStripMenuItem
            // 
            this.登陆ToolStripMenuItem.Name = "登陆ToolStripMenuItem";
            this.登陆ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.登陆ToolStripMenuItem.Text = "登陆";
            this.登陆ToolStripMenuItem.Click += new System.EventHandler(this.登陆ToolStripMenuItem_Click);
            // 
            // 离开ToolStripMenuItem
            // 
            this.离开ToolStripMenuItem.Name = "离开ToolStripMenuItem";
            this.离开ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.离开ToolStripMenuItem.Text = "离开";
            this.离开ToolStripMenuItem.Click += new System.EventHandler(this.离开ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // 总结查询ToolStripMenuItem
            // 
            this.总结查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.雨量分布ToolStripMenuItem,
            this.行政单元雨量分布ToolStripMenuItem,
            this.当前时间降水等值线ToolStripMenuItem});
            this.总结查询ToolStripMenuItem.Name = "总结查询ToolStripMenuItem";
            this.总结查询ToolStripMenuItem.Size = new System.Drawing.Size(178, 35);
            this.总结查询ToolStripMenuItem.Text = "降水数据查询";
            // 
            // 雨量分布ToolStripMenuItem
            // 
            this.雨量分布ToolStripMenuItem.Name = "雨量分布ToolStripMenuItem";
            this.雨量分布ToolStripMenuItem.Size = new System.Drawing.Size(363, 44);
            this.雨量分布ToolStripMenuItem.Text = "降水等值线";
            this.雨量分布ToolStripMenuItem.Click += new System.EventHandler(this.雨量分布ToolStripMenuItem_Click);
            // 
            // 行政单元雨量分布ToolStripMenuItem
            // 
            this.行政单元雨量分布ToolStripMenuItem.Name = "行政单元雨量分布ToolStripMenuItem";
            this.行政单元雨量分布ToolStripMenuItem.Size = new System.Drawing.Size(363, 44);
            this.行政单元雨量分布ToolStripMenuItem.Text = "行政单元雨量分布";
            this.行政单元雨量分布ToolStripMenuItem.Click += new System.EventHandler(this.行政单元雨量分布ToolStripMenuItem_Click);
            // 
            // 当前时间降水等值线ToolStripMenuItem
            // 
            this.当前时间降水等值线ToolStripMenuItem.Name = "当前时间降水等值线ToolStripMenuItem";
            this.当前时间降水等值线ToolStripMenuItem.Size = new System.Drawing.Size(363, 44);
            this.当前时间降水等值线ToolStripMenuItem.Text = "当前时间降水等值线";
            this.当前时间降水等值线ToolStripMenuItem.Click += new System.EventHandler(this.当前时间降水等值线ToolStripMenuItem_Click);
            // 
            // 自由查询ToolStripMenuItem
            // 
            this.自由查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择查询时间ToolStripMenuItem,
            this.当前台风中心位置ToolStripMenuItem,
            this.前24h雨量最大的10个测站ToolStripMenuItem,
            this.台风中心附件30km雨量最大的10个测站ToolStripMenuItem});
            this.自由查询ToolStripMenuItem.Name = "自由查询ToolStripMenuItem";
            this.自由查询ToolStripMenuItem.Size = new System.Drawing.Size(130, 35);
            this.自由查询ToolStripMenuItem.Text = "自由查询";
            // 
            // 选择查询时间ToolStripMenuItem
            // 
            this.选择查询时间ToolStripMenuItem.Name = "选择查询时间ToolStripMenuItem";
            this.选择查询时间ToolStripMenuItem.Size = new System.Drawing.Size(574, 44);
            this.选择查询时间ToolStripMenuItem.Text = "选择查询时间";
            // 
            // 当前台风中心位置ToolStripMenuItem
            // 
            this.当前台风中心位置ToolStripMenuItem.Name = "当前台风中心位置ToolStripMenuItem";
            this.当前台风中心位置ToolStripMenuItem.Size = new System.Drawing.Size(574, 44);
            this.当前台风中心位置ToolStripMenuItem.Text = "当前台风中心位置";
            // 
            // 前24h雨量最大的10个测站ToolStripMenuItem
            // 
            this.前24h雨量最大的10个测站ToolStripMenuItem.Name = "前24h雨量最大的10个测站ToolStripMenuItem";
            this.前24h雨量最大的10个测站ToolStripMenuItem.Size = new System.Drawing.Size(574, 44);
            this.前24h雨量最大的10个测站ToolStripMenuItem.Text = "前24h雨量最大的10个测站";
            // 
            // 台风中心附件30km雨量最大的10个测站ToolStripMenuItem
            // 
            this.台风中心附件30km雨量最大的10个测站ToolStripMenuItem.Name = "台风中心附件30km雨量最大的10个测站ToolStripMenuItem";
            this.台风中心附件30km雨量最大的10个测站ToolStripMenuItem.Size = new System.Drawing.Size(574, 44);
            this.台风中心附件30km雨量最大的10个测站ToolStripMenuItem.Text = "台风中心附件30km雨量最大的10个测站";
            // 
            // 属性查询ToolStripMenuItem1
            // 
            this.属性查询ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.台风属性查询ToolStripMenuItem});
            this.属性查询ToolStripMenuItem1.Name = "属性查询ToolStripMenuItem1";
            this.属性查询ToolStripMenuItem1.Size = new System.Drawing.Size(130, 35);
            this.属性查询ToolStripMenuItem1.Text = "属性查询";
            // 
            // 台风属性查询ToolStripMenuItem
            // 
            this.台风属性查询ToolStripMenuItem.Name = "台风属性查询ToolStripMenuItem";
            this.台风属性查询ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.台风属性查询ToolStripMenuItem.Text = "属性查询";
            this.台风属性查询ToolStripMenuItem.Click += new System.EventHandler(this.台风属性查询ToolStripMenuItem_Click);
            // 
            // 测站点ToolStripMenuItem
            // 
            this.测站点ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.测站点显示ToolStripMenuItem,
            this.渲染ToolStripMenuItem});
            this.测站点ToolStripMenuItem.Name = "测站点ToolStripMenuItem";
            this.测站点ToolStripMenuItem.Size = new System.Drawing.Size(106, 35);
            this.测站点ToolStripMenuItem.Text = "测站点";
            // 
            // 测站点显示ToolStripMenuItem
            // 
            this.测站点显示ToolStripMenuItem.Name = "测站点显示ToolStripMenuItem";
            this.测站点显示ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.测站点显示ToolStripMenuItem.Text = "测站点更新";
            this.测站点显示ToolStripMenuItem.Click += new System.EventHandler(this.测站点显示ToolStripMenuItem_Click);
            // 
            // 渲染ToolStripMenuItem
            // 
            this.渲染ToolStripMenuItem.Name = "渲染ToolStripMenuItem";
            this.渲染ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.渲染ToolStripMenuItem.Text = "雨量渲染";
            this.渲染ToolStripMenuItem.Click += new System.EventHandler(this.渲染ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 41);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.axToolbarControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1838, 835);
            this.splitContainer1.SplitterDistance = 53;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 2;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 0);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(6);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1838, 28);
            this.axToolbarControl1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Panel2.Controls.Add(this.axLicenseControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1838, 779);
            this.splitContainer2.SplitterDistance = 487;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.eagleMapControl);
            this.splitContainer3.Size = new System.Drawing.Size(487, 779);
            this.splitContainer3.SplitterDistance = 371;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(487, 371);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "时间选择";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(136, 259);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 46);
            this.button2.TabIndex = 4;
            this.button2.Text = "雨量数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(60, 120);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker2.MaxDate = new System.DateTime(2020, 8, 7, 0, 0, 0, 0);
            this.dateTimePicker2.MinDate = new System.DateTime(2020, 8, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(278, 35);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.Value = new System.DateTime(2020, 8, 7, 0, 0, 0, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(60, 70);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker1.MaxDate = new System.DateTime(2020, 8, 7, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2020, 8, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(278, 35);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.Value = new System.DateTime(2020, 8, 1, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 186);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "显示";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // eagleMapControl
            // 
            this.eagleMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eagleMapControl.Location = new System.Drawing.Point(0, 0);
            this.eagleMapControl.Margin = new System.Windows.Forms.Padding(6);
            this.eagleMapControl.Name = "eagleMapControl";
            this.eagleMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("eagleMapControl.OcxState")));
            this.eagleMapControl.Size = new System.Drawing.Size(487, 405);
            this.eagleMapControl.TabIndex = 0;
            this.eagleMapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.eagleMapControl_OnMouseDown);
            this.eagleMapControl.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.eagleMapControl_OnMouseUp);
            this.eagleMapControl.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.eagleMapControl_OnMouseMove);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1347, 779);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mainMapControl);
            this.tabPage1.Location = new System.Drawing.Point(8, 8);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(1331, 732);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "台风视图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mainMapControl
            // 
            this.mainMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMapControl.Location = new System.Drawing.Point(4, 3);
            this.mainMapControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mainMapControl.Name = "mainMapControl";
            this.mainMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainMapControl.OcxState")));
            this.mainMapControl.Size = new System.Drawing.Size(1323, 726);
            this.mainMapControl.TabIndex = 0;
            this.mainMapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.mainMapControl_OnMouseDown);
            this.mainMapControl.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.mainMapControl_OnMouseMove);
            this.mainMapControl.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.mainMapControl_OnExtentUpdated);
            this.mainMapControl.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.mainMapControl_OnMapReplaced);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rainMapControl);
            this.tabPage2.Location = new System.Drawing.Point(8, 8);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Size = new System.Drawing.Size(1331, 732);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "降水视图";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rainMapControl
            // 
            this.rainMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rainMapControl.Location = new System.Drawing.Point(4, 3);
            this.rainMapControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rainMapControl.Name = "rainMapControl";
            this.rainMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rainMapControl.OcxState")));
            this.rainMapControl.Size = new System.Drawing.Size(1323, 726);
            this.rainMapControl.TabIndex = 0;
            this.rainMapControl.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.rainMapControl_OnExtentUpdated);
            this.rainMapControl.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.rainMapControl_OnMapReplaced);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(173, 163);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(6);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1838, 898);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eagleMapControl)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rainMapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private ESRI.ArcGIS.Controls.AxMapControl eagleMapControl;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripMenuItem 属性查询ToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem 数据刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新台风中心数据ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ESRI.ArcGIS.Controls.AxMapControl mainMapControl;
        private System.Windows.Forms.TabPage tabPage2;
        private ESRI.ArcGIS.Controls.AxMapControl rainMapControl;
        private System.Windows.Forms.ToolStripMenuItem 导出图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 台风生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 台风级别升降ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登陆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 离开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 总结查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 雨量分布ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 行政单元雨量分布ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自由查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择查询时间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当前台风中心位置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 前24h雨量最大的10个测站ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 台风中心附件30km雨量最大的10个测站ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem 属性查询ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 台风属性查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测站点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测站点显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 渲染ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当前时间降水等值线ToolStripMenuItem;
    }
}

