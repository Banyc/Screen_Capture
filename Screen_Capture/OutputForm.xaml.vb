﻿Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Public Class OutputForm
    Private _content As String
    'Private _

    Public Sub New(content As String)

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        _content = content
    End Sub

    Private Sub OutputForm_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        lblOutput.Content = _content
    End Sub

    Private Sub OutputForm_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseDoubleClick
        Me.DialogResult = True  'Includes Me.Close()
        'Me.Close()
    End Sub

    Private Sub OutputForm_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseLeftButtonDown
        Me.DragMove()
    End Sub

    Private Sub OutputForm_MouseRightButtonUp(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseRightButtonUp
        'Me.DialogResult = False  'Includes Me.Close()
        Me.Close()
    End Sub

    Private Sub lblOutput_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles lblOutput.SizeChanged
        Me.Width = lblOutput.ActualWidth + 45
        Me.Height = lblOutput.ActualHeight + 40
        BottomRightForm()
        'Me.Opacity = 1
    End Sub

    'Locate Window to the center of the screen
    Private Sub CenterForm()
        Dim screenWidth As Double = System.Windows.SystemParameters.PrimaryScreenWidth
        Dim screenHeight As Double = System.Windows.SystemParameters.PrimaryScreenHeight
        Dim windowWidth As Double = Me.Width
        Dim windowHeight As Double = Me.Height
        Me.Left = (screenWidth / 2) - (windowWidth / 2)
        Me.Top = (screenHeight / 2) - (windowHeight / 2)
    End Sub

    'Locate Window to the bottom right of the screen
    Private Sub BottomRightForm()
        Dim screenWidth As Double = System.Windows.SystemParameters.WorkArea.Width
        Dim screenHeight As Double = System.Windows.SystemParameters.WorkArea.Height
        Dim windowWidth As Double = Me.Width
        Dim windowHeight As Double = Me.Height
        Me.Left = screenWidth - windowWidth
        Me.Top = screenHeight - windowHeight
    End Sub

    'Change border color when mouse enter the form
    Private Sub OutputForm_MouseEnter(sender As Object, e As MouseEventArgs) Handles Me.MouseEnter
        Card.Stroke = Media.Brushes.CornflowerBlue
        Card.StrokeThickness = 1
    End Sub

    'Change border color when mouse enter the form
    Private Sub OutputForm_MouseLeave(sender As Object, e As MouseEventArgs) Handles Me.MouseLeave
        Card.Stroke = Media.Brushes.Gray
        Card.StrokeThickness = 0.2
    End Sub
End Class
