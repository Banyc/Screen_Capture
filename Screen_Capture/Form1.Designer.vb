﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lblState = New System.Windows.Forms.Label()
        Me.tmrFrmLoad = New System.Windows.Forms.Timer(Me.components)
        Me.tray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.lbl_lang = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(12, 9)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(39, 15)
        Me.lblState.TabIndex = 0
        Me.lblState.Text = "Mode"
        '
        'tmrFrmLoad
        '
        '
        'tray
        '
        Me.tray.Icon = CType(resources.GetObject("tray.Icon"), System.Drawing.Icon)
        Me.tray.Text = "Screenshot OCR"
        Me.tray.Visible = True
        '
        'lbl_lang
        '
        Me.lbl_lang.AutoSize = True
        Me.lbl_lang.Location = New System.Drawing.Point(12, 24)
        Me.lbl_lang.Name = "lbl_lang"
        Me.lbl_lang.Size = New System.Drawing.Size(71, 15)
        Me.lbl_lang.TabIndex = 1
        Me.lbl_lang.Text = "Language"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(152, 53)
        Me.Controls.Add(Me.lbl_lang)
        Me.Controls.Add(Me.lblState)
        Me.Name = "Form1"
        Me.Opacity = 0R
        Me.ShowInTaskbar = False
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblState As Label
    Friend WithEvents tmrFrmLoad As Timer
    Friend WithEvents tray As NotifyIcon
    Friend WithEvents lbl_lang As Label
End Class
