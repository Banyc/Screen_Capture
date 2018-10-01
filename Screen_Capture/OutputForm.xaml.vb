﻿Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Public Class OutputForm
    Private _content As String

    Public Sub New(content As String)

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        _content = content
    End Sub

    Private Sub OutputForm_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        lblOutput.Content = _content
    End Sub

    'set the _content to clipboard once again
    Private Sub Card_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles Card.MouseLeftButtonDown
        Me.DragMove()
        If e.ClickCount = 2 Then  'https://social.msdn.microsoft.com/Forums/vstudio/en-US/83ac6fbd-af42-4b9c-897e-142abb0a8199/can-not-use-event-double-click-on-button?forum=vbgeneral
            Clipboard.Clear()
            Clipboard.SetText(_content)
            Me.Close()
        End If
    End Sub
    Private Sub lblOutput_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles lblOutput.MouseLeftButtonDown
        Call Card_MouseLeftButtonDown(sender, e)
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

    ''Locate Window to the center of the screen
    'Private Sub CenterForm()
    '    Dim screenWidth As Double = System.Windows.SystemParameters.PrimaryScreenWidth
    '    Dim screenHeight As Double = System.Windows.SystemParameters.PrimaryScreenHeight
    '    Dim windowWidth As Double = Me.Width
    '    Dim windowHeight As Double = Me.Height
    '    Me.Left = (screenWidth / 2) - (windowWidth / 2)
    '    Me.Top = (screenHeight / 2) - (windowHeight / 2)
    'End Sub

    'Locate Window to the bottom right of the screen
    Private Sub BottomRightForm()
        Dim screenWidth As Double = System.Windows.SystemParameters.WorkArea.Width
        Dim screenHeight As Double = System.Windows.SystemParameters.WorkArea.Height
        Dim windowWidth As Double = Me.Width
        Dim windowHeight As Double = Me.Height
        Me.Left = screenWidth - windowWidth
        Me.Top = screenHeight - windowHeight
    End Sub

    'Change border color when mouse enters the form
    Private Sub Card_MouseEnter(sender As Object, e As MouseEventArgs) Handles Card.MouseEnter
        Card.Stroke = Media.Brushes.CornflowerBlue
        Card.StrokeThickness = 2
    End Sub
    Private Sub lblOutput_MouseEnter(sender As Object, e As MouseEventArgs) Handles lblOutput.MouseEnter
        Call Card_MouseEnter(sender, e)
    End Sub

    'Change border color when mouse leaves the form
    Private Sub Card_MouseLeave(sender As Object, e As MouseEventArgs) Handles Card.MouseLeave
        Card.Stroke = Media.Brushes.Gray
        Card.StrokeThickness = 0.2
    End Sub
    Private Sub lblOutput_MouseLeave(sender As Object, e As MouseEventArgs) Handles lblOutput.MouseLeave
        Call Card_MouseLeave(sender, e)
    End Sub

    '=== https://stackoverflow.com/questions/5958508/fading-out-a-window

    Private AlreadyFaded As Boolean = False

    Private Sub window_Closing(ByVal sender As Object, ByVal e As CancelEventArgs) Handles Me.Closing
        If Not AlreadyFaded Then
            AlreadyFaded = True
            e.Cancel = True
            Dim anim = New DoubleAnimation(0, CType(TimeSpan.FromSeconds(0.2), Duration))
            AddHandler anim.Completed, New EventHandler(AddressOf anim_Completed)
            Me.BeginAnimation(UIElement.OpacityProperty, anim)
        End If
    End Sub

    Private Sub anim_Completed(ByVal sender As Object, ByVal e As EventArgs)
        Close()
    End Sub
    '=== end reference
End Class