namespace g29_AutoDriving
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gb_WheelState = new System.Windows.Forms.GroupBox();
            this.btn_stop_state = new System.Windows.Forms.Button();
            this.lbl_wheel = new System.Windows.Forms.Label();
            this.txt_acc = new System.Windows.Forms.TextBox();
            this.txt_wheel = new System.Windows.Forms.TextBox();
            this.txt_brake = new System.Windows.Forms.TextBox();
            this.btn_getState = new System.Windows.Forms.Button();
            this.txt_clutch = new System.Windows.Forms.TextBox();
            this.lbl_clutch = new System.Windows.Forms.Label();
            this.lbl_acc = new System.Windows.Forms.Label();
            this.lbl_brake = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_rec = new System.Windows.Forms.Label();
            this.btn_view = new System.Windows.Forms.Button();
            this.btn_rec = new System.Windows.Forms.Button();
            this.lbl_wheelTarget = new System.Windows.Forms.Label();
            this.txt_wheelTarget = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_stop_laneTracking = new System.Windows.Forms.Button();
            this.btn_start_laneTracking = new System.Windows.Forms.Button();
            this.timer_wheelState = new System.Windows.Forms.Timer(this.components);
            this.timer_rec = new System.Windows.Forms.Timer(this.components);
            this.timer_endtoend = new System.Windows.Forms.Timer(this.components);
            this.worker_wheelState = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_stop_endtoend = new System.Windows.Forms.Button();
            this.btn_start_endtoend = new System.Windows.Forms.Button();
            this.timer_view = new System.Windows.Forms.Timer(this.components);
            this.timer_laneTracking = new System.Windows.Forms.Timer(this.components);
            this.btn_constant = new System.Windows.Forms.Button();
            this.btn_stop_conatant = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_WheelState.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(238, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gb_WheelState
            // 
            this.gb_WheelState.Controls.Add(this.btn_stop_state);
            this.gb_WheelState.Controls.Add(this.lbl_wheel);
            this.gb_WheelState.Controls.Add(this.txt_acc);
            this.gb_WheelState.Controls.Add(this.txt_wheel);
            this.gb_WheelState.Controls.Add(this.txt_brake);
            this.gb_WheelState.Controls.Add(this.btn_getState);
            this.gb_WheelState.Controls.Add(this.txt_clutch);
            this.gb_WheelState.Controls.Add(this.lbl_clutch);
            this.gb_WheelState.Controls.Add(this.lbl_acc);
            this.gb_WheelState.Controls.Add(this.lbl_brake);
            this.gb_WheelState.Location = new System.Drawing.Point(12, 37);
            this.gb_WheelState.Name = "gb_WheelState";
            this.gb_WheelState.Size = new System.Drawing.Size(220, 180);
            this.gb_WheelState.TabIndex = 56;
            this.gb_WheelState.TabStop = false;
            this.gb_WheelState.Text = "WheelState";
            // 
            // btn_stop_state
            // 
            this.btn_stop_state.Location = new System.Drawing.Point(107, 135);
            this.btn_stop_state.Name = "btn_stop_state";
            this.btn_stop_state.Size = new System.Drawing.Size(78, 23);
            this.btn_stop_state.TabIndex = 66;
            this.btn_stop_state.Text = "stop";
            this.btn_stop_state.UseVisualStyleBackColor = true;
            this.btn_stop_state.Click += new System.EventHandler(this.btn_stop_state_Click);
            // 
            // lbl_wheel
            // 
            this.lbl_wheel.AutoSize = true;
            this.lbl_wheel.Location = new System.Drawing.Point(21, 23);
            this.lbl_wheel.Name = "lbl_wheel";
            this.lbl_wheel.Size = new System.Drawing.Size(39, 12);
            this.lbl_wheel.TabIndex = 65;
            this.lbl_wheel.Text = "wheel";
            // 
            // txt_acc
            // 
            this.txt_acc.Location = new System.Drawing.Point(105, 47);
            this.txt_acc.MaxLength = 10;
            this.txt_acc.Name = "txt_acc";
            this.txt_acc.ReadOnly = true;
            this.txt_acc.Size = new System.Drawing.Size(80, 21);
            this.txt_acc.TabIndex = 57;
            this.txt_acc.Text = "0";
            // 
            // txt_wheel
            // 
            this.txt_wheel.Location = new System.Drawing.Point(105, 20);
            this.txt_wheel.MaxLength = 10;
            this.txt_wheel.Name = "txt_wheel";
            this.txt_wheel.ReadOnly = true;
            this.txt_wheel.Size = new System.Drawing.Size(80, 21);
            this.txt_wheel.TabIndex = 64;
            this.txt_wheel.Text = "0";
            // 
            // txt_brake
            // 
            this.txt_brake.Location = new System.Drawing.Point(105, 74);
            this.txt_brake.MaxLength = 10;
            this.txt_brake.Name = "txt_brake";
            this.txt_brake.ReadOnly = true;
            this.txt_brake.Size = new System.Drawing.Size(80, 21);
            this.txt_brake.TabIndex = 58;
            this.txt_brake.Text = "0";
            // 
            // btn_getState
            // 
            this.btn_getState.Location = new System.Drawing.Point(23, 135);
            this.btn_getState.Name = "btn_getState";
            this.btn_getState.Size = new System.Drawing.Size(78, 23);
            this.btn_getState.TabIndex = 63;
            this.btn_getState.Text = "get state";
            this.btn_getState.UseVisualStyleBackColor = true;
            this.btn_getState.Click += new System.EventHandler(this.btn_getState_Click);
            // 
            // txt_clutch
            // 
            this.txt_clutch.Location = new System.Drawing.Point(105, 101);
            this.txt_clutch.MaxLength = 10;
            this.txt_clutch.Name = "txt_clutch";
            this.txt_clutch.ReadOnly = true;
            this.txt_clutch.Size = new System.Drawing.Size(80, 21);
            this.txt_clutch.TabIndex = 59;
            this.txt_clutch.Text = "0";
            // 
            // lbl_clutch
            // 
            this.lbl_clutch.AutoSize = true;
            this.lbl_clutch.Location = new System.Drawing.Point(21, 104);
            this.lbl_clutch.Name = "lbl_clutch";
            this.lbl_clutch.Size = new System.Drawing.Size(39, 12);
            this.lbl_clutch.TabIndex = 62;
            this.lbl_clutch.Text = "clutch";
            // 
            // lbl_acc
            // 
            this.lbl_acc.AutoSize = true;
            this.lbl_acc.Location = new System.Drawing.Point(21, 50);
            this.lbl_acc.Name = "lbl_acc";
            this.lbl_acc.Size = new System.Drawing.Size(68, 12);
            this.lbl_acc.TabIndex = 60;
            this.lbl_acc.Text = "accelerator";
            // 
            // lbl_brake
            // 
            this.lbl_brake.AutoSize = true;
            this.lbl_brake.Location = new System.Drawing.Point(21, 77);
            this.lbl_brake.Name = "lbl_brake";
            this.lbl_brake.Size = new System.Drawing.Size(36, 12);
            this.lbl_brake.TabIndex = 61;
            this.lbl_brake.Text = "brake";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_rec);
            this.groupBox1.Controls.Add(this.btn_view);
            this.groupBox1.Controls.Add(this.btn_rec);
            this.groupBox1.Location = new System.Drawing.Point(12, 330);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 62);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rec";
            // 
            // lbl_rec
            // 
            this.lbl_rec.AutoSize = true;
            this.lbl_rec.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_rec.ForeColor = System.Drawing.Color.Red;
            this.lbl_rec.Location = new System.Drawing.Point(11, -2);
            this.lbl_rec.Name = "lbl_rec";
            this.lbl_rec.Size = new System.Drawing.Size(0, 16);
            this.lbl_rec.TabIndex = 60;
            // 
            // btn_view
            // 
            this.btn_view.Location = new System.Drawing.Point(13, 28);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(60, 23);
            this.btn_view.TabIndex = 69;
            this.btn_view.Text = "view";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // btn_rec
            // 
            this.btn_rec.Location = new System.Drawing.Point(79, 28);
            this.btn_rec.Name = "btn_rec";
            this.btn_rec.Size = new System.Drawing.Size(60, 23);
            this.btn_rec.TabIndex = 67;
            this.btn_rec.Text = "rec";
            this.btn_rec.UseVisualStyleBackColor = true;
            this.btn_rec.Click += new System.EventHandler(this.btn_rec_Click);
            // 
            // lbl_wheelTarget
            // 
            this.lbl_wheelTarget.AutoSize = true;
            this.lbl_wheelTarget.Location = new System.Drawing.Point(21, 29);
            this.lbl_wheelTarget.Name = "lbl_wheelTarget";
            this.lbl_wheelTarget.Size = new System.Drawing.Size(74, 12);
            this.lbl_wheelTarget.TabIndex = 24;
            this.lbl_wheelTarget.Text = "wheel target";
            // 
            // txt_wheelTarget
            // 
            this.txt_wheelTarget.Location = new System.Drawing.Point(105, 26);
            this.txt_wheelTarget.MaxLength = 7;
            this.txt_wheelTarget.Name = "txt_wheelTarget";
            this.txt_wheelTarget.Size = new System.Drawing.Size(80, 21);
            this.txt_wheelTarget.TabIndex = 23;
            this.txt_wheelTarget.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_stop_laneTracking);
            this.groupBox2.Controls.Add(this.btn_start_laneTracking);
            this.groupBox2.Location = new System.Drawing.Point(12, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 100);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lane Tracking";
            // 
            // btn_stop_laneTracking
            // 
            this.btn_stop_laneTracking.Location = new System.Drawing.Point(79, 29);
            this.btn_stop_laneTracking.Name = "btn_stop_laneTracking";
            this.btn_stop_laneTracking.Size = new System.Drawing.Size(60, 23);
            this.btn_stop_laneTracking.TabIndex = 73;
            this.btn_stop_laneTracking.Text = "stop";
            this.btn_stop_laneTracking.UseVisualStyleBackColor = true;
            this.btn_stop_laneTracking.Click += new System.EventHandler(this.btn_stop_laneTracking_Click);
            // 
            // btn_start_laneTracking
            // 
            this.btn_start_laneTracking.Location = new System.Drawing.Point(9, 29);
            this.btn_start_laneTracking.Name = "btn_start_laneTracking";
            this.btn_start_laneTracking.Size = new System.Drawing.Size(60, 23);
            this.btn_start_laneTracking.TabIndex = 72;
            this.btn_start_laneTracking.Text = "start";
            this.btn_start_laneTracking.UseVisualStyleBackColor = true;
            this.btn_start_laneTracking.Click += new System.EventHandler(this.btn_start_laneTracking_Click);
            // 
            // timer_wheelState
            // 
            this.timer_wheelState.Tick += new System.EventHandler(this.timer_wheelState_Tick);
            // 
            // timer_rec
            // 
            this.timer_rec.Interval = 20;
            this.timer_rec.Tick += new System.EventHandler(this.timer_rec_Tick);
            // 
            // timer_endtoend
            // 
            this.timer_endtoend.Tick += new System.EventHandler(this.timer_endtoend_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_stop_endtoend);
            this.groupBox3.Controls.Add(this.btn_start_endtoend);
            this.groupBox3.Controls.Add(this.lbl_wheelTarget);
            this.groupBox3.Controls.Add(this.txt_wheelTarget);
            this.groupBox3.Location = new System.Drawing.Point(12, 398);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 92);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "end to end";
            // 
            // btn_stop_endtoend
            // 
            this.btn_stop_endtoend.Location = new System.Drawing.Point(79, 59);
            this.btn_stop_endtoend.Name = "btn_stop_endtoend";
            this.btn_stop_endtoend.Size = new System.Drawing.Size(60, 23);
            this.btn_stop_endtoend.TabIndex = 71;
            this.btn_stop_endtoend.Text = "stop";
            this.btn_stop_endtoend.UseVisualStyleBackColor = true;
            this.btn_stop_endtoend.Click += new System.EventHandler(this.btn_stop_endtoend_Click);
            // 
            // btn_start_endtoend
            // 
            this.btn_start_endtoend.Location = new System.Drawing.Point(13, 59);
            this.btn_start_endtoend.Name = "btn_start_endtoend";
            this.btn_start_endtoend.Size = new System.Drawing.Size(60, 23);
            this.btn_start_endtoend.TabIndex = 70;
            this.btn_start_endtoend.Text = "start";
            this.btn_start_endtoend.UseVisualStyleBackColor = true;
            this.btn_start_endtoend.Click += new System.EventHandler(this.btn_start_endtoend_Click);
            // 
            // timer_view
            // 
            this.timer_view.Tick += new System.EventHandler(this.timer_view_Tick);
            // 
            // btn_constant
            // 
            this.btn_constant.Location = new System.Drawing.Point(25, 496);
            this.btn_constant.Name = "btn_constant";
            this.btn_constant.Size = new System.Drawing.Size(69, 23);
            this.btn_constant.TabIndex = 72;
            this.btn_constant.Text = "conatant";
            this.btn_constant.UseVisualStyleBackColor = true;
            this.btn_constant.Click += new System.EventHandler(this.btn_constant_Click);
            // 
            // btn_stop_conatant
            // 
            this.btn_stop_conatant.Location = new System.Drawing.Point(100, 496);
            this.btn_stop_conatant.Name = "btn_stop_conatant";
            this.btn_stop_conatant.Size = new System.Drawing.Size(97, 23);
            this.btn_stop_conatant.TabIndex = 73;
            this.btn_stop_conatant.Text = "stop_conatant";
            this.btn_stop_conatant.UseVisualStyleBackColor = true;
            this.btn_stop_conatant.Click += new System.EventHandler(this.btn_stop_conatant_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 661);
            this.Controls.Add(this.btn_stop_conatant);
            this.Controls.Add(this.btn_constant);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_WheelState);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Logitech g29 Autodriving";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_WheelState.ResumeLayout(false);
            this.gb_WheelState.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gb_WheelState;
        private System.Windows.Forms.Button btn_stop_state;
        private System.Windows.Forms.Label lbl_wheel;
        private System.Windows.Forms.TextBox txt_acc;
        private System.Windows.Forms.TextBox txt_wheel;
        private System.Windows.Forms.TextBox txt_brake;
        private System.Windows.Forms.Button btn_getState;
        private System.Windows.Forms.TextBox txt_clutch;
        private System.Windows.Forms.Label lbl_clutch;
        private System.Windows.Forms.Label lbl_acc;
        private System.Windows.Forms.Label lbl_brake;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timer_wheelState;
        private System.Windows.Forms.Timer timer_rec;
        private System.Windows.Forms.Timer timer_endtoend;
        private System.ComponentModel.BackgroundWorker worker_wheelState;
        private System.Windows.Forms.Label lbl_wheelTarget;
        private System.Windows.Forms.TextBox txt_wheelTarget;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_rec;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.Button btn_start_endtoend;
        private System.Windows.Forms.Button btn_stop_endtoend;
        private System.Windows.Forms.Label lbl_rec;
        private System.Windows.Forms.Timer timer_view;
        private System.Windows.Forms.Button btn_start_laneTracking;
        private System.Windows.Forms.Button btn_stop_laneTracking;
        private System.Windows.Forms.Timer timer_laneTracking;
        private System.Windows.Forms.Button btn_constant;
        private System.Windows.Forms.Button btn_stop_conatant;
    }
}

